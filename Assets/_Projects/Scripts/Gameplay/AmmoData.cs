using JvLib.Pooling.Objects;
using UnityEngine;

public class AmmoData : PooledObject
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>())
            Deactivate();
    }
}
