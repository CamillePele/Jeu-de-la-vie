public class Coords
{
    public readonly int _x;
    public readonly int _y;

    public Coords(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public string ToString()
    {
        return _x + "-" + _y;
    }
}