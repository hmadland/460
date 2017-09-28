title: Homework 1
layout: default
---
## Homework 1

The first homework assignment tasked us with learning the basics of HTML, CSS, Bootstrap, and Git.
The assignment instructions can be found [here] (http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html).
Essentially we have been asked to build a set of web pages and this portfolio to show future assignments.
Let's get started ...

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
