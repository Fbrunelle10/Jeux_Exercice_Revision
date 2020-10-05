using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerMovement : MonoBehaviour
{
    public float propellorSpeed = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            gameObject.transform.Rotate(new Vector3(Input.GetAxis("Jump") * propellorSpeed, 0, 0) * Time.deltaTime);
        }
    }
}
