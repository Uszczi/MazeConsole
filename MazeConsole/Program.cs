using System.Data;
using System.Text;
using MazeConsole;

Maze maze = new Maze(rows: 10, cols: 15);

maze.Display();
RandomizedDepthFirstSearch.Generate(maze);
maze.Display();
