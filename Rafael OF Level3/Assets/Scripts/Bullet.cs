using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rig;

    public float damage = 1;

    public AudioSource audioSource;
    public AudioClip hitSFX;
    public GameObject hitFX;
    public float lifeTime = 5;

    void Start()
    {
        Invoke(nameof(AutoDestroy), lifeTime);
    }

    void FixedUpdate()
    {
        if (rig.linearVelocity.sqrMagnitude > 0.01f) transform.forward = rig.linearVelocity.normalized;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().GetHit(damage);
        }

        if(hitFX) Instantiate(hitFX, transform.position, transform.rotation);
        if(hitSFX) audioSource.PlayOneShot(hitSFX);
        
        AutoDestroy();
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
}