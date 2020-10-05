using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    ParticleSystem smoke;
    GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        smoke = gameObject.GetComponent<ParticleSystem>();
        smoke.Stop();

        plane = GameObject.FindGameObjectsWithTag("plane")[0];
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetAxis("Jump") != 0)
        {
            if (!smoke.isPlaying)
            {
                smoke.Play();
            }
        }
        else
        {
            if (smoke.isPlaying)
            {
                smoke.Stop();
            }
        }
    }
}
