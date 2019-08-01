// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

const wb = window['wijmoBlazor'] = window['wijmoBlazor'] || {};

// create and initialize a Wijmo control
wb.initControl = function (netRef, host, className, props, events) {

    // get control
    let ctl = wijmo.Control.getControl(host);

    // do this only once
    if (!ctl) {

        // create control
        ctl = this.createObject(className, host);

        // use a timeout to populate property lists before initializing the control
        setTimeout(() => {

            // special case:
            // if this is a grid and it has columns, then autoGenerateColumns should default to false
            if (ctl instanceof wijmo.grid.FlexGrid && ctl.columns.length) {
                if (props.autoGenerateColumns == null) {
                    ctl.autoGenerateColumns = false;
                }
            }

            // set control properties
            if (props) {
                for (let prop in props) {
                    if (prop === 'class') { // special case: set HTML className on host element
                        wijmo.addClass(host, props[prop]);
                    } else {
                        let value = props[prop];
                        props[prop] = this.setPropObj(ctl, prop, value);
                    }
                }
            }

            // hook up events
            this.connectEventHandlers(netRef, ctl, events);
        });
    }

    // save reference to control
    return this.saveObjRef(ctl);
}.bind(wb);

// create and initialize a markup property
wb.initMarkupProperty = function (netRef, host, propName, className, props, events) {

    // hide dummy host element
    host.style.display = 'none';

    // find parent control
    let ctlHost = wijmo.closest(host, '.wj-control');
    let ctl = ctlHost ? wijmo.Control.getControl(ctlHost) : null;
    wijmo.assert(ctl, 'can\'t find parent for this ' + className + '.');

    // handle extender pattern (e.g. FlexGridFilter(grid), ChartAnimator(chart), etc)
    let propObj = null;
    if (propName === '(extender)') {
        propObj = this.createObject(className, ctl);
    } else {

        // if the property is a collection, create an item and add to the collection
        let propVal = ctl[propName];
        if (wijmo.isArray(propVal)) {
            propObj = this.createObject(className);
            if (props) {
                wijmo.copy(propObj, props);
            }
            propVal.push(propObj);
        } else if (wijmo.isObject(propVal)) { // if not, copy our properties to the object
            propObj = propVal;
            wijmo.copy(propObj, props);
        } else {
            wijmo.assert(false, 'Cannot find property "' + propName + '" in control "' + className + '".');
        }
    }

    // hook up event handlers
    this.connectEventHandlers(netRef, propObj, events);

    // save reference to markup property
    return this.saveObjRef(propObj);

}.bind(wb);

// create a tooltip for the parent element
wb.initTooltip = function (host, props, key) {

    // hide host element
    host.style.display = 'none';

    // create tooltip
    if (!this.tooltip) {
        this.tooltip = new wijmo.Tooltip();
    }

    // set properties (will apply to all tooltips)
    wijmo.copy(this.tooltip, props);

    // add tooltip to the host element
    setTimeout(() => { // let the host's RenderFragment update first...
        this.tooltip.setTooltip(host.parentElement, host.innerHTML);
    });

    // save reference to tooltip object
    return key || this.saveObjRef(this.tooltip);

}.bind(wb);

// create a CollectionView that can be shared by multiple components
wb.initCollectionView = function (netRef, host, props, events) {

    // hide host element
    host.style.display = 'none';

    // create the new collectionView
    let view = new wijmo.collections.CollectionView();
    wijmo.copy(view, props);

    // hook up events
    this.connectEventHandlers(netRef, view, events);

    // save reference to the CollectionView
    return this.saveObjRef(view);

}.bind(wb);

// save an object reference in our element->object map
wb.saveObjRef = function (obj) {
    if (!this.objMap) {
        this.objMap = {};
        this.objCtr = 0;
        this.refPrefix = '#jsRef:';
    }
    let key = this.refPrefix + this.objCtr++;
    this.objMap[key] = obj;
    //console.log('stored object at key', key, 'length is', Object.keys(this.objMap).length);
    return key;
}.bind(wb);

// gets the JS object associated with a key
wb.getObjRef = function (key) {
    let map = this.objMap;
    return map ? map[key] : null;
}.bind(wb);

// dispose of an object
wb.dispose = function (key) {
    //let obj = this.getObjRef(key);
    //if (obj instanceof wijmo.Control) {
    //    obj.dispose(); // can't do this, causes crashes
    //}
    delete this.objMap[key];
    //console.log('disposed, remaining', Object.keys(this.objMap).length);
}.bind(wb);

// hook up a control's event handlers
wb.connectEventHandlers = function (netRef, obj, events) {
    if (obj && events) {
        events.forEach(event => {
            obj[event].addHandler((s, e) => {

                // raise the event
                let args = JSON.stringify(this.marshallOut(e));
                let result = netRef.invokeMethod('InvokeRaiseEvent', event, args);

                // cancel the event if the handler told us to
                //console.log('event', event, 'returned', result);
                if (result && e instanceof wijmo.CancelEventArgs) {
                    result = JSON.parse(result);
                    e.cancel = result.Cancel;
                }
            });
        });
    }
}.bind(wb);

