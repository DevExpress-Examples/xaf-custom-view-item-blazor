Namespace MySolution.Blazor.Server
	Partial Public Class MySolutionBlazorApplication
		''' <summary> 
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary> 
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Component Designer generated code"

		''' <summary> 
		''' Required method for Designer support - do not modify 
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
			Me.module2 = New DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule()
			Me.module3 = New MySolution.Module.MySolutionModule()
			Me.module4 = New MySolution.Module.Blazor.MySolutionBlazorModule()

			DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()

			' 
			' MySolutionBlazorApplication
			' 
			Me.ApplicationName = "MySolution"
			Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
			Me.Modules.Add(Me.module1)
			Me.Modules.Add(Me.module2)
			Me.Modules.Add(Me.module3)
			Me.Modules.Add(Me.module4)
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.DatabaseVersionMismatch += new System.EventHandler<DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs>(this.MySolutionBlazorApplication_DatabaseVersionMismatch);

			DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub

		#End Region

		Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
		Private module2 As DevExpress.ExpressApp.Blazor.SystemModule.SystemBlazorModule
		Private module3 As MySolution.Module.MySolutionModule
		Private module4 As MySolution.Module.Blazor.MySolutionBlazorModule
	End Class
End Namespace
