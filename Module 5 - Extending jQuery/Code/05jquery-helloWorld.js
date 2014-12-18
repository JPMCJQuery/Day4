(function($) {

	$.fn.helloWorld = function(options, complete) {

		var settings = $.extend({
            		message: "Hello, World!",
            		color: 	 "green"
        	}, options);
		this.text(settings.message).css("color", settings.color);

		if ($.isFunction(complete)) complete.call(this);
		
		return this;
    		
	}

}(jQuery));	