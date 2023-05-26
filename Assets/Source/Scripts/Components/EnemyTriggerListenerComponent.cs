using Kuhpik;
using UnityEngine;

[RequireComponent(typeof(EnemyHealthComponent))]
public class EnemyTriggerListenerComponent : MonoBehaviour
{
    private EnemyHealthComponent _healthComponent;

    private void Awake()
    {
        _healthComponent = GetComponent<EnemyHealthComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerBulletComponent bulletComponent))
        {
            Destroy(bulletComponent.gameObject);
            _healthComponent.TakeDamage(bulletComponent.Damage);
        }

        if (collision.TryGetComponent(out EnemiesTargetComponent enemiesTargetComponent))
        {
            Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
        }
    }
}
