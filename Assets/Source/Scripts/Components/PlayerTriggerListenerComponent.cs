using Kuhpik;
using UnityEngine;

public class PlayerTriggerListenerComponent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosionVFX;

    private const string _enemyLayerName = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_enemyLayerName))
        {
            _explosionVFX.transform.parent = null;
            _explosionVFX.Play();
            gameObject.SetActive(false);

            Bootstrap.Instance.ChangeGameState(GameStateID.Lose);
        }

        else if (collision.TryGetComponent(out WeaponDropComponent weaponDropComponent))
        {
            GameEvents.TakeWeapon_E?.Invoke(weaponDropComponent.WeaponIndex);
            Destroy(weaponDropComponent.gameObject);
        }
    }
}
