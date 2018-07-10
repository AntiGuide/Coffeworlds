using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEventController : MonoBehaviour {

	private int remainingEnemys;
	private TimeController tc;
	private GameObject highscores;
	private Highscores scorelist;

	// Use this for initialization
	void Start () {
		remainingEnemys = 21;
		tc = GameObject.Find("Canvas/Time").GetComponent<TimeController> ();
		highscores = GameObject.Find("Canvas/Highscores");
		scorelist = highscores.GetComponent<Highscores> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int subRemainingEnemys(){
		remainingEnemys--;
		if (remainingEnemys == 0) {
			scorelist.addTime(tc.pauseTimer ());
			transform.localScale = Vector3.one;
			highscores.transform.localScale = Vector3.one;

		}
		return remainingEnemys;
	}
}
