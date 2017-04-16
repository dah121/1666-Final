***Changes***

-Fixed all of the probelems in Zach's and my Changelog
-Rounds are Fully automated!!! Hitting "Next Wave" will send the next wave
	On wave completion, returns to Tower-Defense Mode
-Wave Spawner now works (I think). I added a function called "Set_Wave_Stats()" that can be called to change the numer of enemies and the delay between instantiations. We can use this to read from a text file and do rounds in that wave
Made it so all of the tiles use the same material, proper texture
-Changed "Gold" to "Stock Options"
-Added Rotating Text Animation
-When Enemies are Killed they now dump their task name into a List that we can use to generate the completed task list


***Would Like to Have***

-Some Sort of UI Bar with Lives, Rounds, Cash and maybe Level name on it 
	(just a small thing across the top or bottom? maybe could style it like an excel spreadsheet line like our title\
-Different towers (With different costs, effects, etc.)
-Sound Effect + Visual Effect (maybe a particle?) when Synergy Occurs
I have a script where I tried to make the directional beams light up on the minimap, but it didn't work (I tried a long time ago). I would like for that to work too so I'll take a look
-Upgrading and Selling (Promoting and firing) Towers
	I think I said I would do this, I just haven't gotten around to it yet. will soon
-A shop that allows you to select different towers
	instead of buying when you click a button, I was thinking the shop menu could just change which tower the tower_builder script is going to place next and money is deducted once tower is placed (since it already checks your $$$ and does not allow you to place a tower if gold < cost)
-I'm gonna maybe add some props (Desk/Office-Supply Models to this level and make a new one (????)

***Important***

I just found out that if you export everything in someone's project as a UnityPackage (Assets>Export Package...) and then import it into your own project, it will add things your project doesn't have from the package, update things that have changed, and ignore things that are already in your project.
It seems like the best way to add other peoples' functionalities to your project 
I'm not including a UnityPackage because it's just extra space but you can export right from the editor