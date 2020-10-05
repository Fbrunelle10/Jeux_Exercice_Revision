using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float planeTrust = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            rigidbody.AddRelativeForce(new Vector3(planeTrust, 0, 0) * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            rigidbody.AddTorque(new Vector3(0, 0, Input.GetAxis("Vertical") * 1000) * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            rigidbody.AddTorque(new Vector3(Input.GetAxis("Horizontal") * 1000, 0, 0) * Time.deltaTime);
        }
    }
}
