Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports DevExpress.ExpressApp.Blazor.Services
Imports DevExpress.Persistent.Base
Imports Microsoft.AspNetCore.Authentication.Cookies
Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Components.Server.Circuits
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.AspNetCore.Http
Imports Microsoft.Extensions.Configuration
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Hosting
Imports MySolution.Blazor.Server.Services

Namespace MySolution.Blazor.Server
	Public Class Startup
		Public Sub New(ByVal configuration As IConfiguration)
			Me.Configuration = configuration
		End Sub

		Public ReadOnly Property Configuration() As IConfiguration

		' This method gets called by the runtime. Use this method to add services to the container.
		' For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		Public Sub ConfigureServices(ByVal services As IServiceCollection)
			services.AddRazorPages()
			services.AddServerSideBlazor()
			services.AddHttpContextAccessor()
			services.AddSingleton(Of XpoDataStoreProviderAccessor)()
			services.AddScoped(Of CircuitHandler, CircuitHandlerProxy)()
			services.AddXaf(Of MySolutionBlazorApplication)(Configuration)
		End Sub

		' This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IWebHostEnvironment)
			If env.IsDevelopment() Then
				app.UseDeveloperExceptionPage()
			Else
				app.UseExceptionHandler("/Error")
				' The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts()
			End If
			app.UseHttpsRedirection()
			app.UseRequestLocalization()
			app.UseStaticFiles()
			app.UseRouting()
			app.UseAuthentication()
			app.UseXaf()
			app.UseEndpoints(Sub(endpoints)
				endpoints.MapBlazorHub()
				endpoints.MapFallbackToPage("/_Host")
			End Sub)
		End Sub
	End Class
End Namespace
