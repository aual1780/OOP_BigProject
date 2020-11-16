# BattleCOD 3: Eastern Front 2

BattleCOD 3: Eastern Front 2 is a top-down, 2D survival tank shooter.  Players attempt to stay alive for as long as possible while battling an unrelenting horde of enemies from the protection of a Panzer mk VI Tiger.  Points will be earned for destroying enemies and surviving waves.  Tank teams will be able to compare themselves and evaluate their performance with the game’s scoreboard.

The game has 2 main components: the gamehost and the controllers.  The host will display the game (game field, tank, enemies, health, points, etc) while the controllers allow players to operate the tank remotely.  To force teams to work together, the tank controls will be distributed across multiple controllers.  The game will support 1-6 players, and each player will run their controller from their own device.  Possible controls include tank movement, weapon aiming, weapon loading, and shooting.  Each controller will be assigned roles and can only command those specific tank features.  Additionally, controllers will only show information relative to their roles - this prevents any one team member from knowing everything about the tank.  In this way, the players will have to communicate to operate the tank and avoid blowing themselves up.

However, we have not forgotten our player base - we know that not everyone can pull together 5 (or even 1) friends for a game.  The gamehost will dynamically allocate tank operator roles based on the player count.  If only a single player is present, then all roles will be allocated to a single controller.  To streamline the process, a single player will be able to control the game directly from the gamehost.

This action-packed shooter is guaranteed to ruin friendships and leave players bickering like married couples.  It’s minutes of fun!

### Supported Platforms

The game will run on both Windows and Ubuntu.  The CLI controller will run on any platform that has .Net 5.0 runtime support, but the GUI controller is only available for Windows.

### Networking

This project makes extensive use of the [ArdNet](https://dev.azure.com/tipconsulting/ArdNet) messaging protocol.  It is a multiplatform, high performance, TCP-based network communication library.  We configure the library using floating network ports to allow multiple games on the same network, or even the same machine.  This may cause problems with firewalls since each new game will have a new port number.
