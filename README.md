# DDB
A collection of useful DIscord.Net modules for quickly adding functionality to your bot!

## Modules

### Animal Crossing Module

A collection of commands for sharing village information and facilitating trades in Animal Crossing: New Horizons.

#### Interfaces

Provides an IAnimalCrossingService interface, providing the developer with all of the methods that need to be implemented to have a fully functioning module.

#### Models

Provides models for Towns, Fruits, Items, Turnip Price base class, TurnipBuyPrice, and TurnipSell Price. These models can either be used in an entity framework database to persist your data in a database, or serialized to json to be persistent in a file.

#### Preconditions

Includes a Precondition to check if the user has an existing Town. Could be used by developers seeking to add additional commands, granting a precondition that will reject users who haven't registerd a town.

#### Commands

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


### Audio Module

### Bot Module

### Indecision Module

### Jackbox Module

### Pokemon Module

### Server Management Module