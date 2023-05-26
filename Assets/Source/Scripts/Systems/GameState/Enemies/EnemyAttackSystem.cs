using System.Collections.Generic;
using Kuhpik;
using UnityEngine;

public class EnemyAttackSystem : GameSystem
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private int _attackCoolDown;

    private float _coolDown = 1f;
    private Queue<GameObject> _bullets = new Queue<GameObject>();
    private GameObject _activeBullet;

    public override void OnInit()
    {
        GameEvents.ReturnEnemyBullet_E += ReturnBullet;

        for (int i = 0; i < 5; i++)
        {
            _activeBullet = Instantiate(_bullet);
            _bullets.Enqueue(_activeBullet);
            _activeBullet.SetActive(false);
        }
    }

    public override void OnUpdate()
    {
        if (_coolDown == 0)
        {
            int enemyIndex = Random.Range(0, game.Enemies.Count);
            _activeBullet = _bullets.Dequeue();
            _activeBullet.SetActive(true);
            _activeBullet.transform.position = game.Enemies[enemyIndex].transform.position;
        }

        else if (_coolDown >= _attackCoolDown)
        {
            _activeBullet.SetActive(false);
            _coolDown = 0;

            return;
        }

        _coolDown += Time.deltaTime;
    }

    private void ReturnBullet(GameObject bullet)
    {
        _bullets.Enqueue(bullet);
    }
}
