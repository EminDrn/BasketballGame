using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	//variables visible in the inspector
	public int forceX;
	public int forceY;
	public int forceZ;
	
	//not visible in the inspector
	bool shooting;
	
	Vector3 start;
	Vector3 end;
	
	void Update(){
	//destroy ball if game is over
	if(Basketball.gameOver){
	Destroy(gameObject);
	}	
	}
 
	void OnMouseDown(){
	//set shooting true and save swipe starting point
	shooting = true;
	start = Input.mousePosition;
	}
 
	void OnMouseExit(){
	//if you don't hit the ball anymore, get position and use end position to get x shooting force
	if(Input.GetMouseButton(0) && shooting){
	end = Input.mousePosition;
    GetComponent<Rigidbody>().isKinematic = false;
	GetComponent<Rigidbody>().AddForce(new Vector3(((end.x - start.x) * forceX), forceY, forceZ));
	shooting = false;
	
	//after shooting, instantiate new ball and destroy this ball after 10 seconds
	StartCoroutine(newBall());
	Destroy(gameObject, 10);
	}
	}
	
	IEnumerator newBall(){
	//wait 0.3 seconds and spawn new ball. Destroy this script to make sure this ball is not interactive anymore
	yield return new WaitForSeconds(0.3f);	
	Camera.main.GetComponent<Basketball>();
	Destroy(GetComponent<Shooting>());
	}
}
