---
title: Homework 1
layout: default
---
## Homework 1
The first homework assignment tasked us with learning the basics of HTML, CSS, Bootstrap, and Git.
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html).
Essentially we have been asked to build a set of web pages and this portfolio to show future assignments.

## Git
The first step was downloading Git, and making accounts on both GitHub and BitBucket. Once that was done I created a repo on GitHub
    and cloned a copy to my machine.

## HTML, CSS, Bootstrap
From there it was simply a matter of puting together the html files for the set of web pages and making sure they
matched the assignment's specifications. Once they were done I push them to the remote repo.
I also used w3schools to help when I ran into any problems with HTML, css and bootstrap and ran through a few git tutorials.

## Issues
The only major problem I ran into was when I unnecessarily made a branch and had to merge it back with the master. It had a
merge conflict and I had to manually pick between two files

## Finishing Up
Once the pages for homework 1 were complete I began working on the pages for this portfolio. Once everything
was pushed to the remote repo all that was left was making sure everything linked correctly.
You can view the completed site created for HW1 [here](HW1/index.html).
Below are some code examples from HW1.


### Multi column layout and navbar
```bash
<!DOCTYPE html>
<html>
  <head>

    <title>Marvel</title>
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/style.css">

    <nav class="navbar navbar-inverse">
  <div class="container-fluid">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
  <div class="collapse navbar-collapse" id="myNavbar">
    <ul class="nav navbar-nav">
      <li class="active"><a href="#">Home</a></li>
      <li><a href="phoenix.html">Phoenix</a></li>
      <li><a href="wolverine.html">Wolverine</a></li>
      <li><a href="shadowcat.html">Shadowcat</a></li>
      <li><a href="cyclops.html">Cyclops</a></li>
      <li><a href="storm.html">Storm</a></li>
      <li><a href="nightcrawler.html">Nightcrawler</a></li>
      <li><a href="enemies.html">Enemies</a></li>
   </ul>
 </div>
</div>
</nav>

</head>

  <body>
    <div id="BoldW" class="text-center">
      <h1>X-MEN</h1>
      <br>
    </div>

  <div class="container-fluid text-center">
  <div class="row">

    <div class="col-sm-4">
    <a href="phoenix.html">
      <img src="img/grey.jpg" height="240" alt="Image">
      <p id=BoldW>Phoenix</p>
      </a>
    </div>

    <div class="col-sm-4">
      <a href="wolverine.html">
      <img src="img/wolverine.jpg" height="240" alt="Image">
        <p id=BoldW >Wolverine</p>
      </a>
    </div>

    <div class="col-sm-4">
      <a href="shadowcat.html">
      <img src="img/shadowcat.jpg" height="240" alt="Image">
        <p id=BoldW >Shadowcat</p>
      </a>
    </div>
  </div>
  </div>

<!--newrow-->
 <div class="container-fluid text-center"><br>
  <div class="row">

    <div class="col-sm-4">
      <a href="cyclops.html">
      <img src="img/cyclops.jpg" height="240" alt="haskell">
        <p id=BoldW >Cyclops</p>
      </a>
    </div>
    <div class="col-sm-4">
      <a href="storm.html">
      <img src="img/storm.jpg" height="240" alt="haskell">
        <p id=BoldW >Storm</p>
      </a>
    </div>
    <div class="col-sm-4">
      <a href="nightcrawler.html">
      <img src="img/nightcrawler.jpg" height="240" alt="haskell">
        <p id=BoldW >NightCrawler</p>
      </a>
    </div>
</div>
</div><br>

  <footer class="container-fluid text-center">
  </footer>

  </body>
</div>
</html>
```

### Table
```bash
    <!DOCTYPE html>
      <html>
          <head>
             <title>Marvel</title>  <link rel="stylesheet" href="css/bootstrap.css">
             <link rel="stylesheet" href="css/style.css">

           <nav class="navbar navbar-inverse">
           <div class="container-fluid">
               <div class="navbar-header">
                 <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                 </button>
               </div>
           <div class="collapse navbar-collapse" id="myNavbar">
           <ul class="nav navbar-nav">
             <li class="active"><a href="#">Enemies</a></li>
             <li><a href="index.html">Home</a></li>
             <li><a href="phoenix.html">Phoenix</a></li>
             <li><a href="wolverine.html">Wolverine</a></li>
             <li><a href="shadowcat.html">Shadowcat</a></li>
             <li><a href="cyclops.html">Cyclops</a></li>
             <li><a href="storm.html">Storm</a></li>
             <li><a href="nightcrawler.html">Nightcrawler</a></li>
           </ul>
           </div>
           </div>
           </nav>

           </head>

           <body>

             <div id=BoldW class="container">
             <h2>Enemies</h2>
             <table id=BoldW class="table">
               <thead>
                 <tr>
                   <th>Code Name</th>
                   <th>Real name</th>
                   <th>Powers</th>
                 </tr>
               </thead>
               <tbody>
                 <tr>
                   <td>The Black King</td>
                   <td>Sebastian Shaw</td>
                   <td>Absorbs energy and transform it into raw strength</td>
                 </tr>
                 <tr>
                   <td>Apocalypse</td>
                   <td>En Sabah Nur</td>
                   <td>Pretty much every thing</td>
                 </tr>
                 <tr>
                   <td>Juggernaut</td>
                   <td>Cain Marko</td>
                   <td>Superhuman Strength</td>
                 </tr>
                 <tr>
                   <td>Magneto</td>
                   <td>Erik Magnus Lehnsherr</td>
                   <td>Control magnetic fields</td>
                 </tr>
               </tbody>
             </table>
           </div>

           </body>
           </html>
```

