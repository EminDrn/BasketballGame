using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUI : MonoBehaviour {

	//public Shooter shooter;
	public GoalArea goalArea;
	
	public Text textScore;
	public Text textShotPower;
	public Text textDirection;


	int tempScore = 0;
	float tempShotPower = 0.0f;
	Vector3 tempShotDir = Vector3.zero;



	// Update is called once per frame
	void Update () {
	
		// Score
		if (tempScore != goalArea.score) {
			tempScore = goalArea.score;
			textScore.text = tempScore.ToString();
		}


		// Shot Power
	//	if (tempShotPower != shooter.shotPower) {
	//		tempShotPower = shooter.shotPower;
			textShotPower.text = tempShotPower.ToString("0.000");
		}

		// Shot Direction
	//	if (tempShotDir != shooter.direction) {
	//		tempShotDir = shooter.direction;
	//		Quaternion q = Quaternion.Euler(-shooter.transform.eulerAngles);
	//		Vector4 org = new Vector4(tempShotDir.x, tempShotDir.y, tempShotDir.z, 1);
	//		Vector4 v = q * org;
	//		v.Normalize();
	//		textDirection.text = v.x.ToString("0.00") + ", " + v.y.ToString("0.00") + ", " + v.z.ToString("0.00");
		}
	//}



//	public void PushedResetButton () {
//		// restart
//		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
//	}
//}
