using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	public ParticleSystem psStar;


	public int score {get; private set;}


	// Use this for initialization
	void Start () {
		score = 0;
	}



	void OnTriggerEnter (Collider other) {
		ShotBall sb = other.GetComponent<ShotBall>();
		if (sb != null) {
			// Goal!!
			score++;
			psStar.Play();
		}
	}

}
