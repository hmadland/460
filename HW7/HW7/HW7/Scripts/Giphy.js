//when search button is clicked run  getResults
$("#search").click(getResults); 

function getResults() {
    var userQuery = document.getElementById('userQuery').value.trim();

    if (userQuery !== "" || userQuery !== null) {
        //remove spaces replace with -
        var query = userQuery.replace(/ /g, "-");
        console.log(query);
        //remove past results before adding new ones
        $('#results').empty();

        $.ajax({
            url: "/Ajax/Giphy/",
            type: "POST",
            dataType: "json",
            data: { query },
            success: function (Giphy) {
                Giphy.data.forEach(function (gif) {
                    $('#results').append(`<div class="col-md-4"> <br/> <img src="${gif.images.fixed_height.url}"> </div>`);
                } 
                )
            }
        });
    }
}