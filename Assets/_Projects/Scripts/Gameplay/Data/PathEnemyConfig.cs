using UnityEngine;

namespace Project.Gameplay
{
    public class PathEnemyConfig : AEnemyConfig
    {
        [SerializeField] private AnimationCurve _XMovement;
        [SerializeField] private AnimationCurve _YMovement;
        [SerializeField] private AnimationCurve _RotationMovement;
    }
}
