using Microsoft.AspNetCore.Components;

namespace SyncfusionDocumentation_Personal.DataBinding
{
    public class TwoWayDatabindingBase : ComponentBase
    {
        public string textValue { get; set; }

        protected override void OnInitialized()
        {
            textValue = "Syncfusion Blazor";
        }

        protected Dictionary<string, object> htmlAttribute = new Dictionary<string, object>()
        {
            { "bind", "textValue" }
        };
    }
}