### ul list
```bash
             <!DOCTYPE html>
             <html>
               <head>

                 <title>Wolverine</title>
                 <link rel="stylesheet" href="css/bootstrap.css">
                 <link rel="stylesheet" href="css/style.css">

                 <nav class="navbar navbar-inverse">
                   <div class="container-fluid">
                     <div class="navbar-header">
                       <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                         <span class="icon-bar"></span>
                         <span class="icon-bar"></span>
                         <span class="icon-bar"></span>
                       </button>
                     </div>
               <div class="collapse navbar-collapse" id="myNavbar">
                 <ul class="nav navbar-nav">
                   <li class="active"><a href="#">Wolverine</a></li>
               <li><a href="index.html">Home</a></li>
               <li><a href="wPowers.html">Powers</a></li>
               <li><a href="wRandom.html">Family</a></li>
               </ul>
              </div>
             </div>
             </nav>

               </head>
               <body>


                 <div class="container-fluid bg text-center">
                 <h1 class="margin">Wolverine</h1><br>
                 <div class="row">
                     <img src="img/wolverine.jpg" height="250" alt="Image">
                   </div>
                 </div>


                 <div id="BoldW" >
                   <h2>Wolverine</h2>
                   <p id="padL">Wolverine was a founding member of the second incarnation of The X-Men.
                   He has been a member of multiple other teams including:</p>
                   <ul>
                     <li>The X-Men</li>
                     <li>Alpha Flight</li>
                     <li>X-Force</li>
                     <li>Avengers</li>
                     <li>Weapon X</li>
                   </ul>
                 </div>

               </body>
               </html>
```


### ol list
```bash
       <!DOCTYPE html>
       <html>
         <head>
           <title>Phoenix</title>
           <link rel="stylesheet" href="css/bootstrap.css">
           <link rel="stylesheet" href="css/style.css">

           <nav class="navbar navbar-inverse">
             <div class="container-fluid">
               <div class="navbar-header">
                 <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                   <span class="icon-bar"></span>
                 </button>
               </div>
         <div class="collapse navbar-collapse" id="myNavbar">
           <ul class="nav navbar-nav">
             <li class="active"><a href="#">Powers</a></li>
         <li><a href="index.html">Home</a></li>
         <li><a href="wolverine.html">Wolverine</a></li>
         <li><a href="wRandom.html">Family</a></li>

         </ul>
        </div>
       </div>
       </nav>
         </head>
         <body>

           <div id="BoldW">
             <h2>Powers</h2>
           <ol>
             <li>Healing Factor</li>
             <li>Adamantium Covered Bone Claws </li>
             <li>Enhanced Senses</li>
           </ol>
           </div>
           <div class="container-fluid bg">
             <h1 class="margin">Wolverine</h1>
               <div class="row" id="padL">
                 <img src="img/wolverine.jpg" height="250" alt="Image">
               </div>
           </div>

         </body>
         </html>
```

### dl list
```bash
                 <!DOCTYPE html>
                 <html>
                   <head>

                     <title>Phoenix</title>
                     <link rel="stylesheet" href="css/bootstrap.css">
                     <link rel="stylesheet" href="css/style.css">

                     <nav class="navbar navbar-inverse">
                       <div class="container-fluid">
                         <div class="navbar-header">
                           <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                             <span class="icon-bar"></span>
                             <span class="icon-bar"></span>
                             <span class="icon-bar"></span>
                           </button>
                         </div>
                   <div class="collapse navbar-collapse" id="myNavbar">
                     <ul class="nav navbar-nav">
                       <li class="active"><a href="#">Family</a></li>
                   <li><a href="index.html">Home</a></li>
                   <li><a href="wolverine.html">Wolverine</a></li>
                     <li><a href="wPowers.html">Powers</a></li>
                   </ul>
                  </div>
                 </div>
                 </nav>
                   </head>
                   <body>

                     <div id="BoldW">
                       <dl id="padL">
                         <dt>Mother</dt>
                         <dd>Elizabeth Howlett</dd>
                         <dt>Father</dt>
                         <dd>Thomas Logan</dd>
                       </dl>
                     </div>

                     <div class="container-fluid bg">
                       <h1 class="margin">Phoenix</h1>
                         <div class="row" id="padL">
                           <img src="img/wolverine.jpg" height="250" alt="Image">
                         </div>
                     </div>

                   </body>
                   </html>

```



```bash
```
