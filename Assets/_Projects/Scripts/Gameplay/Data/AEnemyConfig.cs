using JvLib.Data;
using UnityEngine;

namespace Project.Gameplay
{
    public class AEnemyConfig : DataEntry
    {
        [SerializeField] private float _Duration;
        public float Duration => _Duration;
    }
}
