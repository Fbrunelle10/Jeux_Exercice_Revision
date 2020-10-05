using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public int lifeSpan = 5;
    public int bulletSpeed = 1;
    private float timeLeftToLive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        timeLeftToLive = lifeSpan;
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 0.1f * bulletSpeed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        Damageable damageableObject = collision.GetComponent<Damageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(1);
        }
    }
}
