 
 /*Shooter.cs
  version 1.0 - August 7, 2015
  version 1.0.1 - february 7, 2017

  Copyright (C) 2015 Wasabi Applications Inc.
   http://www.wasabi-applications.co.jp/
*/

using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public Camera cameraForShooter;
	public GameObject ballPrefab;
	public Transform shotPoint;
	
	public float targetZ = 12.0f;			//screen point z to world point
	public float shotPowerMin = 3.0f;		//minimum shot power
	public float shotPowerMax = 12.0f;		//maximum shot power
	public float offsetY = 100.0f;			//offset Y for trajectory
	public float shotTimeMin = 0.2f;		//minimum time till to release finger
	public float shotTimeMax = 0.55f;		//maximum time till to release finger
	public float torque = 30.0f;			//torque (backspin)

	public float offsetZShotPoint = 1.0f;	//for rolling ball
	public float powerToRoll = 2.0f;		//for rolling ball
	public float timeoutForShot = 5.0f;		//for error handling

	// for demo
	public float shotPower {get; private set;}		//shot power (initial velocity)
	public Vector3 direction {get; private set;}	//shot direction (normalized)


	GameObject objBall;
	Rigidbody ballRigidbody;
	float startTime;

	Vector2 touchPos;
	
	enum ShotState {
		Charging,					//before shot (rolling)
		Ready,						//ready
		DirectionAndPower			//on swiping
	}
	
	ShotState state = ShotState.Charging;



	// Use this for initialization
	void Start () {
		touchPos.x = -1.0f;
	}



	// Update is called once per frame
	void Update () {				
		if (state == ShotState.Charging) {
			ChargeBall();
			CheckTrigger();

		} else if (state == ShotState.Ready) {
			CheckTrigger();

		} else if (state == ShotState.DirectionAndPower) {
			CheckShot();
		}
	}



	void FixedUpdate () {
		if (state != ShotState.Charging) {
			ballRigidbody.velocity = Vector3.zero;
			ballRigidbody.angularVelocity = Vector3.zero;
		}
	}


	
	void ChargeBall () {
		if (objBall == null) {
			objBall = (GameObject)Instantiate(ballPrefab);
			objBall.AddComponent<ShotBall>();
			ballRigidbody = objBall.GetComponent<Rigidbody>();
						
			Vector3 shotPos = shotPoint.transform.localPosition;
			shotPos.z -= offsetZShotPoint;
			objBall.transform.position = shotPoint.transform.TransformPoint(shotPos);
			objBall.transform.eulerAngles = shotPoint.transform.eulerAngles;
			ballRigidbody.velocity = Vector3.zero;

			ballRigidbody.AddForce(shotPoint.transform.TransformDirection(new Vector3 (0.0f, 0.0f, powerToRoll)), ForceMode.Impulse);
		}
		

		
		float dis = Vector3.Distance(shotPoint.transform.position, objBall.transform.position);
		if (dis <= 0.2f) {
			state = ShotState.Ready;
			objBall.transform.position = shotPoint.transform.position;
		}
	}



	void CheckTrigger () {
		if (touchPos.x < 0) {
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = cameraForShooter.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit, 100)) {
					ShotBall sb = hit.collider.transform.GetComponent<ShotBall>();
					if (sb != null && !sb.isActive) {
						sb.ChangeActive();
						touchPos = Input.mousePosition;
						shotPower = 0.0f;
					}
				}
			}
		} else {
			if (touchPos.x != Input.mousePosition.x || touchPos.y != Input.mousePosition.y) {
				touchPos.x = -1.0f;
				startTime = Time.time;
				state = ShotState.DirectionAndPower;
			}
		}
	}

	

	void CheckShot () {
		float elapseTime = Time.time - startTime;
		
		if (Input.GetMouseButtonUp (0)) {
			if (objBall != null) {
				ShootBall(elapseTime);
			}
			
			state = ShotState.Charging;
			objBall = null;
		}

		if (timeoutForShot < elapseTime) {
			Destroy (objBall);
			state = ShotState.Charging;
			objBall = null;
		}
	}


	void ShootBall (float elapseTime) {

		if (elapseTime < shotTimeMin) {
			shotPower = shotPowerMax;
		} else if (shotTimeMax < elapseTime) {
			shotPower = shotPowerMin;
		} else {
			float tmin100 = shotTimeMin * 10000.0f;
			float tmax100 = shotTimeMax * 10000.0f;
			float ep100 = elapseTime * 10000.0f;
			float rate = (ep100 - tmin100) / (tmax100 - tmin100);
			shotPower = shotPowerMax - ((shotPowerMax - shotPowerMin) * rate);
		}

		Vector3 screenPoint = Input.mousePosition;
		screenPoint.z = targetZ;
		Vector3 worldPoint = cameraForShooter.ScreenToWorldPoint (screenPoint);

		worldPoint.y += (offsetY / shotPower);

		direction = (worldPoint - shotPoint.transform.position).normalized;
		
		ballRigidbody.velocity = direction * shotPower;
		ballRigidbody.AddTorque (-shotPoint.transform.right * torque);

	}
	


}
