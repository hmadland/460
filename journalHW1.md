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


```bash
```



```bash
```



### Step 1: Download Git, Learn a Basic Workflow, Create Accounts on GitHub and Bitbucket

I've downloaded `clone`ed software from GitHub before, and browsed through code there, but I've never had to learn Git.  I downloaded the offical Git software from [Git-scm](https://git-scm.com/).  After reading some tutorials and watching a couple YouTube videos on Git I'm ready to dive in.

I first created a repository on Bitbucket, then added a README through their web interface.  To get a local copy on my machine I had to clone it and then make sure everything is set up correctly.  The instructor wants us to do everything through the command line, so we fire up Git Bash (might try the bash shell in Ubuntu inside of the Windows Subsystem for Linux next time -- *I hear it's better*):

```bash
cd Documents/CS460
mkdir repos
cd repos
git clone https://morses@bitbucket.org/morses/myprojectname.git
cd myprojectname

git config --global user.name "Scot Morse"
git config --global user.email morses@wou.edu
git config --global --edit         # to check
```

Now to add some code and see if we can `push` up to the remote server:

```bash
echo "# README" >> README.md
git add README.md
git commit -m "Initial commit; create a project README"
git push -u origin master       # the -u flag adds upstream tracking reference -- will have to look this one up
```

Checking the repo webpage --> success!  Looks like I have a working repository and can add code &#9786;

### Step 2: HTML

![HTML5 Logo](HTML5.png)

I've used HTML before so this should be a cinch...


**You get the picture.  Put some real content in here.  Don't just copy and paste your code -- explain it.  Use a blog or post format, or a mini-tutorial or as this one did, a journal entry style.  Whatever you like.  Be creative.  At the very least it must show what you did and why.**
