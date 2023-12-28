using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Calendars;

namespace SyncfusionDocumentation_Personal.Pages.DataBinding
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

        //Component rendering code
        public DateTime? DateValue { get; set; } = DateTime.Now.Date;
        protected RenderFragment dynamicComponent { get; set; }
        protected RenderFragment CreateComponent() => builder =>
        {
            builder.OpenComponent(0, typeof(SfDatePicker<DateTime>));
            builder.AddAttribute(1, "ID", "MyDynamicId");
            builder.AddAttribute(2, "Placeholder", "Choose a date");
            //Binding the value property with DateValue property.
            builder.AddAttribute(3, "Value", DateValue);
            builder.AddAttribute(4, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.
                    CreateBinder(this, _value => DateValue = _value, DateValue));

            builder.CloseComponent();
        };

        protected void RenderComponent()
        {
            dynamicComponent = CreateComponent();
        }
        protected void onChange()
        {
            DateValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 07);
        }

    }
}
