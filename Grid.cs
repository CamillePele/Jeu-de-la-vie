using System;
using System.Collections.Generic;
using System.Linq;

public class Grid
{
    private int _n { get; set; } //Le nombre de cellules
    public Cell[,] tabCells;

    private Random random = new Random();

    public Grid(int nbCells, List<Coords> aliveCellsCoords, bool random, float chance)
    {
        _n = nbCells;
        tabCells = new Cell[nbCells, nbCells];


        if (random)
        {
            for (int y = 0; y < nbCells; y++)
            {
                for (int x = 0; x < nbCells; x++)
                {
                    double rng = this.random.NextDouble();
                    tabCells[y, x] = new Cell(rng <= chance/100);
                }
            }
            return;
        }
        
        
        for (int y = 0; y < nbCells; y++)
        {
            for (int x = 0; x < nbCells; x++)
            {
                tabCells[y, x] = new Cell( false );
            }
        }
        
        foreach (Coords coord in aliveCellsCoords)
        {
            tabCells[coord._x, coord._y] = new Cell(true);
        }
    }

    public int GetNbAliveNeighboor(int i, int j)
    {
        int amountAlive = 0;
        for (int y = -1; y < 2; y++)
        {
            for (int x = -1; x < 2; x++)
            {
                //Console.WriteLine((i+y >= 0 && i+y <= _n-1 && j+l >= 0 && j+l <= _n-1));
                //Console.WriteLine(y + i +" "+l+j);

                if ((i + y >= 0 && i + y <= _n - 1 && j + x >= 0 && j + x <= _n - 1) &&
                    tabCells[i + y, j + x].isAlive && !(x == 0 && y == 0)) amountAlive++;
            }
        }
        return amountAlive;
    }

    public List<Coords> getCoordsCellsAlive(int i, int j)
    {
        List<Coords> coords = new List<Coords>();
        Coords test = new Coords(i, j);
        for (int y = -1; y < 2; y++)
        {
            for (int x = -1; x < 2; x++)
            {
                if ( (i+y >= 0 && i+y <= _n-1 && j+x >= 0 && j+x <= _n-1) && tabCells[i+y, j+x].isAlive && !(i == y && j == x))
                    coords.Add(new Coords(i+x, j+y));
            }
        }
        return coords;
    }

    public void DisplayGrid()
    {
        string top = String.Join("", Enumerable.Repeat("+---", _n)) + "+" + "\n"; //Construction des bords

        string text = "";
        
        List<String> mid = new List<string>();
        for (int i = 0; i < _n; i++)
        {
            text += top;
            text += string.Join("", Enumerable.Range(0, _n)
                .Select(y => tabCells[y, i].isAlive ? "| X " : "|   ").ToList()) + "|\n"; //Contruction d'une ligne
        }

        Console.WriteLine(text += top);
    }

    public void UpdateGrid()
    {
        //DisplayGrid();
        for (int y = 0; y < _n; y++)
        {
            for (int x = 0; x < _n; x++)
            {

                if (!tabCells[y, x].isAlive && GetNbAliveNeighboor(y, x) == 3) tabCells[y, x].ComeAlive();

                else if (tabCells[y, x].isAlive && (GetNbAliveNeighboor(y, x) == 3 || GetNbAliveNeighboor(y, x) == 2)) tabCells[y, x].ComeAlive();

                else tabCells[y, x].PassAway();
            }
        }
    
        for (int y = 0; y < _n; y++)
        {
            for (int x = 0; x < _n; x++)
            {
                tabCells[y, x].Update();
            }
        }
    }
}
