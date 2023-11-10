using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SyncfusionDocumentation_Personal.Pages
{
    public class SizeModeBase : ComponentBase
    {
        protected bool isChecked = true;
        protected DateTime? DateValue { get; set; } = new DateTime(2023, 11, 08);

        //protected string ButtonText { get; set; } = "e-bigger";
        protected string CssClass { get; set; } = null; 

        protected void To_TouchMode(MouseEventArgs e)
        {
            CssClass = "e-bigger";
        }
        protected void To_MouseMode(MouseEventArgs e)
        {
            CssClass = null;
        }
    }
}
