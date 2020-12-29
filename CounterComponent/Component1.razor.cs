using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CounterComponent
{
    public partial class Component1
    {
        [Parameter] public string ParentName { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        private async Task GetTextAsync()
        {
            await using var js = new ExampleJsInterop(JsRuntime);
            var text = await js.Prompt("Enter some text:");
            
            await TextChanged.InvokeAsync(text);
            Text = text;
        }
    }
}