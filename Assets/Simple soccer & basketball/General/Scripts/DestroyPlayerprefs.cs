using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyPlayerprefs : MonoBehaviour {
	
	//bool visible in the inspector
	public bool destroyPlayerPrefs;

	void Start () {
	//if you want to destroy playerprefs, destroy them all 
	if(destroyPlayerPrefs){
	PlayerPrefs.DeleteAll();
	}
	}
}
