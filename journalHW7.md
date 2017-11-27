---
title: Homework 7
layout: default
---
## Homework 7
This assignment asked us to create a web page that used Javascript and asynchronous calls to a web server to create a responsive single page application. The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW7.html).

## Step One:
The first step was creating a simple view with a form for user input.

Index page
![](img/HW7Index.PNG?raw=true)

Index Page Code
```bash

@{
    ViewBag.Title = "Index";
}
    <center><h1>Search Gifs</h1></center>

    <div id="main_container">
        <!-- Div to contian Inputs Form -->
        <div class="row text-center">
            <div class="col-md-12">
                <form method="post">
                    <!--user input-->
                    <input class="form-control, text-center" id="userQuery" name="userQuery" type="text" />
                    <!-- Submit Button-->
                    <input class="btn btn-danger" type="button" id="search" name="search" value="Search" />
                </form>
            </div>
        </div>
        <!-- Div to contain outputs of images -->
        <div class="row text-center" id="results"></div>
        </div>


@section scripts
{
    <script type="text/javascript" src="~/Scripts/Giphy.js"></script>
}

```
## Second Step
The next step was registering as a developer at Giphy and getting my API key. After that I had to save the key outside my directory and link to it in my Web.config.
After that I created a new Ajaxcontroller

```bash
namespace HW7.Controllers
{
    public class AjaxController : Controller
    {
        private GiphyDBContext db = new GiphyDBContext();

        public ActionResult Giphy(string query)
        {
            // get apikey outside the repo
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyAPIKey"];
            //how many gifs are displayed
            int limit = 9;

            // build URL
            var URL = "http://api.giphy.com/v1/gifs/search?q=" + query + "&api_key=" + key + "&limit=" + limit;

            // WebRequest
            WebRequest request = WebRequest.Create(URL);

            // WebRequest
            WebResponse response = request.GetResponse();

            // build stream
            Stream dataStream = response.GetResponseStream();
            //get stream response
            StreamReader reader = new StreamReader(response.GetResponseStream());

            // Read response to end  
            string responseFromServer = reader.ReadToEnd();

            // close streams and response
            reader.Close();
            response.Close();

            // Create json object
            JObject giphyObject = JObject.Parse(responseFromServer);

            // Create a serializer to deserialize the string response (string in JSON format)
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // Store JSON results in results to be passed back to client (javascript)
            var giphyResults = serializer.DeserializeObject(responseFromServer);

            // make query to put in db
            string userAgent = Request.UserAgent;
            DateTime time = DateTime.Now;
            string queryIP = Request.UserHostAddress;
            var entry = db.GiphyLogs.Create();

            //get user data to add to db entry
            entry.queryTime = time;
            entry.queryClientAgent = userAgent;
            entry.giphyQuery = query;

           //add and save new entry to the db
            db.GiphyLogs.Add(entry);
            db.SaveChanges();

           // return json object
            return Json(giphyResults, JsonRequestBehavior.AllowGet);
        }
    }
}

```
and set up my custom route.
```bash
routes.MapRoute(
                name: "Search",
                url: "Ajax/Giphy",
                defaults: new { controller = "Ajax", action = "Giphy", id = UrlParameter.Optional }
            );
```

## Step three
I then made my Giphy.js file and saved it in my Scripts folder.

```bash
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
```
I went through several iterations before I got everything connected and working properly so that the gifs were retrieved from Giphy.
## Step Four
For the last step I added a database so that user queries could be logged.
```bash
--up
CREATE TABLE dbo.GiphyLogs
(
	giphyID			INT IDENTITY (1,1)	NOT NULL,
	queryTime			DATETIME	NOT NULL,
	queryClientAgent	VARCHAR(128),
	giphyQuery		VARCHAR(128),
	CONSTRAINT [PK_dbo.GiphyLogs] PRIMARY KEY CLUSTERED (giphyID ASC)
);

--down
DROP TABLE dbo.GiphyLogs;
```
Below are some example results after a search was performed
![](img/HW7SearchDogs.PNG?raw=true)

![](img/HW7SearchCats.PNG?raw=true)

![](img/HW7SearchFerret.PNG?raw=true)
