using System;
using System.Collections.Generic;

enum Direction
{
    UpLeft = 1,
    Up = 2,
    UpRight = 3,
    Right = 4,
    DownRight = 5,
    Down = 6,
    DownLeft = 7,
    Left = 8
}

class DirectionModifier : IProvideDirectionModifier
{

    List<PairOfCoords> allDirections = new List<PairOfCoords>(); 

    public PairOfCoords UpLeftModifier => new PairOfCoords(-1, 1);
    public PairOfCoords UpModifier => new PairOfCoords(0, 1);
    public PairOfCoords UpRightModifier => new PairOfCoords(1, 1);
    public PairOfCoords RightModifier => new PairOfCoords(1, 0);
    public PairOfCoords RightDownModifier => new PairOfCoords(1, -1);
    public PairOfCoords DownModifier => new PairOfCoords(0, -1);
    public PairOfCoords DownLeftModifier => new PairOfCoords(-1, -1);
    public PairOfCoords LeftModifier => new PairOfCoords(-1, 0);

    

    public List<PairOfCoords> GetAllDirectionsModifiers()
    {
        allDirections.Add(UpLeftModifier);
        allDirections.Add(UpModifier);
        allDirections.Add(UpRightModifier);
        allDirections.Add(RightModifier);
        allDirections.Add(RightDownModifier);
        allDirections.Add(DownModifier);
        allDirections.Add(DownLeftModifier);
        allDirections.Add(LeftModifier);

        return allDirections;
    }


    
}

internal interface IProvideDirectionModifier
{
    PairOfCoords UpLeftModifier { get; }
    PairOfCoords UpModifier { get; }
    PairOfCoords UpRightModifier { get; }
    PairOfCoords RightModifier { get; }
    PairOfCoords RightDownModifier { get; }
    PairOfCoords DownModifier { get; }
    PairOfCoords DownLeftModifier { get; }
    PairOfCoords LeftModifier { get; }

    List<PairOfCoords> GetAllDirectionsModifiers();
}