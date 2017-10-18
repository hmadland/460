---
title: Homework 3
layout: default
---
## Homework 3
The third assignment tasked us with translating a postfix calculator written in Java into one written in C#.
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW3.html).

## New Branch
The first step was making a new folder for HW3 and then creating a new branch named featureHW3 by using the following commands
```bash
        git checkout -b featureHW3
```

## translating
They main purpose of the assignment was to get familiar with C# as well as Visual Studio and having to translate everything from Java into C# certainly accomplished this. Unfortunately, being a transfer student I don't have much experience working with Java, but luckily C# has some similarity to C++.
Before starting I reread the slides, and watched a few videos on working with C# in Visual Studio. After that it was the slow process of having two windows open and going line by line through the Java code and translating it to C#.


Below is the console output of the C# postfix calculator.
![](img/HW3.PNG?raw=true)

Output for unaccepted input
![](img/HW3_improper.PNG?raw=true)

Once things were working I merged back to master with
```bash
  git checkout master
  git merge featureHW3
  git push origin master
```

All code can be found [here](https://github.com/hmadland/460).

## Issues
After merging I realized my .gitignore file was not working properly. After messing with it for a bit I eventually just copied my calculator code and deleted the files so I could start over with a .gitignore created through Visual Studio. Unfortunately I did forget to switch back to my featureHW3 branch for this, but since the code was already working there wasn't much risk.
