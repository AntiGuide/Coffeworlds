using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatUIControll : MonoBehaviour {

	RectTransform flameBar;

	// Use this for initialization
	void Start () {
		flameBar = gameObject.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateOverheating(float percent){
		flameBar.localScale = new Vector3 (percent, flameBar.localScale.y, flameBar.localScale.z);
	}
}
