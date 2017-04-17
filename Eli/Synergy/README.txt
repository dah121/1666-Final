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
-A shop that allows you to select different towers
	instead of buying when you click a button, I was thinking the shop menu could just change which tower the tower_builder script is going to place next and money is deducted once tower is placed (since it already checks your $$$ and does not allow you to place a tower if gold < cost)
-I'm gonna maybe add some props (Desk/Office-Supply Models to this level and make a new one (????)
