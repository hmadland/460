---
title: Homework 9
layout: default
---
## Homework 9
For assignment 9 we were asked to publish our HW8 to the Cloud using Azure
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW9.html).

[Hannah's Azure site](http://hw9.azurewebsites.net/)

The first thing I did after setting up an account on Azure was set up the resource group.
To do this:
1. Go to Resource Groups
2. Add
3. Fill out form
4. Create

Next I created a db
To do this:
1. Go to SQL databases
2. Add
3. Fill out the form
 4. selecting resource group you created
 5. set pricing to basic
 6. Create
![](img/testing1.PNG?raw=true)
4. Once the db was up I clicked on it and set server firewall
![](img/testing2.PNG?raw=true)

After that I went to SQL Server Management Studio
1. Pasted the server name from the db in Azure
2. filled in user and password and connected
3. then I ran a new query and took my upSQL from HW8
![](img/testing3.PNG?raw=true)

Then I created a web app on Azure
1. Go to App Services
2. Add
3. Select Web App
4. Create
5. Fill out the form using
  6. existing resource group
  7. Create app service plan
  8. Create

Then I went back to visual studios and in my project to deploy
1. Click on project name hit publish
2. Select Exsisting
![](img/testing6.PNG?raw=true)
3. Next from the pop up select resource group and web app click OK
![](img/testing7.PNG?raw=true)
4. Then hit publish once more

After this I went back to Azure to connect the my db to my web app.
1. Click on SQL databases, select your db
2. Click connection strings
3. Copy connection String
4. Go to App Services click on your web app
5. Go to Application Settings
6. Scroll down to connection strings
7. In the Name type the context file that interacts with the db in your local project
8. In the Value past in the connection string and add in your user_name and password
9. Click save

Back in Visual Studio go to Web.Config
1. Past in the same connection string, but this one cannot have the brackets around the user-name and password
2. I republished to make sure everything was connected properly

Then you're done!
![](img/testing8.PNG?raw=true)
![](img/testing9.PNG?raw=true)
![](img/testing10.PNG?raw=true)

I am having some difficulty getting the genre buttons to work properly in Azure, but they do work locally
