using Kuhpik;
using UnityEngine;

public class EnemyHealthComponent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionVFX;
    [SerializeField] private ParticleSystem _bulletExplosionVFX;

    private int _health;
    private bool _isDestroy;

    public void AddHealth(int health)
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _bulletExplosionVFX.Play();

        if (_health <= 0 && _isDestroy == false)
        {
            _isDestroy = true;
            GameEvents.DestroyEnemy_E?.Invoke(1, gameObject.transform);

            _explosionVFX.transform.parent = null;
            _explosionVFX.Play();
            gameObject.SetActive(false);

            Bootstrap.Instance.GameData.Enemies.Remove(gameObject);
        }
    }
}
