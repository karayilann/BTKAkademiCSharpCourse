
ScoringAlgortihm algorithm;
Console.WriteLine("Mens scoring algorithm");
algorithm = new MensScoringAlgorithm();
Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
Console.WriteLine("Womens scoring algorithm");
algorithm = new WomenScoringAlghoritms();
Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
Console.WriteLine("Childrens scoring algorithm");
algorithm = new ChildrensScoringAlghoritms();
Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 34)));


abstract class ScoringAlgortihm
{
    public int GenerateScore(int hits, TimeSpan time)
    {
        int score = CalculateBaseScore(hits);
        int reduction = CalculateReduction(time);
        return CalculateOverallScore(score,reduction);

    }
    public abstract int CalculateOverallScore(int score, int reduction);

    public abstract int CalculateReduction(TimeSpan time);

    public abstract int CalculateBaseScore(int hits);

}

class MensScoringAlgorithm : ScoringAlgortihm
{
    public override int CalculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 5;
    }

    public override int CalculateBaseScore(int hits)
    {
        return hits * 100;
    }
}


class WomenScoringAlghoritms: ScoringAlgortihm
{
    public override int CalculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 3;
    }

    public override int CalculateBaseScore(int hits)
    {
        return hits * 100;
    }
}
class ChildrensScoringAlghoritms: ScoringAlgortihm
{
    public override int CalculateOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)time.TotalSeconds / 2;
    }

    public override int CalculateBaseScore(int hits)
    {
        return hits * 80;
    }
}
