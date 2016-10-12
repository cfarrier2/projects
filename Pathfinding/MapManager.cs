using System;
using System.Collections.Generic;
using System.Linq;

public class MapManager : IProvideMap
{
    //map stores all of the known squares.  Can build visualization from it
    public List<Square> map;
    public List<PairOfCoords> blacklist;
    public Square startPoint;
    public Square endPoint;
    public Stack<Square> travelLog;
    public Square currentSquare;
    public List<Square> obstacles; 

    public List<Square> possibleMoves;

    private DirectionModifier _directionModifier;
    private PairOfCoords coordsOfSquareOnTrial;
    private List<PairOfCoords> allDirections;
    private List<FScore> sortedFScoresList;
    private Stack<FScore> lastResortFScores;

    public MapManager(PairOfCoords start, PairOfCoords end, List<Square> startingObstacles )
    {
        _directionModifier = new DirectionModifier();

        travelLog = new Stack<Square>();
        startPoint = new Square(start.x, start.y);
        currentSquare = startPoint;
        travelLog.Push(startPoint);
        endPoint = new Square(end.x, end.y);
        map = new List<Square>();
        possibleMoves = new List<Square>();
        blacklist = new List<PairOfCoords>();
        obstacles = startingObstacles;
        sortedFScoresList = new List<FScore>();
        lastResortFScores = new Stack<FScore>();
        if (obstacles.Count != 0 && obstacles != null)
        {
            foreach (var obstacle in obstacles)
            {
                blacklist.Add(new PairOfCoords(obstacle.x, obstacle.y));
            }
        }
        coordsOfSquareOnTrial = new PairOfCoords(0,0);
        allDirections = _directionModifier.GetAllDirectionsModifiers();


    }

    public bool Blacklisted(int x, int y)
    {
        if (blacklist.Count == 0)
            return false;
        foreach (var pairOfCoords in blacklist)
        {
            if (x == pairOfCoords.x && y == pairOfCoords.y)
            {
                return true;
            }
        }
        return false;
    }


    public void ClearPossibleMovesList()
    {
        possibleMoves.Clear();
    }

    //After moving, new origin to survey from

    public void PopulatePossibleMovesIfValid(PairOfCoords directionModifier)
    {
        coordsOfSquareOnTrial.x = currentSquare.x + directionModifier.x;
        coordsOfSquareOnTrial.y = currentSquare.y + directionModifier.y;

        if (!Blacklisted(coordsOfSquareOnTrial.x, coordsOfSquareOnTrial.y))
        {
            possibleMoves.Add(new Square(coordsOfSquareOnTrial.x, coordsOfSquareOnTrial.y));
            map.Add(new Square(coordsOfSquareOnTrial.x, coordsOfSquareOnTrial.y));
            

        }
    }



    public void SurveySurroundings() //Don't need the parameter
    {
        possibleMoves.Clear();
        map = map.Distinct().ToList();

        foreach (var direction in allDirections)
        {
            PopulatePossibleMovesIfValid(direction);
        }
        
    }

    public bool AtEnd()
    {
        if ((travelLog.Peek().x == endPoint.x) && (travelLog.Peek().y == endPoint.y))
        {
            return true;
        }
        return false;
    }

    public void PrintTravelLog()
    {
        Console.WriteLine("End");
        foreach (var square in travelLog)
        {
            Console.WriteLine(square.x + ", " + square.y);
        }
        Console.WriteLine("Start");
        //Console.ReadKey();
    }



    public void GetBestMove()
    {
        var directionScore = 0;
        var asBirdFliesScore = 0;
        List<FScore> FScores = new List<FScore>();
        

        SurveySurroundings();

        foreach (var candidateSquare in possibleMoves)
        {
            foreach (var square in travelLog)
            {
                if (candidateSquare.x.Equals(square.x) && candidateSquare.y.Equals(square.y))
                {
                    candidateSquare.freshSnow = false;
                }
            }
            directionScore = candidateSquare.GetDirectionScore(currentSquare, candidateSquare);
            asBirdFliesScore = candidateSquare.GetAsTheBirdFliesScore(endPoint, candidateSquare);

            if (candidateSquare.freshSnow)
            {
                FScores.Add(new FScore(directionScore + asBirdFliesScore, candidateSquare));
            }

            if (!candidateSquare.freshSnow)
            {
                lastResortFScores.Push(new FScore(directionScore + asBirdFliesScore, candidateSquare));
                //FScores.Add(new FScore(directionScore + asBirdFliesScore, candidateSquare));  //may need to increase penalty
            }
        }

        if (FScores.Count > 0)
        {
            sortedFScoresList = FScores.OrderBy(o => o.fScore).ToList();

            travelLog.Push(sortedFScoresList[0].fScoreSquare);

            currentSquare = sortedFScoresList[0].fScoreSquare;
            currentSquare.freshSnow = false;
        }

        if (FScores.Count == 0 && lastResortFScores.Count > 0)
        {
            if (!Blacklisted(currentSquare.x, currentSquare.y))
            {
                blacklist.Add(new PairOfCoords(currentSquare.x, currentSquare.y));
            }
            currentSquare = lastResortFScores.Peek().fScoreSquare;
            blacklist.Add(new PairOfCoords(lastResortFScores.Peek().fScoreSquare.x, lastResortFScores.Peek().fScoreSquare.y));

            travelLog.Push(lastResortFScores.Pop().fScoreSquare);
            
        }



    }
}