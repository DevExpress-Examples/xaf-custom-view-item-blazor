using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CustomViewItem.Blazor.Server.Editors.ButtonViewItem;

public interface IModelButtonDetailViewItemBlazor : IModelViewItem;

[ViewItem(typeof(IModelButtonDetailViewItemBlazor))]
public class ButtonDetailViewItemBlazor(IModelViewItem model, Type objectType) : 
    ViewItem(objectType, model.Id), 
    IComponentContentHolder, 
    IComplexViewItem
{
    public ButtonModel ComponentModel => componentModel;
    
    private ButtonModel componentModel;
    private XafApplication application;

    RenderFragment IComponentContentHolder.ComponentContent =>
        ComponentModelObserver.Create(componentModel, componentModel.GetComponentContent());
    void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application) {
        this.application = application;
    }

    protected override object CreateControlCore() {
        componentModel = new ButtonModel
        {
            Text = "Click me!",
            Click = EventCallback.Factory.Create<MouseEventArgs>(this, ComponentModel_Click),
        };
        return componentModel;
    }
    private void ComponentModel_Click() {
        application.ShowViewStrategy.ShowMessage("Action is executed!");
    }
}
