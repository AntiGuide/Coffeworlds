using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {

	Text timeText;
	float timeSaver;
	bool timerStarted;

	// Use this for initialization
	void Start () {
		timeText = gameObject.GetComponent<Text> ();
		timeSaver = 0f;
	}

	// Update is called once per frame
	void Update () {
		if (timerStarted) {
			try{
				timeSaver += Time.deltaTime;
			}catch{
				this.restartTimer();
			}
			timeText.text = TimeToString(timeSaver);

		}
	}

	string TimeToString(float time){
		string strReturn = "";
		if(time >= 3600){
			strReturn = ((int)time / 3600).ToString ("D2") + ":" + ((int)((time % 3600) / 60)).ToString ("D2") + ":" + ((int)time % 60).ToString ("D2") + "." + ((int)((time % 1) * 1000)).ToString ("D3");
		}else{
			strReturn = ((int)time / 60).ToString ("D2") + ":" + ((int)time % 60).ToString ("D2") + "." + ((int)((time % 1) * 1000)).ToString ("D3");
		}

		return strReturn;

	}

	public void startTimer(){
		timerStarted = true;
	}

	public float resetTimer(){
		timeSaver = 0f;
		return timeSaver;
	}

	public float restartTimer(){
		timeSaver = 0f;
		timerStarted = true;
		return timeSaver;
	}

	public float pauseTimer(){
		timerStarted = false;
		return timeSaver;
	}
}