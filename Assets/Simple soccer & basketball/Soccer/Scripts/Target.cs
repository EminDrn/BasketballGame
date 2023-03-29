using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
	
	//variables visible in the inspector
	public OptionsList addScore;
	public enum OptionsList{
	ninetyPoints, 
	sixtyPoints,
	thirtyPoints,
	tenPoints
	}
	
	public ParticleSystem effect1;
	public ParticleSystem effect2;
	public ParticleSystem effect3;
	
	//check if this part of the goal object gets triggered
	void OnTriggerEnter(Collider other){
	//if the ball didn't score points already, check the amount of points and add them to the total score
	if(other.GetComponent<SoccerBall>().hasTriggered == false){
	if(addScore == OptionsList.ninetyPoints){
	Soccer.score += 90;
	//add nice scoring effect
	Instantiate(effect1, other.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
	}
	if(addScore == OptionsList.sixtyPoints){
	Soccer.score += 60;
	//add nice scoring effect
	Instantiate(effect2, other.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
	}
	if(addScore == OptionsList.thirtyPoints){
	Soccer.score += 30;
	//add nice scoring effect
	Instantiate(effect3, other.gameObject.transform.position, Quaternion.Euler(-90, 0, 0));
	}
	if(addScore == OptionsList.tenPoints){
	Soccer.score += 10;
	}
	//make sure the ball can't score more points
	other.GetComponent<SoccerBall>().hasTriggered = true;
	}
	}
}
