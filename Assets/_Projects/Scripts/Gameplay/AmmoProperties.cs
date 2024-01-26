using JvLib.Data;
using UnityEngine;

public partial class AmmoProperties : ScriptableSingletonObject<AmmoProperties>
{
    public Vector3 Direction;
    public Vector3 StartPosition;
    public float StartSpeed;
    public float Mass;
    public float Drag;
}
