using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Transform playerTransform;
	float camX;
	float camY;

	// Use this for initialization
	void Start () {
		playerTransform = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		//rechts x = 7.32
		//links x = -7.32
		//oben y = 10.24
		//unten y = -10.24
		camX = playerTransform.localPosition.x;
		camY = playerTransform.localPosition.y;

		/*if (playerTransform.localPosition.x > 7.32) {
			camX = 7.32f;
		}else if(playerTransform.localPosition.x < -7.32){
			camX = -7.32f;
		}

		if (playerTransform.localPosition.y > 10.24) {
			camY = 10.24f;
		}else if(playerTransform.localPosition.y < -10.24){
			camY = -10.24f;
		}*/

		transform.localPosition = new Vector3 (camX, camY, transform.localPosition.z);
	}

	void LateUpdate(){
		
	}
}
