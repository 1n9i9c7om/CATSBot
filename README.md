# CATSBot
A bot for the mobile game "Crash Arena Turbo Stars", short C.A.T.S. running with MEmu.

Check out our forum for more information: [CATSBot Forum](https://catsbot.net)

# Note about this branch

This branch is currently in testing and contains debug code as well as UI elements. Feel free to help us testing and report bugs in our forum, but don't expect everything to work. It might, and it would be cool, but I don't expect this.

Before we'll even consider pulling this branch into master, a few things still have to be done:

* Allow users to specifiy their MEmu installation folder (currently hardcoded)
* Test the thing, duh.
* Automatically restart CATS in case there's an error (using `Bothelper.startCATS()` and `BotHelper.stopCATS()`, the methods exist already. Error recognition is missing, though)
* Polish code and UI (and remove debug-related stuff)
