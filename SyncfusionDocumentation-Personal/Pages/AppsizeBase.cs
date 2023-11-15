using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace SyncfusionDocumentation_Personal.Pages
{
    public class AppsizeBase : ComponentBase
    {
        [Inject]
        public IJSRuntime jSRuntime { get; set; }


        private async void callOntouch(MouseEventArgs args)
        {
            await jSRuntime.InvokeAsync<string>("onTouch");
        }
    }
}
