<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/390342511/22.2.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1017666)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# XAF Blazor - Use a Custom View Item to Add a Button to a Detail View

This example shows how to add a custom component to a Detail View. We add a button to a Detail View and display a message when a user clicks the button.

![](./images/blazor-custom-view-button.png)

## Implementation Details

1. In the ASP.NET Core Blazor Module project, create a new [Razor component](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/) and name it _ButtonRenderer_. In this component, configure the [DxButton](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxButton) component, add the `Create` method that creates [RenderFragment](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.renderfragment), and handle the `Click` event. 

   **Razor Component** - [CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonRenderer.razor](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonRenderer.razor)
 
2. Ensure that the component's [`Build Action`](https://docs.microsoft.com/en-us/visualstudio/ide/build-actions) property is set to `Content`.

3. Create a `ComponentModelBase` descendant and name it _ButtonModel_. In this class, add properties and methods that describe your component.
   
   **Component Model** - [CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonRenderer.razor](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonModel.cs)

4. In the ASP.NET Core Blazor Module project, create the _ButtonDetailViewItemBlazor_ View Item and decorate it with the [ViewItemAttribute](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.ViewItemAttribute) to make this View Item appear in the Application Model's **ViewItems** node.

5. Override the `CreateControlsCore` method to get a `ButtonHolder` instance. `ButtonHolder` returns a render fragment with our custom component. Note that in the XAF Blazor application, `CreateControlsCore` should return an instance that implements the `IComponentContentHolder` interface.

6. Override the `OnControlsCreated` method. In this method, subscribe to the component model’s `Click` event. Implement the logic in the `ComponentModel_Click` event handler (in our example, the [ShowMessage](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ShowViewStrategyBase.ShowMessage(System.String-DevExpress.ExpressApp.InformationType-System.Int32-DevExpress.ExpressApp.InformationPosition)) is called). 

7. Override the [BreakLinksToControls](https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Editors.ListEditor.BreakLinksToControls) method. In this method, unsubscribe from the component model’s `Click` event to release resources.

   **Custom View Item** - [CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonDetailViewItemBlazor.cs](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonDetailViewItemBlazor.cs).
   
See the following help topic for more information: [How to: Use a Custom View Item to Add a Button to a Detail View](https://docs.devexpress.com/eXpressAppFramework/113653/ui-construction/view-items-and-property-editors/how-to-add-a-button-to-a-detail-view-using-custom-view-item).

<!-- default file list -->
## Files to Look at

* [ButtonRenderer.razor](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonRenderer.razor)
* [ButtonModel.cs](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonModel.cs)
* [ButtonDetailViewItemBlazor.cs](./CS/EFCore/CustomViewItem/CustomViewItem.Blazor.Server/Editors/ButtonViewItem/ButtonDetailViewItemBlazor.cs)
<!-- default file list end -->

## Documentation

* [Using a Custom Control that is not Integrated by Default](https://docs.devexpress.com/eXpressAppFramework/113610/ui-construction/using-a-custom-control-that-is-not-integrated-by-default/using-a-custom-control-that-is-not-integrated-by-default)
* [How to: Implement a View Item](https://docs.devexpress.com/eXpressAppFramework/112641/ui-construction/view-items-and-property-editors/how-to-implement-a-view-item)

## More Examples

[XAF - Add a Custom Button to a Form (WinForms and ASP.NET WebForms)](https://github.com/DevExpress-Examples/XAF_how-to-add-a-button-to-a-form-using-custom-view-item-t137443)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-custom-view-item-blazor&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xaf-custom-view-item-blazor&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
