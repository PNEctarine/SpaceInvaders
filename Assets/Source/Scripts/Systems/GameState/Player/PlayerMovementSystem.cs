using Kuhpik;
using UnityEngine;

public class PlayerMovementSystem : GameSystem
{
    [SerializeField] private float _inputAcceleration = 5;
    private Vector2 _maxTopRight;

    public override void OnInit()
    {
        _maxTopRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public override void OnUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 newPosition = game.Player.transform.position + new Vector3(game.InputVector.x, game.InputVector.y, 0f) * _inputAcceleration * Time.deltaTime;
        Vector2 clampedPosition = new Vector3(Mathf.Clamp(newPosition.x, -_maxTopRight.x, _maxTopRight.x), Mathf.Clamp(newPosition.y, -_maxTopRight.y, _maxTopRight.y));

        game.Player.transform.position = clampedPosition;
    }
}
