using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour {
	
	//how long are the particles in the scene
	public float lifetime;
	
	void Start () {
	//remove particles after lifetime
	Destroy(gameObject, lifetime);
	}
}
