using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public int damage = 1;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20); //Zerstört Objekt nach 20 Sekunden
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag.Equals ("Enemy")){
			PlayerHealth ph = col.gameObject.GetComponent<PlayerHealth> ();
			ph.subLife (damage);
		}else if(col.tag.Equals ("Ground")){
			Destroy (gameObject);
		}
	}



}
