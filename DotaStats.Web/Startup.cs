using System;
using System.IO;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Owin;

[assembly: OwinStartup(typeof(DotaStats.Web.Startup))]
namespace DotaStats.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Serve Static Files from wwwroot directory w/ Owin
            //https://stackoverflow.com/questions/36294188/using-a-wwwroot-folder-asp-net-5-style-in-asp-net-4-5-project
            var root = AppDomain.CurrentDomain.BaseDirectory;
            var physicalFileSystem = new PhysicalFileSystem(Path.Combine(root, "wwwroot"));
            var options = new FileServerOptions
            {
                RequestPath = PathString.Empty,
                EnableDefaultFiles = true,
                FileSystem = physicalFileSystem
            };

            // Allows OWIN middleware to serve JSON config files 
            // https://stackoverflow.com/questions/28457090/how-to-serve-woff2-files-from-owin-fileserver
            ((FileExtensionContentTypeProvider)options.StaticFileOptions.ContentTypeProvider)
                .Mappings.Add(".json", "application/json");

            options.StaticFileOptions.FileSystem = physicalFileSystem;
            options.StaticFileOptions.ServeUnknownFileTypes = false;
            app.UseFileServer(options);
        }
    }
}
