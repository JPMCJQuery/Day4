@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<div id="Events"></div>

@section scripts
    <script>
        $.ajax({
            url: "http://localhost:35007/api/Events",
            type: "Get",
            dataType: "json",
            success: function(data, textStatus, xhr) {
                console.log(data);
            },
            error: function (data, textStatus, xhr) {
                console.log("Error in Ajax");
            }
        });

        // or

        $.getJSON("http://localhost:35007/api/Events",
            function (data) { console.log(data); });


        $.getJSON("http://localhost:35007/api/Events",
            function (data) {
                var items = [];
                $.each(data,
                    function (key, val) {
                        items.push("<li id='" + key + "'>" + val["Title"] + "</li>");
                    });
                $("<ul/>", {
                    "class": "Events",
                    html: items.join("")
                }).appendTo("#Events");
            });
    </script>
End Section