public class Cell
{
    private bool _isAlive { get; set; }
    public bool isAlive { get { return _isAlive; } }
    private bool _nextState { get; set; }

    public Cell(bool state)
    {
        _isAlive = state;
    }

    public void ComeAlive()
    {
        _nextState = true;
    }

    public void PassAway()
    {
        _nextState = false;
    }

    public void Update()
    {
        _isAlive = _nextState;
    }
}
