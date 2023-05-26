using Kuhpik;
using UnityEngine;

public class WeaponDropoutSystem : GameSystem
{
    [SerializeField] private BulletsConfig _bulletsConfig;

    public override void OnInit()
    {
        GameEvents.DestroyEnemy_E += ChanceOfDrop;
    }

    private void ChanceOfDrop(int _, Transform enemyTransform)
    {
        int chance = Random.Range(0, 100);
        int chanceToDrop = 0;
        int[] chances = new int[_bulletsConfig.Bullets.Length + 1];

        for (int i = 0; i < _bulletsConfig.Bullets.Length; i++)
        {
            chanceToDrop += _bulletsConfig.Bullets[i].Chance;
            chances[i] = _bulletsConfig.Bullets[i].Chance;
        }

        chances[^1] = 100 - chanceToDrop;
        chanceToDrop = chances[0];

        int bulletIndex = 0;

        for (int i = 0; i < chances.Length; i++)
        {
            if (chance <= chanceToDrop)
            {
                bulletIndex = i;
                break;
            }

            chanceToDrop += chances[i + 1];
        }

        if (bulletIndex < _bulletsConfig.Bullets.Length)
        {
            GameObject bulletDrop = Instantiate(_bulletsConfig.Bullets[bulletIndex].Drop);
            bulletDrop.transform.position = enemyTransform.position;
            bulletDrop.GetComponent<WeaponDropComponent>().WeaponIndex = bulletIndex;
        }
    }
}
