using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControll : MonoBehaviour {

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public bool portingBlocked;
	public bool shootingBlocked;

	GunFlipper flipper;
	PlayerMovement playerMovement;
	GameObject playerInvis;


	void OnMouseEnter(){
		Cursor.SetCursor(cursorTexture, new Vector2 (cursorTexture.width / 2, cursorTexture.height / 2), cursorMode);
	}

	void OnMouseExit(){
		Cursor.SetCursor (null, Vector2.zero, cursorMode);
	}

	// Use this for initialization
	void Start () {
		//flipper = this.transform.Find ("Gun").GetComponent<GunFlipper> ();
		flipper = GameObject.Find("Player/PlayerInvisible/Gun").GetComponent<GunFlipper> ();
		playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement> ();
		playerInvis = GameObject.Find ("Player/PlayerInvisible");

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Restart")) {
			SceneManager.LoadScene ("MainScene");
		}
		if (Input.GetMouseButtonDown(1) && !portingBlocked){
			float tmpPlayerRotation = Mathf.Deg2Rad * playerInvis.transform.localRotation.eulerAngles.z;
			playerMovement.FireTeleport (new Vector2(Mathf.Cos (tmpPlayerRotation),Mathf.Sin (tmpPlayerRotation)));
		}
	}

	void OnMouseDown(){
		if (!shootingBlocked) {
			flipper.shooting = true;
		}
	}

	void OnMouseUp(){
		flipper.shooting = false;
	}



}
