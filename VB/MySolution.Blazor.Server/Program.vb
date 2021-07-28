Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Threading.Tasks
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Blazor.DesignTime
Imports DevExpress.ExpressApp.Blazor.Services
Imports DevExpress.ExpressApp.Design
Imports Microsoft.AspNetCore
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting

Namespace MySolution.Blazor.Server
	Public Class Program
		Implements IDesignTimeApplicationFactory

		Private Shared Function ContainsArgument(ByVal args() As String, ByVal argument As String) As Boolean
			Return args.Any(Function(arg) arg.TrimStart("/"c).TrimStart("-"c).ToLower() = argument.ToLower())
		End Function
		Public Shared Function Main(ByVal args() As String) As Integer
			If ContainsArgument(args, "help") OrElse ContainsArgument(args, "h") Then
				Console.WriteLine("Updates the database when its version does not match the application's version.")
				Console.WriteLine()
				Console.WriteLine($"    {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.exe --updateDatabase [--forceUpdate --silent]")
				Console.WriteLine()
				Console.WriteLine("--forceUpdate - Marks that the database must be updated whether its version matches the application's version or not.")
				Console.WriteLine("--silent - Marks that database update proceeds automatically and does not require any interaction with the user.")
				Console.WriteLine()
				Console.WriteLine($"Exit codes: 0 - {DBUpdater.StatusUpdateCompleted}")
				Console.WriteLine($"            1 - {DBUpdater.StatusUpdateError}")
				Console.WriteLine($"            2 - {DBUpdater.StatusUpdateNotNeeded}")
			Else
				DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.Latest
				Dim host As IHost = CreateHostBuilder(args).Build()
				If ContainsArgument(args, "updateDatabase") Then
					Using serviceScope = host.Services.CreateScope()
						Return serviceScope.ServiceProvider.GetRequiredService(Of IDBUpdater)().Update(ContainsArgument(args, "forceUpdate"), ContainsArgument(args, "silent"))
					End Using
				Else
					host.Run()
				End If
			End If
			Return 0
		End Function
		Public Shared Function CreateHostBuilder(ByVal args() As String) As IHostBuilder
			Return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(Sub(webBuilder)
			webBuilder.UseStartup(Of Startup)()
			End Sub)
		End Function
		Private Function IDesignTimeApplicationFactory_Create() As XafApplication Implements IDesignTimeApplicationFactory.Create
			Dim hostBuilder As IHostBuilder = CreateHostBuilder(Array.Empty(Of String)())
			Return DesignTimeApplicationFactoryHelper.Create(hostBuilder)
		End Function
	End Class
End Namespace
