---
title: Homework 4
layout: default
---
## Homework 4
The fourth assignment asked us to use ASP.NET MVC 5 to create a multi-page MVC web application (not using a database)
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW4.html).

## Creating an MVC Project
To start I created an MVC project and created a new feature branch. I started by setting up a Home page with a ul list linking to all other pages. Later I also implemented the nav bar. To create the list I used @Html.ActionLink helper methods.
```bash
<ul>
    <li> @Html.ActionLink("Home", "Index", "Home") </li>
    <li> @Html.ActionLink("Page 1", "Page1", "Home") </li>
    <li> @Html.ActionLink("Page 2", "Page2", "Home") </li>
    <li> @Html.ActionLink("Page 3", "Page3", "Home") </li>
</ul>
```

## Page 1
For page 1 I created a dollar to euro converter.
The form takes in a number and the user can choose to convert that into either dollars or euros.

```bash
@{
    ViewBag.Title = "Page 1";
}

<h2>Page1</h2>

<form method="get">
        <label for="amount">Amount</label>
        <br/>
        <input type="text" name="amount" value="" />
        <br/><br/>

        <label for="convert">Enter D to convert to dollars or E to convert to euros </label>
        <br/>
        <input type="text" name="convert" />

        <input type="submit" name="submit" value="Submit" />
</form>

<br/>
<br/>
    <p>@ViewBag.x</p>
```

I used GET to retrieve server-side content based on the values in the request,
and as instructed my controller action method used no parameters.
```bash
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
```
After this was completed I merged my feature branch back to master.

## Page 2
For Page 2 I made a simple temperature converter for Fahrenheit and Celsius.
```bash
@{
    ViewBag.Title = "Page2";
}

<h2>Page2</h2>

<form method="post">
    <label for="amount">Degree</label>
    <br />
    <input type="text" name="degree" value="" />
    <br /><br />

    <label for="convert">Enter F to convert to Fahrenheit or C to convert to Celsius </label>
    <br />
    <input type="text" name="convert" />

    <input type="submit" name="submit" value="Submit" />
</form>
<br />
<br />
<p>@ViewBag.x</p>
```
This form used POST to post the data from the form to the server. My GET method was parameterless and my POST used the FormCollection type parameter.
```bash
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
```
Once completed I merged back to master

## Page 3
For Page 3 I built a loan calculator where the user could input the loan amount, interest rate, and length of loan. After submission the form returned the monthly payments and total paid. The form uses POST.
```bash
@{
    ViewBag.Title = "Page3";
}

<h2>Fixed Term Loan Calculator</h2>
<body>
    <form method="post">
        <label for="Principle">Loan Amount</label>
        <br />
        <input type="number" min="1" name="Principle" value =""/>
        <br />
        <br />
        <label for="InterestRate">Interest Rate </label>
        <br />
        <input type="number"min="0" step="0.01" name="InterestRate" value =""/>
        <br/>
        <br/>
        <label for="LoanTerm">Term Length in Years </label>
        <br />
        <input type="number" min ="1" name="LoanTerm" value ="" />
        <br/>
        <br/>
        <input type="submit" name="submit" value="Submit" />
    </form>
        <br/>

    <Label>@ViewBag.stuff</Label>
</body>
```
As instructed I also used model binding in the controller action methods and made sure the user could not leave any elements in the form empty.
```bash
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
```
Since we are not yet using models the function used to calculate the monthly payments and total payment was placed in the controller

```bash
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
            output = "Monthly Payments = $" + mPay +"  Total payments = $" + tPay;
            //return output
            return output;
        }

    }
}
```
