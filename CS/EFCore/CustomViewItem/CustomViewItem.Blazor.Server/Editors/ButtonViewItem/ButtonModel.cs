using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CustomViewItem.Blazor.Server.Editors.ButtonViewItem;

public class ButtonModel : ComponentModelBase {
    public string Text {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }
    public EventCallback<MouseEventArgs> Click {
        get => GetPropertyValue<EventCallback<MouseEventArgs>>();
        set => SetPropertyValue(value);
    }

    public override Type ComponentType => typeof(Button);
}
