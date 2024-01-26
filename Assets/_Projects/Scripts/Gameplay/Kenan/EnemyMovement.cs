using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class EnemyMovement : MonoBehaviour
{
    private readonly float _Min, _Max;

    [SerializeField] private AnimationCurve _AnimationCurve;

    [SerializeField] float _Duration;
    float _Time;

    private void Update()
    {
        _Time++;
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.position = new Vector3(0, 0, _Min + (_Max - _Min) * _AnimationCurve.Evaluate01(_Time / _Duration));
    }
}