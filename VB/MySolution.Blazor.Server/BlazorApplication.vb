Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Blazor
Imports DevExpress.ExpressApp.SystemModule
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports DevExpress.ExpressApp.Xpo
Imports MySolution.Blazor.Server.Services

Namespace MySolution.Blazor.Server
	Partial Public Class MySolutionBlazorApplication
		Inherits BlazorApplication

		Public Sub New()
			InitializeComponent()
		End Sub
		Protected Overrides Sub OnSetupStarted()
			MyBase.OnSetupStarted()
			Dim configuration As IConfiguration = ServiceProvider.GetRequiredService(Of IConfiguration)()
			If configuration.GetConnectionString("ConnectionString") IsNot Nothing Then
				ConnectionString = configuration.GetConnectionString("ConnectionString")
			End If
#If EASYTEST Then
			If configuration.GetConnectionString("EasyTestConnectionString") IsNot Nothing Then
				ConnectionString = configuration.GetConnectionString("EasyTestConnectionString")
			End If
#End If
#If DEBUG Then
			If System.Diagnostics.Debugger.IsAttached AndAlso CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema Then
				DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
			End If
#End If
		End Sub
		Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
			Dim dataStoreProvider As IXpoDataStoreProvider = GetDataStoreProvider(args.ConnectionString, args.Connection)
			args.ObjectSpaceProviders.Add(New XPObjectSpaceProvider(dataStoreProvider, True))
			args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
		End Sub
		Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
			Dim accessor As XpoDataStoreProviderAccessor = ServiceProvider.GetRequiredService(Of XpoDataStoreProviderAccessor)()
			SyncLock accessor
				If accessor.DataStoreProvider Is Nothing Then
					accessor.DataStoreProvider = XPObjectSpaceProvider.GetDataStoreProvider(connectionString, connection, True)
				End If
			End SyncLock
			Return accessor.DataStoreProvider
		End Function
		Private Sub MySolutionBlazorApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
#If EASYTEST Then
			e.Updater.Update()
			e.Handled = True
#Else
			If System.Diagnostics.Debugger.IsAttached Then
				e.Updater.Update()
				e.Handled = True
			Else
				Dim message As String = "The application cannot connect to the specified database, " & "because the database doesn't exist, its version is older " & "than that of the application or its schema does not match " & "the ORM data model structure. To avoid this error, use one " & "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article."

				If e.CompatibilityError IsNot Nothing AndAlso e.CompatibilityError.Exception IsNot Nothing Then
					message &= vbCrLf & vbCrLf & "Inner exception: " & e.CompatibilityError.Exception.Message
				End If
				Throw New InvalidOperationException(message)
			End If
#End If
		End Sub
	End Class
End Namespace
