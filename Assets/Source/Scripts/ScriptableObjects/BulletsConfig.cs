using System;
using UnityEngine;

[Serializable]
public struct Bullet
{
    public string Name;

    public float FlightSpeed;
    public float CoolDown;

    public int Chance;
    public int Damage;

    public PlayerBulletComponent BulletComponent;
    public GameObject Drop;
}

[CreateAssetMenu(menuName = "Config/BulletsConfig")]
public class BulletsConfig : ScriptableObject
{
    public Bullet[] Bullets;
}
