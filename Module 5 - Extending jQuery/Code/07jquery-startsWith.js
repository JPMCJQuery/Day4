(function ($) {
 
    $.expr.filters.startsWith = function (element, index, details, collection) {
        //console.log(arguments);
	return $(element).text().indexOf(details[3]) == 0;
    };
}(jQuery));