using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

	float[] times;

	void Awake(){
	}
	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = Vector3.zero;
		if (PlayerPrefs.HasKey ("Score0") && PlayerPrefs.HasKey ("Score1") && PlayerPrefs.HasKey ("Score2") && PlayerPrefs.HasKey ("Score3") && PlayerPrefs.HasKey ("Score4")) {
			times = new float[5];
			for (int i = 0; i < times.Length; i++) {
				times [i] = PlayerPrefs.GetFloat ("Score"+i);
			}
		}else{
			times = new float[5];
			for (int i = 0; i < times.Length; i++) {
				times [i] = -1;
				PlayerPrefs.SetFloat ("Score"+i,times[i]);
			}
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addTime(float time){
		if (time > times[times.Length - 1] && times[times.Length - 1] != -1) {
			return;
		}else{
			for (int i = times.Length-2; i >= 0; i--) {
				if (i == 0 && (times [i] == -1 || time < times [i])) {
					insertTime (i, time);
					break;
				}
				if (time > times [i] && times [i] != -1) {
					insertTime (i+1, time);
					break;
				}
			}
			string output = "";
			for (int i = 0; i < times.Length; i++) {
				if (times[i] != -1) {
					output += (i+1) + ". " + ((int)times[i] / 60).ToString ("D2") + ":" + ((int)times[i] % 60).ToString ("D2") + "." + ((int)((times[i] % 1) * 1000)).ToString ("D3");
					if (i != times.Length - 1 && times[i+1] != -1) {
						output += "\r\n";
					}
				}
			}
			gameObject.GetComponent<Text> ().text = output;
		}
	}

	void insertTime(int platz, float timeToInsert){
		float tmpTime;
		for (int i = platz; i < times.Length; i++) {
			tmpTime = times [i];
			times [i] = timeToInsert;
			PlayerPrefs.SetFloat ("Score"+i,times[i]);
			timeToInsert = tmpTime;
		}
	}
}
