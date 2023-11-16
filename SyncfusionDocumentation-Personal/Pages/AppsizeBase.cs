using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace SyncfusionDocumentation_Personal.Pages
{
    public class AppsizeBase : ComponentBase
    {
        [Inject]
        public IJSRuntime jSRuntime { get; set; }

        public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 24);


        private async void callOnTouch(MouseEventArgs args)
        {
            await jSRuntime.InvokeAsync<string>("onTouch");
        }
        private async void callOnMouse(MouseEventArgs args)
        {
            await jSRuntime.InvokeAsync<string>("onMouse");
        }
    }
}
