using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rig;

    void FixedUpdate()
    {
        if (rig.linearVelocity.sqrMagnitude > 0.01f) transform.forward = rig.linearVelocity.normalized;
    }
}