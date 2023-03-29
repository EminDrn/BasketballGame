using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopZıplama : MonoBehaviour
{
    private Rigidbody rb;
    public float topSpeed;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
  }


    // Update is called once per frame
    void Update()
    {
        speed = ballSpeed();
     if(Input.GetKey(KeyCode.Space)){
            transform.Translate(-0.71f*Time.deltaTime,0.6f,0);


    }
    }
    public float ballSpeed(){
        float speed = rb.velocity.magnitude;
        speed *=1.5f;
        if(speed > topSpeed)
        rb.velocity = (topSpeed / 3.6f) * rb.velocity.normalized;
        return speed;
    }
    }
