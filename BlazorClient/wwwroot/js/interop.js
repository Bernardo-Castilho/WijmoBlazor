// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.interop = {
    primes: function (n) {
        var start = Date.now();
        var primes = [];
        var i = 3;
        var c = 0;
        for (var count = 2; count <= n; i++) {
            for (c = 2; c < i; c++) // check whether c is prime or not
            {
                if (i % c === 0) {
                    break;
                }
            }
            if (c === i) // c is prime
            {
                primes.push(c);
                count++;
            }
        }
        //console.log('JS done in', Date.now() - start, 'ms', 'result is', primes[primes.length - 1]);
        return primes[primes.length - 1];
    },
    exportCSV: function (csv, fileName) {
        let fileType = 'txt/csv;charset=utf-8';
        if (navigator.msSaveBlob) { // IE 
            navigator.msSaveBlob(new Blob([csv], {
                type: fileType
            }), fileName);
        } else {
            let e = document.createElement('a');
            e.setAttribute('href', 'data:' + fileType + ',' + encodeURIComponent(csv));
            e.setAttribute('download', fileName);
            e.style.display = 'none';
            document.body.appendChild(e);
            e.click();
            document.body.removeChild(e);
        }
    }

};
