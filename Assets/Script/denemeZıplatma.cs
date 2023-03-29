using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class denemeZıplatma : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float yspeed = 10f; 
    Rigidbody rb;
   
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
           rb.AddForce(new Vector3(-speed,yspeed,0), ForceMode.Impulse); 
        }
       // void OnTriggerEnter(Collider collider){
        //     if(collider.tag == "Pota"){
        //   rb.AddForce(new Vector3(-speed,speed,0), ForceMode.Impulse); 
           

       // }
        //}

        //if(collider.tag == "Pota"){
            //void OnTriggerEnter(Collider collider){
            //  if(collider.tag == "Pota"){
         //  rb.AddForce(new Vector3(speed,speed,0), ForceMode.Impulse); 
       // }
     //   }
       // }
    } 
    private void OnTriggerEnter(Collider other)
    {
        speed = speed * -1;
    }
}  
