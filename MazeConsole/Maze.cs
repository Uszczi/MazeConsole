using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeConsole;

public class Cell
{
    public List<Cell> neigbours;
    public int row;
    public int col;

    public Cell() { 
        neigbours = new List<Cell>();
    }

}

public class Maze
{
    public int rows;
    public int cols;
    private Cell[,] cells;


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
     
                  cells[i, j].neigbours.Add(cells[i, j+1]);
                  cells[i, j + 1].neigbours.Add(cells[i, j]);
                }

                // Bottom and top
                if (i < last_row)
                {                  
                      cells[i, j].neigbours.Add(cells[i+1,j]);
                      cells[i+1, j].neigbours.Add(cells[i, j]);
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
                foreach (Cell neib in cell.neigbours) 
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
                    foreach (Cell neib in cell.neigbours)
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

