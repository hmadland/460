---
title: Milestone 3
layout: default
---
## Milestone 3
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/t3/M3.html).
We were asked to go through backlog refinement and grooming for our class project, start using Visual Studio
Team Services (VSTS) for Scrum Agile processes, prove architecture and development workflow for class project, start team
project inception, and propose Individual Project ideas.


## Visual Studio Team Services (VSTS)
For this task we simply figured out how VSTS scrum board worked. We will not be using their built in version control for our assignments.
We broke Epics into Features, Features into PBIs, and PBIs into tasks.

## Backlog Refinement/Grooming:
Everyone in our group was assigned a task to finish during our mini sprint. We wound up separating some PBIs that under normal circumstances would not have been, but for the initial sprint our goal was mainly to figure out VSTS and practice the Scrum workflow.
```bash
1. Create Empty MVC project
2. Create data model and up script
3. Create Model Classes and Views
4. Set Up Continuous Deployment
```

## Prove architecture
In order to prove the architecture we had to have a hello world site up and continuously deployed on Azure.

## Team Project inception
We decided to go with the Assassins or elimination game application and API for our group project.

## Mindmap:
![](img/mindmap.png?raw=true)

## vision statement draft:

    For developers who want to create elimination-based live-action mobile games, the Elimination App and API is a server-side
	application that allows for an admin to make a game and set rules and invite other users to join the game. The
	application will store user accounts, skills and stats from previous and on-going games, as well as make decisions
	for furthering current games and setting up new ones. Unlike current methods for playing elimination-based live-action
	games, our product will remove the subjectivity that comes from a human moderator and human players determining a successful
	elimination and also make adding more rules to games easier and more fun.

## Needs & Features:

```bash
Needs:
    -Database to store players, player stats, and game information.
    -API that will allow developers to create games based on eliminating other players and building player stats.
    -Web App to manage the game and players to make accounts and manage them.

Features:
    -Create players to allow a user to manage their profile and level up their stats.
    -Skills that will be used to calculate a players chance of successful attacks and traps.
    -Items such as traps, range weapons, armor, anti-venom, theft
    -Bunker time to hide from enemies.
    -Management tools to determine if eliminations are valid like photo recognition, line of sight, bluetooth.

Requirements:
    Non-functional:
    -Need to use Json when passing data from server to client to decrease bandwith constraints.
    -Game and player information should be stored using minimal amount of memory to conserve space.

```    

## Individual Project Ideas
```bash
Idea		Platform: Native Android      Language: Java				                      
Companion app for group project Elimination 	  
API. The app allows users to access and manage
their account as well as play against other
users and receive new targets in elimination
games.  


Idea		Platform: Native Android      Language: Java
Book barcode scanner app.			        
The app allows you to scan a book’s
barcode and then gives you reviews
and possibly similar titles.
Possibly using Goodreads API.


Idea		Platform: Native Android      Language: Java
House plant identification app. 		 
The app uses image recognition to
identify plant species and return care
instructions.

```
