﻿using System.Web.Optimization;

namespace ArchaeoAnalysisHub
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jqcloud.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/jqcloud.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/js-site-analyses").Include(
                      "~/Scripts/site/modal-img.js",
                      "~/Scripts/site/world-cloud.js",
                      "~/Scripts/site/plotting.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-site-ternary-plot").Include(
                      "~/Scripts/site/ternary-plot.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-site-analysis-form").Include(
                     "~/Scripts/site/modal-img.js"));
        }
    }
}
