(function($) {

	$.fn.helloWorld = function(options) {

		var settings = $.extend({
            		message: "Hello, World!",
            		color: 	 "green"
        	}, options);
		return this.text(settings.message).css("color", settings.color);

	}

}(jQuery));	