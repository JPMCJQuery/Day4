// Self-executing wrapper to avoid global namespace conflicts
// $ to assume we are in noConflict() mode
(function($) {

	// $.fn is namepace for jQuery Object properties and methods
	$.fn.helloWorld = function() {

		// Breakpoint next line of code and check out "this"
		// "this" is already a jQuery object, so no need for $(this)
		this.text("Hello World!");

	}

}(jQuery));	// passing in jQuery object to $ parameter for noConflict()