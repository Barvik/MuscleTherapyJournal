/*****************
*
* This cfg extends the MDX one
* 
*****************/

requirejs.config({
    baseUrl: "/",
    paths: {
        "moment": "Scripts/moment-with-langs",
        "jquery-validate-unobtrusive": "Scripts/jquery.validate.unobtrusive",
        "jquery-validate": "Scripts/jquery.validate",
        "jquery-validate-custom-methods": "Scripts/cfg/jquery.validate.custom-methods",
        "jquery-placeholder": "Scripts/jquery.placeholder",
        "jquery-format": "Scripts/jquery.format-1.3.min",
        "form-helper": "Scripts/Helpers/form-helper",
       
    },
    shim: {
        "jquery-placeholder": ["jquery"],
        "jquery-format": ["jquery"],
        modernizr: {
            exports: "Modernizr"
        },
        "jquery-validate": {
            deps: ['jquery'],
            exports: "$jQval"
        },
        "jquery-validate-unobtrusive": ["jquery-validate"],
        "bootstrap-datepicker": ["jquery"],
        "bootstrap-datepicker-nb": ["bootstrap-datepicker"],
        "angular-locale": ["angular"],
        'angular': {
            exports: 'angular'
        },
        "crud-grid-directive": ["angular", "angular-locale"],
        'ngResource': ["angular", "angular-locale"],
        'ngAnimate': ["angular", "angular-locale"]

    },
    deps: ['angularBootstrapper']
});


define('modernizr', [], Modernizr);
