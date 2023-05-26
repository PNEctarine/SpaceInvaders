using Kuhpik;
using UnityEngine;

public class EnemiesCountSystem : GameSystem
{
    public override void OnInit()
    {
        GameEvents.DestroyEnemy_E += DestroyEnemy;
    }

    private void DestroyEnemy(int _, Transform __)
    {
        game.EnemiesCount--;

        if (game.EnemiesCount <= 0)
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Victory);
        }
    }
}
