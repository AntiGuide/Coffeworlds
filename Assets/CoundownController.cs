using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoundownController : MonoBehaviour {

	private float timeInCountown;
	private PlayerMovement player;
	private MouseControll aimOverlay;
	private TimeController tc;
	private bool firstCall = true;

	// Use this for initialization
	void Start () {
		timeInCountown = 5f;
		player = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
		player.movementBlocked = true;
		aimOverlay = GameObject.Find ("AimOverlay").GetComponent<MouseControll> ();
		aimOverlay.portingBlocked = true;
		aimOverlay.shootingBlocked = true;
		tc = GameObject.Find ("Canvas/Time").GetComponent<TimeController> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeInCountown -= Time.deltaTime;
		if (timeInCountown <= 0 && firstCall) {
			firstCall = false;
			transform.localScale = Vector3.zero;
			tc.startTimer ();
			player.movementBlocked = false;
			aimOverlay.portingBlocked = false;
			aimOverlay.shootingBlocked = false;
		}else{
			gameObject.GetComponent<Text> ().text = ((int)timeInCountown+1).ToString ();
		}
	}
}
