public class FScore
{
    public int fScore { get; set; }
    public Square fScoreSquare { get; set; }

    public FScore(int fScore, Square fScoreSquare)
    {
        this.fScore = fScore;
        this.fScoreSquare = fScoreSquare;
    }
}