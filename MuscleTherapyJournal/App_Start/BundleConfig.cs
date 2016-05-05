using System.Web;
using System.Web.Optimization;

namespace MuscleTherapyJournal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/requirejs").Include(
            //            "~/scripts/require.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                       "~/Scripts/jquery.validate.unobtrusive.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                      "~/Scripts/Datepicker/DatePickerReady.js",
                      "~/Scripts/jquery.ui.datepicker.min.js",
                      "~/Scripts/jquery.ui.core.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                  "~/Content/themes/base/core.css",
                  "~/Content/themes/base/resizable.css",
                  "~/Content/themes/base/datepicker.css",
                  "~/Content/themes/base/selectable.css",
                  "~/Content/themes/base/accordion.css",
                  "~/Content/themes/base/autocomplete.css",
                  "~/Content/themes/base/button.css",
                  "~/Content/themes/base/dialog.css",
                  "~/Content/themes/base/slider.css",
                  "~/Content/themes/base/tabs.css",
                  "~/Content/themes/base/progressbar.css",
                  "~/Content/themes/base/theme.css")); 


            bundles.Add(new StyleBundle("~/Content/appcss").Include(
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/pages.css"));

            bundles.Add(new StyleBundle("~/Content/treatmentcss").Include(
                      "~/Content/treatment.css"));

        }
    }
}
