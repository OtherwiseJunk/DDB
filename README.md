# DDB
A collection of useful DIscord.Net modules for quickly adding functionality to your bot!

## Modules

### **Animal Crossing Module**

A collection of commands for sharing village information and facilitating trades in Animal Crossing: New Horizons.

#### **Interfaces**

Provides an IAnimalCrossingService interface, providing the developer with all of the methods that need to be implemented to have a fully functioning module.

#### **Models**

Provides models for Towns, Fruits, Items, Turnip Price base class, TurnipBuyPrice, and TurnipSell Price. These models can either be used in an entity framework database to persist your data in a database, or serialized to json to be persistent in a file.

#### **Preconditions**

Includes a Precondition to check if the user has an existing Town. Could be used by developers seeking to add additional commands, granting a precondition that will reject users who haven't registerd a town.

#### **Commands**

* reg - Allows the user to register their town by name. Ex) `$reg Helltown`
* tornps - Returns a cute meme picture of Timmy or Tommy (you tell me) who is a Tornps Understander.
* tstats - Returns stats on the requesting users lifetime turnip prices
* tweek - Returns stats on the requesting users turnip prices, with the start of the week being Sunday
* hemi - Allows user to set the hemisphere of their town. Accepts n|s|north|south|southern|northern Ex) `$hemi n`
* list - Returns a list of data for all the registered towns.
* flist - Returns a list of each towns available fruits.
* tlist - See a list of registered turnip prices for the day.
* freg - Allows user to register a fruit that grows in their town. Ex) `$freg Apple`
* sell - Allows user to register their Turnip Sell Price for the day.
* buy - Allows user to register their Turnip Buy Price for the day.
* msg - Allows users to send messages to other users they do not share a discord server with
* wreg - Allows users to register an item to their wishlist. Unlike fruit registration there is no check on if it's a real item or not.
* wrem - Allows user to remove the specified item from their wishlist
* wishlist - Returns a list of items in each registered towns wishlist.
* open - Allows the user to indicate their town gate is open. They can also provide a dodocode optionally, which will appear in the `$list` results.
* close - Allows the user to indicate their town gate is closed.
* nreg - Allows the user to register their native fruit for their town. Only one native fruit per town, of course.
* namereg - Allows the user to register a "Real Name" or nickname that will appear in the `$list` instead of their discord name, if the user is present in the server the request is made from.


### **Audio Module**

In theory allows you to connect to a Lavanode server and do audio things with a bot. Wouldn't recommend using this currently, but feel free to try anyway!

### **Bot Module**

#### **Interfaces**

An interface allowing developers to specify an installation link and Github Repo link for your bot. Used in the Bot Module Command responses.

#### **Commands**

* listchnl - Requires Owner. Lists all of the guilds/channels the bot is in.
* playing - Requires Owner. Allows the owner to specify what the bot is "playing".
* say - Requires Owner. Allows the owner to send a message as the bot.
* link - Provides the configured link for users to add the bot to their own servers.
* repo - Provides a link to the bot's configured Github repository.
* renick - Requires Owner. Allows the owner to specify the bots nickname for the current server.

### **Chat Module**

A collection of fun chat commands that the bot can use to liven up the place!

#### **Commands**

* 8ball - Gives an 8ball response to a given question. Bot doesn't actually do anything with the question.
* clap - Will replace the message the user sends with a message with Clap emotes between each word. Will preserve the username of the triggering user, and wil reply to any message the original was replying to.
* mock - Will replace the message the user sends with a message with a SpoNGeBoB MOcKiFIeD VErsiOn oF tHe MessAge. Will preserver the username of the triggering user, and wil reply to any message the original was replying to.
### **Indecision Module**

#### **Commands**

* pick - Will select at random one of the provided values in a comma separated list. Users can add an arbitrary number of `+` to increase the odds of a given choice. Ex) `$pick something,from,this,list++` (List would have 3 entires, every other value would have 1).
* roll - Allows the user to roll dice! Ex) `$roll 420d69+1337`

### **Jackbox Module**

#### **Interfaces**

Provides an interface for Jackbox Constants, so you can specify your own emotes/player descriptors for each game. Also includes a default implementation, JackboxConstants

#### **Commands**

* jackbox - Requests that the bot create a poll for jackbox games. User must provide a comma separated lists of Jackbox games to create the list for Ex) `$jackbox 1,3,7` would return a poll with all the games in Jackbox 1, Jackbox 3, and Jackbox 7.

### **Pokemon Module**

In theory allows users in a channel to register as owning either Sword or Shield. Module doesn't provide much functionality, so another I would recommend skipping.

### **Server Management Module**

#### **Interfaces**

IServerMangmentService allows the developer to provide implementation data needed for the RoleColor command. HexColorValidation Regex, a method for parsing Discord Colors from a string hexcode,
a method for checking if the given role exists, and a method for actually modifying the user's role.

#### **Commands**

* rolecolor - Allows the user to request a role be created of the specified color. Will automatically assign the role to the bot if able.

## **Preconditions**

This package also contains a collection of preconditions that you can apply to any commands/modules you develop.

* RequireChannelAttribute - Allows you to require a command be sent from specific Channel (by ChannelID).
* RequireGuildAttribute - Allows you to require a command be sent from a specific Guild (by GuildID).
* RequireRoleName - Allows you to require a command be sent by a user with a specific Role (by Role Name).

## **Utilities/Services**

This package also contains a collection of services, and corresponding interfaces so you can implement your own version.

* Audio Service - Used for the audio module. Mostly junk for now, like the module!
* MessageReliabilityService - Allows you to inject a service that will ensure that if messages are over the discord max message length that they are properly sent in multiple messages.
