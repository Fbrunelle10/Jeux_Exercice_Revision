using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, Damageable
{
    Rigidbody2D rigidbody;
    float playerSpeed = 100;
    public float fireDelay = 0.1f;
    private float delayBeforeNextFire = 0;
    public GameObject bulletPrefab;
    public GameObject deathEffect;

    int lifeTotal = 1;

    public AudioClip audioMusic;
    private SoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        soundPlayer = GameObject.FindObjectOfType<SoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            rigidbody.MovePosition(new Vector3(rigidbody.position.x, Mathf.Clamp((rigidbody.position.y + (Input.GetAxis("Vertical") * playerSpeed) * Time.deltaTime), -4.25f, 4.25f), transform.position.z));      
        }

        if (Input.GetAxis("Fire1") != 0)
        {
            ProcessFire();
        }
    }

    void ProcessFire()
    {
        delayBeforeNextFire -= Time.deltaTime;

        if (delayBeforeNextFire <= 0)
        {
            ShootBullet();
            delayBeforeNextFire = fireDelay;
        }
    }

    private void ShootBullet()
    {
        Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageableObject = gameObject.GetComponent<Damageable>();

        if (damageableObject != null)
        {
            damageableObject.TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;

        if (lifeTotal <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        soundPlayer.PlayMusic(audioMusic);
        Destroy(gameObject);
    }
}
