﻿local say = topic:new()
say:add("name", "I am Suzy.")
say:addbank()

local handler = npchandler:new( {
    greet = "Welcome [playername]! What can I do for you?",
    busy = "Sorry [playername], I am already talking to a customer. Please wait.",
    say = say,
    farewell = "Good bye.",
    disappear = "Good bye."
} )

registernpcsdialogue("Suzy", handler)