// create an object based on its class name
wb.createObject = function (className, ctorParam) {
    let obj = window;
    className.split('.').forEach(part => {
        obj = obj[part];
        wijmo.assert(obj, 'Wijmo class not loaded: "' + className + '". Please see https://www.grapecity.com/wijmo/docs/GettingStarted/Referencing-Wijmo');
    });
    return new obj(ctorParam);
}.bind(wb);

// get a property from a Wijmo control
wb.getProp = function (key, name) {
    let obj = this.getObjRef(key),
        value = obj ? obj[name] : null;

    // special cases: Date, CellRange, CellRange[]
    if (wijmo.isDate(value)) {
        return this.marshallOut(value);
    }
    if (value instanceof wijmo.grid.CellRange) {
        return this.marshallOut(value);
    }
    if (wijmo.isArray(value) && value[0] instanceof wijmo.grid.CellRange) {
        return value.map(rng => this.marshallOut(rng));
    }

    // done
    return value;
}.bind(wb);

// set a property on a Wijmo control (direct assignment)
wb.setProp = function (key, name, value) {
    let obj = this.getObjRef(key);
    if (obj) {
        this.setPropObj(obj, name, value);
        return true;
    }
    return false;
}.bind(wb);

// set a property on an object (and handle deep bindings like "tooltip.content")
wb.setPropObj = function (obj, name, value) {
    for (let dot = name.indexOf('.'); dot > -1; dot = name.indexOf('.')) {
        obj = obj[name.substr(0, dot)];
        name = name.substr(dot + 1);
    }
    value = this.marshallIn(name, value);
    obj[name] = value;
    return value;
}.bind(wb);

// call a method on a Wijmo control
wb.call = function (key, method, ...params) {
    let obj = this.getObjRef(key);
    if (obj) {
        let fn = obj[method];
        if (wijmo.isFunction(fn)) {
            return fn.apply(obj, ...params);
        }
    }
    wijmo.assert(false, "Call to [" + method + "] failed.");
}.bind(wb);

// show a popup dialog and invoke a callback when the dialog closes
wb.showPopupWithCallback = function (netRef, key, modal) {
    let obj = this.getObjRef(key);
    if (obj instanceof wijmo.input.Popup) {
        obj.show(modal, () => {
            return netRef.invokeMethod('_PopupCallback', obj.dialogResult);
        });
    } else {
        wijmo.assert(false, "Invalid host in call to Popup.show.");
    }
}.bind(wb);

// REVIEW:
// marshall values coming from Blazor:
// convert empty objects into null and dates in arrays
wb.rxDate = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:[\d.]+Z?$/;
wb.marshallIn = function (name, val) {

    // resolve JS references
    if (wijmo.isString(val) && val.indexOf(this.refPrefix) === 0) {
        let ref = this.getObjRef(val);
        if (ref) {
            return ref;
        }
    }

    // convert {} into null
    if (!wijmo.isPrimitive(val) && val) {
        if (!Object.keys(val).length && val.constructor === Object) {
            return null;
        }
    }

    // convert strings into dates
    if (wijmo.isString(val) && val.match(this.rxDate)) {
        val = new Date(val);

        // convert GMT to local
        var local = new Date(val.getTime() + val.getTimezoneOffset() * 60000);
        //console.log('convert GMT to local', val, '=>', local);
        val = local;
    }

    // convert strings into dates within arrays
    if (wijmo.isArray(val)) {
        val.forEach(item => {
            for (let key in item) {
                let val = item[key];
                if (wijmo.isString(val) && val.match(this.rxDate)) {
                    item[key] = this.marshallIn(key, val);
                }
            }
        });
    }

    // done
    return val;

}.bind(wb);

// create serializable objects to send to Blazor via interop
// REVIEW: System.Text.Json uses a stupid camelCase capitalizaton 
// policy that may screw up JavaScript's JSON conversions.
// https://github.com/aspnet/AspNetCore/issues/10156
wb.marshallOut = function (val) {

    // convert local to GMT
    if (val instanceof Date) {
        var gmt = new Date(val.getTime() - val.getTimezoneOffset() * 60000);
        //console.log('convert local to GMT', val, '=>', gmt);
        return gmt;
    }

    // CellRange
    if (val instanceof wijmo.grid.CellRange) {
        return { // REVIEW: lowercase prop names when dealing with events
            row: val.row,
            col: val.col,
            row2: val.row2,
            col2: val.col2
        };
    }

    // other objects
    let obj = {};
    for (let k in val) {
        if (k[0] !== '_') { // skip internal stuff
            let capName = k[0].toUpperCase() + k.substr(1);
            let value = val[k];
            if (value instanceof wijmo.grid.CellRange) { // include CellRange objects
                obj[capName] = { // REVIEW: uppercase prop names when dealing with events
                    Row: value.row,
                    Col: value.col,
                    Row2: value.row2,
                    Col2: value.col2
                };
            } else if (wijmo.isPrimitive(val[k])) { // include primitive values
                obj[capName] = val[k];
            }
        }
    }

    // done
    return  obj;
}.bind(wb);
