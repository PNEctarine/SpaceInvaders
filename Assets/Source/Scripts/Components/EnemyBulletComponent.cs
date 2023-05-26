using UnityEngine;

public class EnemyBulletComponent : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + -_speed * Time.deltaTime);

        if (gameObject.transform.position.y < -10)
        {
            GameEvents.ReturnEnemyBullet_E?.Invoke(gameObject);
            gameObject.SetActive(false);
        }
    }
}
