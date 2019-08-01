# WijmoBlazor
Wijmo 5 components for Blazor (grid, chart, gauge, inputs).

[Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor)
is Microsoft's framework for building interactive client
side web UI with .NET. It uses WebAssembly to run .NET code on the
client so you can develop in C# instead of JavaScript/TypeScript.

**WijmoBlazor** is a library that wraps several
[Wijmo](https://www.grapecity.com/wijmo) controls as regular 
**Blazor** components. For example, this is how you would create 
a **FlexGrid** in a **Blazor** page:

```html
    <WJ.FlexGrid
        IsReadOnly="true"
        HeadersVisibility="WJ.HeadersVisibility.Column"
        ItemsSource="@forecasts">
        <WJ.Column Binding="date" Header="Date" Width="@("2*")" />
        <WJ.Column Binding="temperatureC" Header="Temp. (C)" Width="@("2*")" />
        <WJ.Column Binding="temperatureF" Header="Temp. (F)" Width="@("2*")" />
        <WJ.Column Binding="summary" Header="Summary" Width="@("3*")" />
    </WJ.FlexGrid>
```

This [sample](https://wijmoblazor.firebaseapp.com) shows all the controls 
in **WijmoBlazor**.

The **WijmoBlazor** library shows how you can use Blazor's
[JavaScript Interop](https://docs.microsoft.com/en-us/aspnet/core/blazor/javascript-interop?view=aspnetcore-3.0)
to connect C# code to JavaScript libraries such as **Wijmo**.

**Blazor** has not been officially released yet, so at this point **WijmoBlazor**
is a technology preview/sample.
When **Blazor** ships, we expect to include it **WijmoBlazor** in the **Wijmo**
package as an extra interop (along with **React**, **Vue**, and **Angular**).

