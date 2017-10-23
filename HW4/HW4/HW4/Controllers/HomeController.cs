using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        // GET: Page1
        public ActionResult Page1()
        {
            double numAmmount = 0;
            string ammount = Request.QueryString["ammount"];
            string convert = Request.QueryString["convert"];

            if (ammount != null && ammount != "")
            {
                //convert to euros
                if (convert == "E" || convert == "e")
                {
                    //convert ammount to double
                    numAmmount = Convert.ToDouble(ammount);
                    //multiply ammount by .848551
                    double newAmmount = (numAmmount * .848551);
                    //convert newAmmount to string
                    string answere = newAmmount.ToString();

                    //return Content($"{ammount} dollars =  {answere} euros");
                    ViewBag.x = ($"{ammount} Dollars =  {answere} Euros");
                }

                //convert to dollars
                if (convert == "D" || convert == "d")
                {
                    //convert ammount to double
                    numAmmount = Convert.ToDouble(ammount);
                    //multiply ammount by 1.178367
                    double newAmmount = (numAmmount * 1.178367);
                    //convert newAmmount to string
                    string answere = newAmmount.ToString();

                   // return Content($"{ammount} euros =  {answere} dollars");
                    ViewBag.x = ($"{ammount} Euros =  {answere} Dollars");
                }

            }
            return View();
    
        }

        [HttpGet]
        public ActionResult Page2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page2(FormCollection form)
        {
            double numDegree;
            string degree = Request.Form["degree"];
            string convert = Request.Form["convert"];

            if (degree != null && degree != "")
            {
                //convert to Celsius
                if (convert == "C" || convert == "c")
                {
                    //convert ammount to double
                    numDegree = Convert.ToDouble(degree);
                    //subtract 32 and multiply by .5556 
                    double newDegree = ((numDegree - 32) * .5556);
                    //convert newDegree to string
                    string answere = newDegree.ToString();

                    //return Content($"{degree} Fahrenheit =  {answere} Celsius");
                    ViewBag.x = ($"{degree} Fahrenheit =  {answere} Celsius");
                }

                //convert to Fahrenheit
                if (convert == "F" || convert == "f")
                {
                    //convert ammount to double
                    numDegree = Convert.ToDouble(degree);
                    //multiply by 1.8 (or 9/5) and add 32.
                    double newDegree = ((numDegree * 1.8) + 32);
                    //convert newAmmount to string
                    string answere = newDegree.ToString();

                    // return Content($"{degree} Celsius =  {answere} Fahrenheit");
                    ViewBag.x = ($"{degree} Celsius =  {answere} Fahrenheit");
                }
            }
                return View();
        }

    }
}