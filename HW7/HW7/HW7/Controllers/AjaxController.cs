using System;
using System.IO;
using HW7.Models;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

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
