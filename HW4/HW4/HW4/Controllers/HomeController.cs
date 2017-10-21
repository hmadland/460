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
    }
}