# dndworlddata
Coding Project for the 6th Semester Creative Coding Course

What i wanted to do: 

## First things first 
I started out by doing a small SQL tutorial, as I didn't remember any of it anymore. This is the tutorial I completed:
https://sql-island.informatik.uni-kl.de/#
here you can make sure of the completion by looking at my certificate (yes I am very proud of it and printed it out to frame it on my wall):
https://github.com/abhededam/dndworlddata/blob/master/certificates/Certificate_SQL-Island.pdf

 ### ERM
 Quickly when learning more about SQLite and refreshing my knowledge about databases, I came to the conclusion, that I should probably make a Entity-Relationship-Model. So I researched that and designed one of those. For bette readability I made the tables in excel so and made the ERM without the attributes, as all my Entitys have relationship with every other Entity. 
 
 ### deciding on how to break it down
 as the whole project of creating a interactive map/database for a fully fleshed/or soon to be fleshed out D&D Fantasy world, there are quite a lot Entitys to differentiate. Way to many for a small-ish Studentproject that I aim to complete within a full workweek. _SO_ i had to break it down to very basic entitys. When i came down to it i had four different kind of map objects: 

* Continents: to differentiate between water and land
* Zones: those can be different things, like countrys, forests, a mountain range, several citys and villages that are under an allyship or can be discribed as a region. Zones can be overlapping
* Routes: those are all the ways, streets and well routes people and peoplelike species take for trading, travel or similar. so it could as well describe the mainpart of a river
* Points of Interest(POI): those can be of very different kinds as well most commonly describes citys, villages, dungeons. so it could be said that those are all the important points one might put on a map

### making the database 
for creating all my needed tables with their attributes i used DB Browser for SQLite (https://sqlitebrowser.org/). Fortunatly for me, one of my flatmates has an exam about object oriented databases coming up, so they could answer my question as how to describe n:m relationships in databases.... you just create a new table for that. WOW sometimes solutions can be this easy and obvious. so i created tables for all the relationship except for one, the relationship between continents and pois is the only 1:n. 

i added some more test data to my database so i could test if the relationship tables work. they do obviously.

try: 

    SELECT continent.name FROM continent, zone, rconzon
    WHERE zone.id = rconzon.zone
    AND continent.id = rconzon.continent
    AND zone.id = 2;
    
## How to:
Only works in the test play mode in Unity, not as a .exe, so the project needs to be opened in UnityEngine.

1. hold p and click left mousekey to set new poi
2. type in name and choose type
3. click on Add POI
4. wait until Popup disappears
5. click on r to refresh
6. VOILA new poi visible
 
