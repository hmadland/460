
    $('#results').empty();
    $.ajax({
        type: "POST",
        url: "/Home/GetBids/",
        data: { id: gid }, //define id as gid to use in controller
        dataType: "json",
        success: function (data) {
            $.each(data, function (i, item) {
                $("#results").append("<li>" + "<strong>" + item["Artist"] + ": " + "</strong>" + item["Title"] + "</li>");
            });
        },
        error: Aerror
    })
};

function Aerror() {
    console.log("Error!");
}