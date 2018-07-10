using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControll : MonoBehaviour {
	
	bool gunFlipped;
	GunFlipper flipper;


	// Use this for initialization
	void Start () {
		flipper = this.transform.Find ("Gun").GetComponent<GunFlipper> ();
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		if(Mathf.Abs (angle) < 90){
			gunFlipped = false;
		}else{
			flipper.flipGun ();
			gunFlipped = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		RotateWeapon ();
	}

	void RotateWeapon(){
		var pos = Camera.main.WorldToScreenPoint (transform.position);
		var dir = Input.mousePosition - pos;
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		transform.localRotation = Quaternion.AngleAxis (angle, Vector3.forward);

		if(Mathf.Abs (angle) <= 90 && gunFlipped){
			flipper.flipGun ();
			gunFlipped = !gunFlipped;
		}else if(Mathf.Abs (angle) > 90 && !gunFlipped){
			flipper.flipGun ();
			gunFlipped = !gunFlipped;
		}
	}



}
