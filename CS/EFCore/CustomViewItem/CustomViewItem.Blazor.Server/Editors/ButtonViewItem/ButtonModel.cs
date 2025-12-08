using DevExpress.ExpressApp.Blazor.Components.Models;
using Microsoft.AspNetCore.Components;

namespace CustomViewItem.Blazor.Server.Editors.ButtonViewItem;

public class ButtonModel : ComponentModelBase {
    public string Text {
        get => GetPropertyValue<string>();
        set => SetPropertyValue(value);
    }
    public EventCallback Click {
        get => GetPropertyValue<EventCallback>();
        set => SetPropertyValue(value);
    }

    public override Type ComponentType => typeof(Button);
}
