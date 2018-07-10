using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : MonoBehaviour {

	Transform[] flashes;
	int aktFlashCount;
	private int flashCount;
	public float regenTime = 1f;
	private float prvRegenTime;

	// Use this for initialization
	void Start () {
		flashes = gameObject.GetComponentsInChildren<Transform>();
		flashCount = flashes.Length - 1;
		aktFlashCount = flashCount;
		prvRegenTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		prvRegenTime += Time.deltaTime;
		while (prvRegenTime > regenTime && aktFlashCount < 3) {
			prvRegenTime -= regenTime;
			aktFlashCount++;
			flashes [aktFlashCount].gameObject.SetActive (true);
		}
		if (aktFlashCount >= 3) {
			prvRegenTime = 0f;
		}
	}

	public bool useFlash(){
		if (aktFlashCount > 0) {
			flashes [aktFlashCount].gameObject.SetActive (false);
			aktFlashCount--;
			return true;
		}else{
			return false;
		}
	}
}
