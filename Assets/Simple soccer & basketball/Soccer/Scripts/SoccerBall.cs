using UnityEngine;
using System.Collections;

public class SoccerBall : MonoBehaviour {
	
	//variables visible in the inspector
	public int Force;
	public float fadespeed;
	public int lifetime;
	public bool hasTriggered;
	
	//not visible in the inspector
	Vector3 startPos;
	bool decreaseAlpha;
	float alpha = 1f;
	
	void Update(){
	//decrease alpha color of the ball to fade it out
	if(decreaseAlpha){
	if(alpha > 0f){
	alpha -= Time.deltaTime * fadespeed;
	foreach(Material material in GetComponent<Renderer>().materials){
	material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
	}	
	}
	else{
	//if ball has faded, destroy it
	Destroy(gameObject);	
	}
	}	
	if(Soccer.gameOver){
	//also destroy it if game is over
	Destroy(gameObject);
	}	
	}
 
	void OnMouseDown(){
	//get soccer ball starting position when swiping
    startPos = Input.mousePosition;
    startPos.z = transform.position.z - Camera.main.transform.position.z;
    startPos = Camera.main.ScreenToWorldPoint(startPos);
	}
 
	void OnMouseUp() {
	//get soccer ball end position when swipe finished
    Vector3 endPos = Input.mousePosition;
    endPos.z = transform.position.z - Camera.main.transform.position.z;
    endPos = Camera.main.ScreenToWorldPoint(endPos);
	
	//get the proper direction and z force
    Vector3 force = endPos - startPos;
    force.z = force.magnitude;
    
	//check if you swiped (not just clicked) and if ball had not been fired already
	if(startPos != endPos && GetComponent<Rigidbody>().isKinematic == true){
	GetComponent<Rigidbody>().isKinematic = false;
    GetComponent<Rigidbody>().AddForce(force * Force);
	//destroy ball after some time and add a new one to shoot
	StartCoroutine(destroyBall());
	StartCoroutine(newBall());
	}
	}
	
	IEnumerator newBall(){
	//wait 0.3 seconds and spawn a new ball
	yield return new WaitForSeconds(0.3f);	
	Camera.main.GetComponent<Soccer>().spawnBall();
	}
	
	IEnumerator destroyBall(){
	//wait some seconds before destroying the ball
	yield return new WaitForSeconds(lifetime);
	//change material rendering mode to transparent for each material (to create fade effect)
	foreach(Material material in GetComponent<Renderer>().materials){
	material.SetFloat("_Mode", 3);
    material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
    material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
    material.SetInt("_ZWrite", 0);
    material.DisableKeyword("_ALPHATEST_ON");
    material.EnableKeyword("_ALPHABLEND_ON");
    material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
    material.renderQueue = 3000;
	}
	//actually start fading
	decreaseAlpha = true;
	}
}
