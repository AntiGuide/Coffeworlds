using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeControll : MonoBehaviour {

	public float eyeMove = -0.0001f;

	// Use this for initialization
	void Start () {
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		Vector2 localPosition = gameObject.transform.localPosition;
		localPosition.x = (Mathf.Abs (angle) + 90) * eyeMove;
		transform.localPosition = localPosition;

	}
	
	// Update is called once per frame
	void Update () {
		var dir = Input.mousePosition - Camera.main.WorldToScreenPoint (transform.position);
		var angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

		Vector2 localPosition = gameObject.transform.localPosition;
		localPosition.x = (Mathf.Abs (angle) - 90) * eyeMove;
		transform.localPosition = localPosition;
	}
}
