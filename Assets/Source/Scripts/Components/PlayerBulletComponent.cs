using NaughtyAttributes;
using UnityEngine;

public class PlayerBulletComponent : MonoBehaviour
{
    [ReadOnly] public int Damage;
    [ReadOnly] public float Speed;

    private void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + Speed * Time.deltaTime);

        if (gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}
