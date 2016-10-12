using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MoreLinq;
using NUnit.Framework;

public class PathController
{
    private MapManager _mapManager;
    

    public PairOfCoords startCoordinates { get; set; }
    public PairOfCoords endCoordinates { get; set; }

    public void ExecuteAdventure()
    {
        while (!_mapManager.AtEnd())
        {
            _mapManager.GetBestMove();
        }

        _mapManager.PrintTravelLog();
        Console.ReadKey();
    }

    public List<Square> obstaclesList; 

    public PathController()
    {

        PairOfCoords start = GetStartCoordinates();
        PairOfCoords end = GetEndCoordinates();

        List<Square> obstaclesList = GetObstacles();



        _mapManager = new MapManager(start, end, obstaclesList);
    }

    private List<Square> GetObstacles()
    {
        List<Square> obs = new List<Square>();
        obs.Add(new Square(0, 3));
        obs.Add(new Square(0, 2));
        obs.Add(new Square(0, 1));
        obs.Add(new Square(0, 0));
        obs.Add(new Square(0, -1));
        obs.Add(new Square(0, -2));
        obs.Add(new Square(0, -3));

        List<Square> deadEnd = new List<Square>();

        //leftwall
        deadEnd.Add(new Square(-1, 0));
        deadEnd.Add(new Square(-1, -1));
        deadEnd.Add(new Square(-1, -2));
        deadEnd.Add(new Square(-1, -3));
        deadEnd.Add(new Square(-1, -4));

        //rightwall
        deadEnd.Add(new Square(1, 0));
        deadEnd.Add(new Square(1, -1));
        deadEnd.Add(new Square(1, -2));
        deadEnd.Add(new Square(1, -3));
        deadEnd.Add(new Square(1, -4));

        //base
        deadEnd.Add(new Square(-1, -5));
        deadEnd.Add(new Square(0, -5));
        deadEnd.Add(new Square(1, -5));

        return deadEnd;
    }

    private PairOfCoords GetStartCoordinates()
    {
        //        Console.WriteLine("Start X=");
        //        var xStart = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("Start Y=");
        //        var yStart = Convert.ToInt32(Console.ReadLine());

        //        return new PairOfCoords(xStart, yStart);
        return new PairOfCoords(0, 10);
    }

    private PairOfCoords GetEndCoordinates()
    {
        //        Console.WriteLine("End X=");
        //        var xEnd = Convert.ToInt32(Console.ReadLine());
        //        Console.WriteLine("End Y=");
        //        var yEnd = Convert.ToInt32(Console.ReadLine());

        //        return new PairOfCoords(xEnd, yEnd);
        return new PairOfCoords(0, -10);
    }


}