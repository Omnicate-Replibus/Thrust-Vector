using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb; 
    [SerializeField] float upThrust;
    [SerializeField] float rotateSpeed;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        upThrust = 2000f;
        rotateSpeed = 50;
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * upThrust * Time.deltaTime);
        }
    }
    
    void ProcessRotation()
    {

        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; //freezing general rotation to allow manual rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing general rotation so physics system can go nuts
    }
}
