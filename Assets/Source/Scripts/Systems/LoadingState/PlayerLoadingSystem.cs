using Kuhpik;
using UnityEngine;

public class PlayerLoadingSystem : GameSystem
{
    [SerializeField] private GameObject _player;

    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _gamePoint;

    public override void OnInit()
    {
        GameEvents.ClearEvents();

        GameObject player = Instantiate(_player);
        player.transform.position = _spawnPoint.position;

        game.PlayerGamePoint = _gamePoint;
        game.Player = player;
    }
}
