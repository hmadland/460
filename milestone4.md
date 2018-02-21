---
title: Milestone 4
layout: default
---
## Milestone 4
The assignment instructions can be found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/t2/M4.html).


All other documents can be found [here](https://bitbucket.org/blakebauer/etprogressus) in our groups bitbucket repo.

## One full iteration of class project
Our group groomed our backlog and assigned tasks to each member to add features and functionality to our XC team site.
I worked on adding drop downs to the athlete view allowing users to filter athletes by team, or DOB.

## Team project inception continues
We were instructed to spend some "quality time" working with our group to expand on our team project. Over the week we spent about five hours together brainstorming and came up with the following.

### Needs, Features and Requirements

### Needs:
API that will allow developers to create games based on eliminating other players and building player stats
Database to store players, player stats, and game information
Developers to create games to test
Web App to manage the game
Players to make accounts and manage them

### Features:
Player Creation:
* Profile Management
* Bio
* Photo
* Change Password
* Social Media Login
* View Skills
* Upgrade Skills with Coins
* View Performance Stats
* View Awards/Achievements/Badges
Elimination Validation
* Photo-recognition
* Bluetooth
Skills
* Weapon Proficiency
* Trap Proficiency
* Armor Proficiency
* Awareness
* Sneak (Maybe phone automatically makes noise when near other players if Sneak skill is low)
* Pick-Pocket
Tracking
* Used to calculate a players chance of successful attacks and traps (or escape from them), as well as informing the future game target algorithm.

Inventory
* Armor
* Weapons

Traps
* Bombs (target only or bystanders)
* Poison (disguised as items?)
* Bear Trap (steal skills?)

Items
* Antivenin
* Potions?
* Ammunition?

Wallet

Stats Basic
* Games Won
* Games Played
* Successful Eliminations
* Success/Failed Ratio
* Eliminations/Eliminated Ratio
* Failed Eliminations
* Times Eliminated
* Eliminated/Escaped Ratio
* Times Escaped

Stats Detailed
* Total Distance Travelled
* Average Distance Travelled per game
* Average Distance Travelled per elimination
* Total Time Alive
* Average Time alive per game
* Average Time between eliminations
* Average speed

In-Game Currency/Experience Points
* Earned from: Game Victory, Successful Elimination, Successful Escape, Achievements, Time Alive, Distance Travelled, Item-Drops, Successful Pick-pocket

In-Game Purchases
* Weapons, Traps, Items, Armor
* Upgrading skills

Lose In-Game Currency by
* pick-pocket
* bear-traps
* missed check-in

Awards/Achievements/Badges
* Number-based
* Games played
* Games won
* Players Eliminated
* Times Eliminated
* Near-misses
* Close-calls
* Time-based
* Distance-based

Player Settings
* Safe-times (Bunker-time) (To accommodate for things like class, meetings or work)
* Safe-Zones (set a home base radius by GPS)

Global Settings/Rules
* Game hosts establish (most) rules before game begins
* Safe-Times (bunker-time)
* Safe-Zones (GPS-based safe zones for all players)
* Total Game Duration: Beginning Time, Ending Time or Last-person-standing
* Game Region: GPS based zone for game, penalties for leaving zone after certain duration
* Elimination Rules: Allowed frequency of attempts, Penalties for near-misses: cool-down timer, forced check-in
* Awards for eliminations, close-calls: Coins, items, skill increases
* Function after being eliminated: Become host's enforcers
* Target acquisition style: Circle, Teams, Free-for-all
* Target Randomization: Frequency
* Item-Drop Rules: Manual or random location, frequency, accessibility duration, visible or mystery items, coins
* Location Check-in Rules: Accessibility duration, required or optional, penalty for missing

### Requirements:
Non-functional
Json needs to be used when passing data from server to client to decrease bandwidth constraints.
Game and player information should be stored safely using min amount of memory to conserve space and cost.


### Identification of Risks:
Photo-Recognition
It may be too difficult to implement or it may not be accurate enough to work. It also may be to slow and ruin the immersion.
A player could possibly cheat this system by taking a picture of a picture or resend a previously taken photo the resulted in a successful elimination.
GPS
A trap may be set in the bottom floor of a building but go off if someone passes by it on the second floor.
Legality
Some might call the kind of behaviors expressed while playing elimination-based live-action games "stalker-ish" or "creepy."
There may be misunderstandings that we could be held liable for...
Security
Bluetooth vulnerability

### Final Vision Statement:
For people who want to create and play elimination-based live-action mobile games (like Assassin! or Humans Vs. Zombies), the Elimination Framework and API is an web application (and associated mobile apps) that allows for an admin to make a game and set rules and invite other users to join the game. Elimination-based live action games involve players being assigned other players as targets and then proceeding to attempt to eliminate their target/targets, traditionally with mock-projectiles (like Nerf-guns or balled up socks), by whatever rules are established for the specific game, until either the last player/team is remaining. Unlike current methods for playing elimination-based live-action games, our full website will remove the subjectivity that comes from a human moderator and human players determining a successful elimination and also make adding more rules and features (like player skill modifiers, a player inventory, and methods of elimination) to games easier and more fun. The application will store user accounts, skills, and stats from previous and on-going games, as well as make decisions for furthering current games and setting up new ones.

## Initial DB Design
![](img/initial-database-design.png?raw=true)

## Architecture Diagram
![](img/architecture-diagram.png?raw=true)

## Use Case Diagram
![](img/overall-use-case.png?raw=true)

![](img/view-use-case-diagram.jpg?raw=true)
