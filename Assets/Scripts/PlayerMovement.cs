using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerJumpPower = 1250;
	public float teleportDistance = 5.0f;
	public LayerMask TerrainMask;
	public bool movementBlocked;

	private FlashController flashController;
	private float moveX;
	private PlayerHealth health;

	void Start(){
		flashController = GameObject.Find("Canvas/Flashes").GetComponent<FlashController> ();
		health = gameObject.GetComponent<PlayerHealth> ();
	}

	void Update () {
		if(!movementBlocked){
			PlayerMove ();
		}
	}

	void PlayerMove(){
		moveX = Input.GetAxis ("Horizontal");
		if(Input.GetButtonDown ("Jump") && IsGrounded()){
			Jump ();
		}
		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}

/*	void FlipPlayer(){
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}*/

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Enemy"){
			health.Die ();
		}

	}

	bool IsGrounded() {

		float distance = 0.4f;
		RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, distance);

		for (int i = 0; i < hit.Length; i++) {
			if (hit[i].transform.gameObject.layer == 10) {
				return true;
			}
		}
		return false;
	}

	public void FireTeleport(Vector2 direction){
		if (flashController.useFlash()) {
			
				RaycastHit2D rayHit = Physics2D.Raycast(transform.position,	direction, teleportDistance, TerrainMask);
				if (rayHit){
					transform.Translate(direction * rayHit.distance);
				}else{
					transform.Translate(direction * teleportDistance);
				}
				
				if ((direction.y > 0 && gameObject.GetComponent<Rigidbody2D> ().velocity.y < 0) || (direction.y < 0 && gameObject.GetComponent<Rigidbody2D> ().velocity.y > 0)) {
					gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (gameObject.GetComponent<Rigidbody2D> ().velocity.x, 0f);
				}
			}

		}
}
