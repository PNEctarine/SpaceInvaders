using DG.Tweening;
using Kuhpik;
using UnityEngine;

public class EnemiesMovementSystem : GameSystem
{
    [SerializeField] private float _movementSpeed;
    private Vector3 _movementDirection;

    private float _maxLeft;
    private float _maxRight;
    private float _offsetDown = 0.5f;

    private bool _isChangeDirection;

    public override void OnInit()
    {
        _movementDirection = Vector3.left;

        _maxLeft = game.MaxTopLeft.x + game.FirstEnemyX + game.EnemiesSpace;
        _maxRight = _maxLeft * -1;
    }

    public override void OnUpdate()
    {
        if (_isChangeDirection == false)
        {
            game.EnemiesSwarm.transform.position += _movementSpeed * Time.deltaTime * _movementDirection;

            if (game.EnemiesSwarm.transform.position.x <= _maxLeft || game.EnemiesSwarm.transform.position.x >= _maxRight)
            {
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        if (_isChangeDirection == false)
        {
            _isChangeDirection = true;
            float offsetX = game.EnemiesSwarm.transform.position.x + 0.5f * _movementDirection.x * -1;
            float offsetY = game.EnemiesSwarm.transform.position.y + _offsetDown * -1f;

            game.EnemiesSwarm.transform.DOMove(new Vector2(offsetX, offsetY), _movementSpeed).OnComplete(() =>
            {
                _movementDirection *= -1;
                _isChangeDirection = false;
            });
        }
    }
}
