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
            double numAmount = 0;
            string amount = Request.QueryString["amount"];
            string convert = Request.QueryString["convert"];

            if (amount != null && amount != "")
            {
                //convert to euros
                if (convert == "E" || convert == "e")
                {
                    //convert amount to double
                    numAmount = Convert.ToDouble(amount);
                    //multiply amount by .848551
                    double newAmount = (numAmount * .848551);
                    //convert newAmount to string
                    string answere = newAmount.ToString();

                    //return Content($"{amount} dollars =  {answere} euros");
                    ViewBag.x = ($"{amount} Dollars =  {answere} Euros");
                }

                //convert to dollars
                if (convert == "D" || convert == "d")
                {
                    //convert amount to double
                    numAmount = Convert.ToDouble(amount);
                    //multiply amount by 1.178367
                    double newAmount = (numAmount * 1.178367);
                    //convert newAmount to string
                    string answere = newAmount.ToString();

                   // return Content($"{amount} euros =  {answere} dollars");
                    ViewBag.x = ($"{amount} Euros =  {answere} Dollars");
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
                    //convert amount to double
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
                    //convert amount to double
                    numDegree = Convert.ToDouble(degree);
                    //multiply by 1.8 (or 9/5) and add 32.
                    double newDegree = ((numDegree * 1.8) + 32);
                    //convert newAmount to string
                    string answere = newDegree.ToString();
                    // return Content($"{degree} Celsius =  {answere} Fahrenheit");
                    ViewBag.x = ($"{degree} Celsius =  {answere} Fahrenheit");
                }
            }
                return View();
        }

        [HttpGet]
        public ActionResult Page3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Page3(double? Principle, double? InterestRate,  double? LoanTerm)
        {
            string answer = monthlyPay(Principle, InterestRate, LoanTerm);
            ViewBag.stuff = answer;
            return View(); 
        }


        //function
          string  monthlyPay(double? amount, double? rate, double? numTerms)
        {
            //variables
            double? mPay =0;
            double? tPay =0;
            string output;

            //check if form is blank
            if ((amount == null) || (rate == null) || (numTerms == null))
            {
                output = "Please enter a value in all fields";
                return output;
            }

            ///math
            double? interest = (rate/100) / (12);
            double i = Convert.ToDouble(interest);
            //number of payments = years * 12
            double n = Convert.ToDouble(numTerms * 12);

            double discount = (Math.Pow((1 + i), n) - 1) / (i * Math.Pow((1 + i), n));
            Debug.WriteLine(discount);

            //change to double so we can round
            double a = Convert.ToDouble(amount);

            //
            double amountx = Math.Round((a / discount), 2);
            mPay = Math.Round((a / discount), 2);
          //number of payments * amount payed per payment
            tPay = Math.Round((n * amountx),2);
           
            //set output
            output = "Monthly Payments = $" + mPay +"  Total paid = $" + tPay;
            //return output
            return output;
        }

    }
}