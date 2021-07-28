Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Blazor
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports Microsoft.AspNetCore.Components

Namespace MySolution.Module.Blazor
	Public Interface IModelButtonDetailViewItemBlazor
		Inherits IModelViewItem

	End Interface

	<ViewItem(GetType(IModelButtonDetailViewItemBlazor))>
	Public Class ButtonDetailViewItemBlazor
		Inherits ViewItem
		Implements IComplexViewItem

		Public Class ButtonHolder
			Implements IComponentContentHolder

			Public Sub New(ByVal componentModel As ButtonModel)
				Me.ComponentModel = componentModel
			End Sub
			Public ReadOnly Property ComponentModel() As ButtonModel
			Private ReadOnly Property IComponentContentHolder_ComponentContent() As RenderFragment Implements IComponentContentHolder.ComponentContent
				Get
					Return ButtonRenderer.Create(ComponentModel)
				End Get
			End Property
		End Class
		Private application As XafApplication
		Public Sub New(ByVal model As IModelViewItem, ByVal objectType As Type)
			MyBase.New(objectType, model.Id)
		End Sub
		Private Sub IComplexViewItem_Setup(ByVal objectSpace As IObjectSpace, ByVal application As XafApplication) Implements IComplexViewItem.Setup
			Me.application = application
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			Return New ButtonHolder(New ButtonModel())
		End Function
		Protected Overrides Sub OnControlCreated()
			Dim tempVar As Boolean = TypeOf Control Is ButtonHolder
			Dim holder As ButtonHolder = If(tempVar, CType(Control, ButtonHolder), Nothing)
			If tempVar Then
				holder.ComponentModel.Text = "Click me!"
				AddHandler holder.ComponentModel.Click, AddressOf ComponentModel_Click
			End If
			MyBase.OnControlCreated()
		End Sub
		Public Overrides Sub BreakLinksToControl(ByVal unwireEventsOnly As Boolean)
			Dim tempVar As Boolean = TypeOf Control Is ButtonHolder
			Dim holder As ButtonHolder = If(tempVar, CType(Control, ButtonHolder), Nothing)
			If tempVar Then
				RemoveHandler holder.ComponentModel.Click, AddressOf ComponentModel_Click
			End If
			MyBase.BreakLinksToControl(unwireEventsOnly)
		End Sub
		Private Sub ComponentModel_Click(ByVal sender As Object, ByVal e As EventArgs)
			application.ShowViewStrategy.ShowMessage("Action is executed!")
		End Sub
	End Class
End Namespace
