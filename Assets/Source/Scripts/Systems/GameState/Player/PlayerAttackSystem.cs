using Kuhpik;
using UnityEngine;

public class PlayerAttackSystem : GameSystem
{
    [SerializeField] private BulletsConfig _bulletsConfig;

    private float[] _coolDown;
    private int[] _bulletsCount;

    public override void OnInit()
    {
        GameEvents.TakeWeapon_E += TakeWeapon;

        _coolDown = new float[_bulletsConfig.Bullets.Length];
        _bulletsCount = new int[_bulletsConfig.Bullets.Length];

        _bulletsCount[0] = 1;
    }

    public override void OnUpdate()
    {
        for (int i = 0; i < _bulletsConfig.Bullets.Length; i++)
        {
            if (_bulletsCount[i] <= 0)
                continue;

            if (_coolDown[i] == 0)
            {
                float positionX = -BulletDirection(i);

                for (int b = 0; b < _bulletsCount[i]; b++)
                {
                    GameObject bullet = Instantiate(_bulletsConfig.Bullets[i].BulletComponent.gameObject);
                    bullet.GetComponent<PlayerBulletComponent>().Speed = _bulletsConfig.Bullets[i].FlightSpeed;

                    bullet.transform.position = game.Player.transform.position + new Vector3(positionX, 0, 0);
                    positionX += 0.2f;
                }
            }

            else if (_coolDown[i] >= _bulletsConfig.Bullets[i].CoolDown)
            {
                _coolDown[i] = 0;
                return;
            }

            _coolDown[i] += Time.deltaTime;
        }
    }

    private float BulletDirection(int index)
    {
        float offsetX;

        if ((_bulletsCount[index] - 1) % 2 == 0)
        {
            offsetX = (_bulletsCount[index] - 1) / 2 * 0.2f;
        }

        else
        {
            offsetX = 0.2f / 2 * (_bulletsCount[index] - 1);
        }

        return offsetX;
    }

    public void TakeWeapon(int bulletIndex)
    {
        _bulletsCount[bulletIndex] += 1;
    }
}
