using UnityEngine;

namespace Project.Gameplay
{
    public partial class GameplayServiceManager // Stage
    {
        [SerializeField] private Vector2 _MinBound;
        public Vector2 MinBound => _MinBound;
        [SerializeField] private Vector2 _MaxBound;
        public Vector2 MaxBound => _MaxBound;
    }
}
