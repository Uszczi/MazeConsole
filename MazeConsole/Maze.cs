using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace MazeConsole;

public class Cell
{
    public List<Cell> neighbours;
    public List<Cell> wall_neighbours;
    public int row;
    public int col;
    public bool visited;

    public Cell() {
        neighbours = new List<Cell>();
        wall_neighbours = new List<Cell>();
    }
}

public class RandomizedDepthFirstSearch
{
    public static void Generate(Maze maze)
    {
        Cell startCell = maze.cells[0, 0];
        startCell.visited = true;

        Stack<Cell> stack = new Stack<Cell>();

        stack.Push(startCell);

        while (stack.Count > 0)
        {
            Cell current_cell = stack.Pop();

            List<Cell> possible_neig = new List<Cell>();
            foreach (Cell neig in current_cell.wall_neighbours)
            {
                if (!neig.visited)
                {
                    possible_neig.Add(neig);
                }
            }
            if (possible_neig.Count > 0)
            {
                
                Random random = new Random();
                int index = random.Next(possible_neig.Count);
                Cell randomNeig = possible_neig[index];

                current_cell.wall_neighbours.Remove(randomNeig);
                current_cell.neighbours.Add(randomNeig);

                randomNeig.wall_neighbours.Remove(current_cell);
                randomNeig.neighbours.Add(current_cell);

                randomNeig.visited = true;
                stack.Push(current_cell);
                stack.Push(randomNeig);
            }
        }
    }
}

public class Maze
{
    public int rows;
    public int cols;
    public Cell[,] cells;


    public Maze(int rows, int cols) { 
        this.rows = rows;
        this.cols = cols;

        cells = new Cell[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++) { 
                Cell cell = new Cell { row=i, col=j };
                cells[i,j] = cell;
            }
        }

        int last_row = rows - 1;
        int last_col = cols - 1;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // Right and left neigbours
                if (j < last_col)
                {
     
                  cells[i, j].wall_neighbours.Add(cells[i, j+1]);
                  cells[i, j + 1].wall_neighbours.Add(cells[i, j]);
                }

                // Bottom and top
                if (i < last_row)
                {                  
                      cells[i, j].wall_neighbours.Add(cells[i+1,j]);
                      cells[i+1, j].wall_neighbours.Add(cells[i, j]);
                }
            }
        }

    }
    
    public void Display()
    {
        Console.WriteLine("---Maze---");
        Console.WriteLine($"Rows: {rows} Columns: {cols}");

        string horizontal_line = "#";
        for (int i = 0; i < cols; i++) {
            horizontal_line += "###";
        }
        Console.WriteLine(horizontal_line);
        
        for (int i = 0; i < rows; i++) {
            string line = "#";
            for (int j = 0; j < cols; j++) {
                Cell cell = cells[i, j];

                bool has_right_neigbour = false;
                foreach (Cell neib in cell.neighbours) 
                { 
                        if (neib.col > cell.col && neib.row == cell.row)
                        {
                            has_right_neigbour = true;
                        }
                }

                if ( has_right_neigbour)
                {

                    line += $"   ";
                }else
                {

                    line += $"  #";
                }

            }
            Console.WriteLine(line);

            if (i < rows -1)
            {
                line = "#";
      

                for (int j = 0; j < cols; j++)
                {
                    Cell cell = cells[i, j];
                    bool has_bottom_neigbour = false;
                    foreach (Cell neib in cell.neighbours)
                    {
                        if (neib.col == cell.col && neib.row > cell.row)
                        {
                            has_bottom_neigbour = true;
                        }
                    }

                    if (has_bottom_neigbour)
                    {

                        line += $"  #";
                    }
                    else
                    {

                        line += $"###";
                    }
                }
                Console.WriteLine(line);
            }


        }

        Console.WriteLine(horizontal_line);

    }
    }

