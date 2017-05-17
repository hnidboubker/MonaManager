using System.Web.Hosting;
using System.Web.Optimization;

namespace Mona.Web
{
    public class BundleConfig : Bundle
    {

        public BundleConfig(string virtualPath)
            :base(virtualPath)
        {
            
        }

        public new BundleConfig IncludeDirectory(string directoryVirtualPath, string searchPattern, bool searchSubdirectories)
        {
            var truePath = HostingEnvironment.MapPath(directoryVirtualPath);
            if (truePath == null) return this;

            var dir = new System.IO.DirectoryInfo(truePath);
            if (!dir.Exists || dir.GetFiles(searchPattern).Length < 1) return this;

            base.IncludeDirectory(directoryVirtualPath, searchPattern);
            return this;
        }

        public new BundleConfig IncludeDirectory(string directoryVirtualPath, string searchPattern)
        {
            return IncludeDirectory(directoryVirtualPath, searchPattern, false);
        }
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //    "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //    "~/Scripts/jquery.unobtrusive*",
            //    "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
            //    "~/Scripts/knockout-{version}.js",
            //    "~/Scripts/knockout.validation.js"));


            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //    "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //    "~/Scripts/bootstrap.js",
            //    "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/bootstrap.css"
            //    ));

            // Custom Part
            bundles.Add(new BundleConfig("~/bundles/plugging")
                .IncludeDirectory("~/Assets/pugging/mo", "modernizr-{version}.js")
                 .IncludeDirectory("~/Assets/pugging/jq/js", "jquery-{version}.js")
                .IncludeDirectory("~/Assets/pugging/bootjs","bootstrap.js")
                .IncludeDirectory("~/Assets/plugging/res","respond.js")
                .IncludeDirectory("~/Assets/plugging/sam","sammy-{version}.js")
                );
            //bundles.Add(new ScriptBundle("~/bundles/plugging")
            //    .Include(
            //    "~/Assets/pugging/mo/modernizr-{version}.js",
            //    "~/Assets/pugging/jq/js/jquery-{version}.js",
            //    "~/Assets/pugging/boot/js/bootstrap.js",
            //    "~/Assets/plugging/res/respond.js",
            //    "~/Assets/plugging/sam/sammy-{version}.js"

            //    ));



            bundles.Add(new StyleBundle("~/Assets/vendors")
                .IncludeDirectory( "~/Assets/plugging/boot/css","bootstrap.css"));
        }
    }
}