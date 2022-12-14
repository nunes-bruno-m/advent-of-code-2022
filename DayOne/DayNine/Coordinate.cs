
using System.Linq;

public class Coordinate
{
    public int x { get; set; }
    public int y { get; set; }
    public bool IsTail { get; set; }

    public List<string> PositionsLog{ get; set; } = new List<string>();

    public Coordinate(int x, int y, bool isTail = false)
    {
        this.x = x;
        this.y = y;
        IsTail = isTail;
        LogPosition();
    }

    public void FixDiagonal(Coordinate target, Coordinate movement)
    {

        if(movement.x == 1 && movement.y == 1)
        {
            this.x += movement.x > 0 ? 1:-1;
            this.y += movement.y > 0 ? 1 : -1;
        } else
        {
            if (movement.x != 0)
            {
                if (target.y != this.y && Math.Abs(target.x - this.x) > 1)
                {
                    var direction = target.y - this.y > 0 ? 1 : -1;
                    this.y += direction;
                }
            }
            if (movement.y != 0)
            {
                if (Math.Abs(target.y - this.y) > 1 && target.x != this.x)
                {
                    var direction = target.x -this.x > 0 ? 1 : -1;
                    this.x += direction;
                }
            }
        }
    }
    public void FixDiagonalOld(Coordinate target, Coordinate movement)
    {

        if (movement.x == 1 && movement.y == 1)
        {
            this.x += movement.x > 0 ? 1 : -1;
            this.y += movement.y > 0 ? 1 : -1;
        }
        else
        {
            if (movement.x != 0)
            {
                if (target.y != this.y && Math.Abs(target.x - this.x) > 1)
                {
                    this.y = target.y;
                }
            }
            if (movement.y != 0)
            {
                if (Math.Abs(target.y - this.y) > 1 && target.x != this.x)
                {
                    this.x = target.x;
                }
            }
        }
    }

    public void Move(Coordinate movement)
    {
        this.x += movement.x;
        this.y += movement.y;
    }

    public void Follow(Coordinate target, Coordinate movement)
    {
        FixDiagonal(target, movement);
        if (movement.x != 0 && target.x != this.x)
        {
            var direction = movement.x > 0 ? 1 : -1;

            while(target.x != this.x + direction)
            {
                this.x += direction;
                LogPosition();
            }

        }
        else if (movement.y != 0 && target.y != this.y)
        {
            var direction = movement.y > 0 ? 1 : -1;
         
            while (target.y != this.y + direction)
            {
                this.y += direction;
                LogPosition();
            }
        }
        LogPosition();
    }
    public void FollowOld(Coordinate target, Coordinate movement)
    {
        FixDiagonal(target, movement);
        if (movement.x != 0 && target.x != this.x)
        {
            var direction = movement.x > 0 ? 1 : -1;

            while (target.x != this.x + direction)
            {
                this.x += direction;
                LogPosition();
            }

        }
        else if (movement.y != 0 && target.y != this.y)
        {
            var direction = movement.y > 0 ? 1 : -1;

            while (target.y != this.y + direction)
            {
                this.y += direction;
                LogPosition();
            }
        }
        LogPosition();
    }

    private void LogPosition()
    {
        var key = $"{this.x}:{this.y}";
        PositionsLog.Add(key);
    }
}
//Console.WriteLine("Puzzle two: " + puzzleTwo(false));