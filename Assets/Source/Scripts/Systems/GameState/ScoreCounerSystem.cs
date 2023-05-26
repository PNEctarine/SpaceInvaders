using Kuhpik;
using UnityEngine;

public class ScoreCounerSystem : GameSystemWithScreen<GameUI>
{
    public override void OnInit()
    {
        GameEvents.DestroyEnemy_E += AddScore;
        screen.ScoreTMP.text = $"Score {player.Score}";
    }

    private void AddScore(int score, Transform _)
    {
        player.Score += score;
        screen.ScoreTMP.text = $"Score {player.Score}";
    }
}
