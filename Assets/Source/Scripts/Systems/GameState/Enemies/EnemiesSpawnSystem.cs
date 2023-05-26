using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class EnemiesSpawnSystem : GameSystem
{
    [SerializeField] private EnemiesConfig _enemiesConfig;
    [SerializeField] private float _enemiesCount;
    [SerializeField][ReadOnly] private float _enemiesSpace = 0.5f;

    private Camera _mainCamera;

    public override void OnInit()
    {
        game.EnemiesSpace = _enemiesSpace;

        _mainCamera = Camera.main;
        game.MaxTopLeft = _mainCamera.ViewportToWorldPoint(new Vector2(0, 1));

        if ((_enemiesCount - 1) % 2 == 0)
        {
            game.FirstEnemyX = (_enemiesCount - 1) / 2 * _enemiesSpace;
        }

        else
        {
            game.FirstEnemyX = _enemiesSpace / 2 * (_enemiesCount - 1);
        }

        game.EnemiesSwarm = new() { name = "Swarm" };

        for (int i = 0; i < _enemiesConfig.Enemies.Length; i++)
        {
            float posY = i;
            float posX = -game.FirstEnemyX;

            for (int j = 0; j < _enemiesCount; j++)
            {
                GameObject enemy = Instantiate(_enemiesConfig.Enemies[i].Enemy);

                enemy.transform.position = new Vector2(posX, posY);
                enemy.transform.parent = game.EnemiesSwarm.transform;
                enemy.GetComponent<EnemyHealthComponent>().AddHealth(_enemiesConfig.Enemies[i].health);

                posX += _enemiesSpace;

                game.Enemies.Add(enemy);
                game.EnemiesCount++;
            }
        }

        game.EnemiesSwarm.transform.position = new Vector2(0, game.MaxTopLeft.y - _enemiesConfig.Enemies.Length);
    }
}
