Imports System
Imports DevExpress.ExpressApp.Blazor.Components.Models

Namespace MySolution.Module.Blazor
	Public Class ButtonModel
		Inherits ComponentModelBase

		Public Property Text() As String
			Get
				Return GetPropertyValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetPropertyValue(value)
			End Set
		End Property
		Public Sub ClickFromUI()
			ClickEvent?.Invoke(Me, EventArgs.Empty)
		End Sub
		Public Event Click As EventHandler
	End Class
End Namespace
