
using UnityEngine;
using System.Collections;

public class Topyondegistirme : MonoBehaviour {
 public float speed;
	
	
	Rigidbody rb; 
	
	public ParticleSystem effect;

	// Use this for initialization
	void Start () {


	}



	void OnTriggerEnter(){
	//add 1 point to the main basketball script
	
	 rb.AddForce(new Vector3(speed,speed,0), ForceMode.Impulse); 
	  transform.Translate(0.71f*Time.deltaTime,  0.6f,0);
	//instantiate effect in the hoop
	if(Input.GetKey(KeyCode.Space)){
            transform.Translate(-0.71f*Time.deltaTime,  0.6f,0);
		
		}
		
	}
}



	



