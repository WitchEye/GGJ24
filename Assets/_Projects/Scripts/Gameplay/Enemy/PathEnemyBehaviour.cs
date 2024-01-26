using JvLib.Services;
using UnityEngine;

namespace Project.Gameplay.Enemy
{
    public class PathEnemyBehaviour : AEnemyBehaviour<PathEnemyConfig>
    {
        [SerializeField] private AnimationCurve _XCurve;
        [SerializeField] private AnimationCurve _YCurve;
        [SerializeField] private AnimationCurve _RotationCurve;

        protected override void Update()
        {
            base.Update();
            
            Vector2 minBound = Svc.Gameplay.MinBound;
            Vector2 maxBound = Svc.Gameplay.MaxBound;
            
            float x = minBound.x + (maxBound.x - minBound.x) * _XCurve.Evaluate01(Time / Duration);
            float y = minBound.y + (maxBound.y - minBound.y) * _YCurve.Evaluate01(Time / Duration);

            float rot = _RotationCurve.Evaluate01(Time / Duration);

            transform.position = new Vector3(x, y, 0);
            transform.rotation = Quaternion.Euler(0, rot, 0);
        }
    }
}
