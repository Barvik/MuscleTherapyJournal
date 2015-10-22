var require = {
    paths: {
        "bootstrap": "/Scripts/bootstrap.min",
        "respond": "/Scripts/respond.js",
		"jquery": "/Scripts/jquery-2.1.4",
		"jquery-validate-unobtrusive": "Scripts/jquery.validate.unobtrusive",
		"jquery-validate": "Scripts/jquery.validate",
		"jqueryui": "Scripts/jquery-ui-1.11.4"
	},
	shim: {
		"bootstrap": {
		     deps: ["jquery"]
		},
		"jquery-validate": {
			deps: ['jquery'],
			exports: "$jQval"
		},
		"jquery-validate-unobtrusive": ["jquery-validate"],

	}
};

define('modernizr', [], Modernizr);
//"~/Scripts/Datepicker/DatePickerReady.js",
//		  "~/Scripts/jquery.ui.datepicker.min.js",
//		  "~/Scripts/jquery.ui.core.min.js"));

//@Scripts.Render("~/bundles/jquery")
//    @Scripts.Render("~/bundles/jqueryui")
//    @Scripts.Render("~/bundles/jqueryval")
//    @Scripts.Render("~/bundles/unobtrusive")
//    @Scripts.Render("~/bundles/bootstrap")
//    @Scripts.Render("~/bundles/datepicker")

//bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
//                        "~/Scripts/jquery-{version}.js"));

//bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
//			"~/Scripts/jquery-ui-{version}.js"));

////bundles.Add(new ScriptBundle("~/bundles/requirejs").Include(
////            "~/scripts/require.js"));

//bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
//			"~/Scripts/jquery.validate.js"));

//bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
//		   "~/Scripts/jquery.validate.unobtrusive.js"));


//// Use the development version of Modernizr to develop with and learn from. Then, when you're
//// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
//bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
//			"~/Scripts/modernizr-*"));

//bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
//		  "~/Scripts/bootstrap.js",
//		  "~/Scripts/respond.js"));

//bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
//		  "~/Scripts/Datepicker/DatePickerReady.js",
//		  "~/Scripts/jquery.ui.datepicker.min.js",
//		  "~/Scripts/jquery.ui.core.min.js"));