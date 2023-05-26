using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static Action<int, Transform> DestroyEnemy_E;
    public static Action<int> TakeWeapon_E;
    public static Action<GameObject> ReturnEnemyBullet_E;

    public static void ClearEvents()
    {
        DestroyEnemy_E = null;
        TakeWeapon_E = null;
        ReturnEnemyBullet_E = null;
    }
}
