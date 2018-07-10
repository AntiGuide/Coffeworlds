using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int health = 3;
	private GameObject[] heathIcons;
	private EndEventController eec;
	private RectTransform rectTrans;

	// Use this for initialization
	void Start () {
		eec = GameObject.Find ("Canvas/YouWon").GetComponent<EndEventController> ();
		rectTrans = GameObject.Find ("Canvas/YouWon").GetComponent<RectTransform> ();
		rectTrans.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die(){
		SceneManager.LoadScene ("MainScene");
	}

	public void subLife(int lifeToSub){
		health -= lifeToSub;
		UpdateLifeArmor ();
	}

	private void UpdateLifeArmor (){
		if (health <= 0) {
			gameObject.SetActive (false);
			eec.subRemainingEnemys ();
		}
	}
}
