using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    public Vector3 startForce ; 

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce,ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
