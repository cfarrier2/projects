using System.Collections.Generic;
using NUnit.Framework;
using Pathfinding;

[TestFixture]
public class PathfindingTests
{
    private MapManager _sut;
    private List<Square> obstacles;

    [SetUp]
    public void Setup()
    {
        obstacles = new List<Square>();
    }

    [Test]
    public void Should_Calculate_Straight_Horizontal_Path()
    {

        _sut = new MapManager(new PairOfCoords(0, 0), new PairOfCoords(10, 0), obstacles);
        while (!_sut.AtEnd())
        {
            _sut.GetBestMove();
        }
        _sut.PrintTravelLog();
    }

    [Test]
    public void Should_Calculate_Straight_Vertical_Path()
    {
        _sut = new MapManager(new PairOfCoords(0, 0), new PairOfCoords(0, 10), obstacles);
        while (!_sut.AtEnd())
        {
            _sut.GetBestMove();
        }
        _sut.PrintTravelLog();
    }

    [Test]
    public void Should_Calculate_Path_With_Simple_Obstacle()
    {
        obstacles.Add(new Square(0, 3));
        obstacles.Add(new Square(0, 2));
        obstacles.Add(new Square(0, 1));
        obstacles.Add(new Square(0, 0));
        obstacles.Add(new Square(0, -1));
        obstacles.Add(new Square(0, -2));
        obstacles.Add(new Square(0, -3));
        _sut = new MapManager(new PairOfCoords(-5, 0), new PairOfCoords(5, 0), obstacles);
        while (!_sut.AtEnd())
        {
            _sut.GetBestMove();
        }
        _sut.PrintTravelLog();
    }

    [Test]
    public void Should_Navigate_Back_From_Dead_End()
    {
        obstacles.Add(new Square(-1, 0));
        obstacles.Add(new Square(-1, -1));
        obstacles.Add(new Square(-1, -2));
        obstacles.Add(new Square(-1, -3));
        obstacles.Add(new Square(-1, -4));

        obstacles.Add(new Square(1, 0));
        obstacles.Add(new Square(1, -1));
        obstacles.Add(new Square(1, -2));
        obstacles.Add(new Square(1, -3));
        obstacles.Add(new Square(1, -4));

        obstacles.Add(new Square(-1, -5));
        obstacles.Add(new Square(0, -5));
        obstacles.Add(new Square(1, -5));

        _sut = new MapManager(new PairOfCoords(0, 10), new PairOfCoords(0, -10), obstacles);
        while (!_sut.AtEnd())
        {
            _sut.GetBestMove();
        }
        _sut.PrintTravelLog();
    }

    [Test]
    public void Should_Navigate_Deadend_In_Reverse()
    {
        obstacles.Add(new Square(-1, 0));
        obstacles.Add(new Square(-1, -1));
        obstacles.Add(new Square(-1, -2));
        obstacles.Add(new Square(-1, -3));
        obstacles.Add(new Square(-1, -4));

        obstacles.Add(new Square(1, 0));
        obstacles.Add(new Square(1, -1));
        obstacles.Add(new Square(1, -2));
        obstacles.Add(new Square(1, -3));
        obstacles.Add(new Square(1, -4));

        obstacles.Add(new Square(-1, -5));
        obstacles.Add(new Square(0, -5));
        obstacles.Add(new Square(1, -5));

        _sut = new MapManager(new PairOfCoords(0, 10), new PairOfCoords(0, -10), obstacles);
        while (!_sut.AtEnd())
        {
            _sut.GetBestMove();
        }
        _sut.PrintTravelLog();
    }
}