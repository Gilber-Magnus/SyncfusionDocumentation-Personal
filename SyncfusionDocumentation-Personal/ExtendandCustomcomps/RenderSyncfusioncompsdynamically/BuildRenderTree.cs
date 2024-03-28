using Microsoft.AspNetCore.Components;

namespace SyncfusionDocumentation_Personal.ExtendandCustomcomps.RenderSyncfusioncompsdynamically
{
    public class BuildRenderTree : ComponentBase
    {
        [Parameter]
        public string ID { get; set; }

        [Parameter]
        public string Label { get; set; }

    }
}
