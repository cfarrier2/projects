using System;

public class Square
{
    public int x { get; set; }
    public int y { get; set; }
    public bool freshSnow { get; set; } //might not need
    public bool isBlacklisted;
    private Direction? direction;

    //Field of view around this square
    public int GetDirectionScore(Square currentSquare, Square candidateSquare)
    {
        if (candidateSquare.x - currentSquare.x > 0 || currentSquare.x - candidateSquare.x > 0)
        {
            if (candidateSquare.y - currentSquare.y > 0 || currentSquare.y - candidateSquare.y > 0)
            {
                return 14;
            }

            return 10;
        }

        return 10;

    }

    public int GetAsTheBirdFliesScore(Square endPoint, Square candidateSquare)
    {
        int totalXFromStartToEnd = 0;
        int totalYFromStartToEnd = 0;

        totalXFromStartToEnd = endPoint.x - candidateSquare.x;
        totalYFromStartToEnd = endPoint.y - candidateSquare.y;

        return (Math.Abs(totalXFromStartToEnd) + Math.Abs(totalYFromStartToEnd))*10;
    }

    

    public Square(int x, int y)
    {
        freshSnow = true;
        isBlacklisted = false;
        this.x = x;
        this.y = y;


    }



    public Square()
    {
        x = 0;
        y = 0;
        freshSnow = true;

        direction = null;
    }


}