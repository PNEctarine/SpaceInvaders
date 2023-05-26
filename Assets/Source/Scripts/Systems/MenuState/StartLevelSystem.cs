using DG.Tweening;
using Kuhpik;

public class StartLevelSystem : GameSystemWithScreen<MenuUI>
{
    public override void OnStateEnter()
    {
        screen.StartButton.onClick.AddListener(() =>
        {
            game.Player.transform.DOMove(game.PlayerGamePoint.position, 0.3f);
            Bootstrap.Instance.ChangeGameState(GameStateID.Game);
        });
    }

    public override void OnStateExit()
    {
        screen.StartButton.onClick.RemoveAllListeners();
    }
}
