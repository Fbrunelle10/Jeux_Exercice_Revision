using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, Damageable
{
    private Rigidbody2D rigidBody;
    public int enemySpeed = 50;
    private GameObject player;
    public int lifeTotal = 1;
    public GameObject deathEffect;

    public AudioClip audioMusic;
    private SoundPlayer soundPlayer;

    float liveTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        soundPlayer = GameObject.FindObjectOfType<SoundPlayer>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            rigidBody.MovePosition(Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x - 50, transform.position.y, transform.position.z), enemySpeed * Time.deltaTime));
        }
        
        if (liveTime <= 0)
        {
            Die();
        }
        else
        {
            liveTime -= Time.deltaTime;
        }


    }

    public void Die()
    {
        Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
        if (liveTime > 0)
        {
            soundPlayer.PlayMusic(audioMusic);
        }
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;

        if (lifeTotal <= 0)
        {
            Die();
        }
    }
}
