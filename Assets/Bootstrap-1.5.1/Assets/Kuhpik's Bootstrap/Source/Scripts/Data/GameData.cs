using System;
using UnityEngine;
using System.Collections.Generic;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public Vector2 InputVector;
        public Vector2 MaxTopLeft;

        public List<GameObject> Enemies = new List<GameObject>();
        public GameObject Player;
        public GameObject EnemiesSwarm;

        public Transform PlayerGamePoint;

        public int EnemiesCount;

        public float FirstEnemyX;
        public float EnemiesSpace;


        // Example (I use public fields for data, but u free to use properties\methods etc)
        // public float LevelProgress;
        // public Enemy[] Enemies;
    }
}