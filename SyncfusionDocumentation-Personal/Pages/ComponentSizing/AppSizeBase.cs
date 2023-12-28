using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace SyncfusionDocumentation_Personal.Pages.ComponentSizing
{
    public class AppSizeBase : ComponentBase
    {
        [Inject]
        public IJSRuntime jSRuntime { get; set; }

        public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 24);


        public async void callOnTouch(MouseEventArgs args)
        {
            await jSRuntime.InvokeAsync<string>("onTouch");
        }
        public async void callOnMouse(MouseEventArgs args)
        {
            await jSRuntime.InvokeAsync<string>("onMouse");
        }
    }
}
