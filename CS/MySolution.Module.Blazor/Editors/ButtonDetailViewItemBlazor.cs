using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using MySolution.Module.Blazor.Editors;

namespace MySolution.Module.Blazor
{
    public interface IModelButtonDetailViewItemBlazor : IModelViewItem { }

    [ViewItem(typeof(IModelButtonDetailViewItemBlazor))]
    public class ButtonDetailViewItemBlazor : ViewItem, IComplexViewItem {
        public class ButtonHolder : IComponentContentHolder {
            public ButtonHolder(ButtonModel componentModel) {
                ComponentModel = componentModel;
            }
            public ButtonModel ComponentModel { get; }
            RenderFragment IComponentContentHolder.ComponentContent => ButtonRenderer.Create(ComponentModel);
        }
        private XafApplication application;
        public ButtonDetailViewItemBlazor(IModelViewItem model, Type objectType) : base(objectType, model.Id) { }
        void IComplexViewItem.Setup(IObjectSpace objectSpace, XafApplication application) {
            this.application = application;
        }
        protected override object CreateControlCore() => new ButtonHolder(new ButtonModel());
        protected override void OnControlCreated() {
            if (Control is ButtonHolder holder) {
                holder.ComponentModel.Text = "Click me!";
                holder.ComponentModel.Click += ComponentModel_Click;
            }
            base.OnControlCreated();
        }
        public override void BreakLinksToControl(bool unwireEventsOnly) {
            if (Control is ButtonHolder holder) {
                holder.ComponentModel.Click -= ComponentModel_Click;
            }
            base.BreakLinksToControl(unwireEventsOnly);
        }
        private void ComponentModel_Click(object sender, EventArgs e) {
            application.ShowViewStrategy.ShowMessage("Action is executed!");
        }
    }
}
