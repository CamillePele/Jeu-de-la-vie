using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class Game
{
    private int n;
    private int iter;
    private int cellSize;
    public Grid grid;
    private readonly List<Coords> aliveCellsCoord = new List<Coords>() 
       {

        new Coords(1+15 ,6+15),

        new Coords(3+15 ,6+15),
        new Coords(3+15 ,5+15),

        new Coords(5+15,4+15),
        new Coords(5+15 ,3+15),
        new Coords(5+15 ,2+15),

        new Coords(7+15 ,3+15),
        new Coords(7+15 ,2+15),
        new Coords(7+15 ,1+15),
        new Coords(8+15 ,2+15)
    
    };

    public Game(int nbCells) : this(nbCells, 5)
    {
    }

    public Game(int nbCells, int cellSize)
    {
        n = nbCells;
        grid = new Grid(nbCells, aliveCellsCoord, true, 30f);
        this.cellSize = cellSize;
    }

    public void RunGameConsole()
    {
        for (int i = 0; i < iter; i++)
        {
            grid.UpdateGrid();
        }
    }
    public void Paint(Graphics g)
    {
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {   
                if (grid.tabCells[i, j].isAlive)
                {
                    g.FillRectangle(whiteBrush, j * cellSize, i * cellSize, cellSize, cellSize);
                }
            }
        }
    }

}
