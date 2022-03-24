<div align="center">
  <br />
  <h1>Daniel Machado</h1>
</div>

<p align="center">
  Creative C# Console Game
</p>

---

## Description

- It's a C# .Net simple console game, made in a simplified MVC(model, view, control) scheme, with a couple of unique AND hidden rules and mechanics that remind ourselves from the 90's years, where only the personal enthusiasm and curiosity of being able to improve your own skills were enough to get happy. Also, this little project has an extremely easy and simple console engine, like Lego, that can be used in a large range of ideas. Feel free to use that as you wish. =)

## How to start

- In order to start the game you must have Visual Studio installed with .Net Core package - Windows environment

## About the engine code

- As you can see below, all the classes and methods related to the game logic are within the square (LogicServices namespace), whereas the other parts of the MVC scheme are positioned in a specific namespace and folder too. For the majority of situations, only the controllers can see and communicate data with the model layer to avoid messes, but there are a few adjustments yet to be done in this matter.
 
<a title="LibQuality API">
  <img src="https://i.imgur.com/lKv7rC1.png"/>
</a>

- This GameLogics class deals with the main business rules, such a method that returns a bool containing the data IF it is possible or NOT to move the player, called 'IsItPossibleToMoveThePlayer'.

<a title="LibQuality API">
  <img src="https://i.imgur.com/85zmnd1.png"/>
</a>

- This one is the input layer main method, which can be extended as well.

<a title="LibQuality API">
  <img src="https://i.imgur.com/ahrZzDx.png"/>
</a>

- This is the view layer's Table class which makes the game assets appear on the screen whenever it is called again in the main loop. It returns a string matrix [,] containing the assets data to make up the game field.

<a title="LibQuality API">
  <img src="https://i.imgur.com/DbOFg8P.png"/>
</a>

- Finally, this is one of the most important steps in this engine project, where
the player, the spyders (enemies) and the pieces of food are set from the NEW assets positions in the memory to the matrix that will be rendered on the next steps of the main loop. This method returns a string[,] matrix.

<a title="LibQuality API">
  <img src="https://i.imgur.com/SLDvjZU.png"/>
</a>

## TODO

- The first thing that needs to be improved is the position of the spyders on the field, which could be a lot more fun if they just appear randomly
  - In order to do that, it'll be necessary to check the player position, to NOT spawn a spyder OVER the player position, which would let the game to trigger the main loop end (game over)
- You can create and try to change the field assets, figuring out new ways to fill it up, as well as creating new enemies shapes.
- Improve the Score method
- Create weapons to the player and add the methods to use it in the input layer
- Create new games and assets with this console engine, your imagination is the limit!

## Contact

- Please, if you like this engine and made something new to it, contact me via my github profile email
- Feel free to use and change the code, enjoy it, thanks!