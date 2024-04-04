using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Syncfusion.Blazor.Inputs;

namespace SyncfusionDocumentation_Personal.ExtendandCustomcomps;

public class SyncTextBox2 : ComponentBase
{
    [Parameter]
    public string ID { get; set; }

    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public Dictionary<string, object> TextAttributes { get; set; }
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        // create div element.
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "form-group");

        // creating label element.
        builder.OpenElement(2, "label");
        builder.AddAttribute(3, "for", ID);
        builder.AddContent(4, Label);
        builder.CloseElement();

        // create Syncfusion TextBox component.
        builder.OpenComponent<SfTextBox>(5);
        builder.AddAttribute(6, "ID", ID);
        // Added similar attributes used in the component.
        if (TextAttributes != null)
        {
            builder.AddMultipleAttributes(3, TextAttributes);
        }
        builder.CloseComponent();
        builder.CloseElement();
    }
}
