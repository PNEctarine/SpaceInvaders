using System;
using UnityEngine;

[Serializable]
public struct Enemies
{
    public GameObject Enemy;
    public int health;
}

[CreateAssetMenu(menuName = "Config/EnemiesConfig")]
public class EnemiesConfig : ScriptableObject
{
    public Enemies[] Enemies;
}
