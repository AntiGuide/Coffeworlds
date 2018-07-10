using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlipper : MonoBehaviour {

	public float shootingRate = 0.25f;
	private float shotCooldown;
	private float overheatingTime;
	private bool isOverheated;
	private OverheatUIControll heatUI;
	public Transform bulletPrefab;
	public bool shooting;
	public int bulletSpeed;
	public float maxHookDistance = 30.0f;
	public float timeUntilOverheat = 5.0f;


	// Use this for initialization
	void Start () {
		shotCooldown = 0f;
		overheatingTime = 0f;
		isOverheated = false;
		heatUI = GameObject.Find("Canvas/FlameContainer/Flame").GetComponent<OverheatUIControll> ();
	}
	
	// Update is called once per frame
	void Update () {
		shotCooldown -= Time.deltaTime;

		if(shooting && !isOverheated){
			overheatingTime += Time.deltaTime;
			if (overheatingTime < timeUntilOverheat) {
				FireWeapon ();
			}else{
				isOverheated = true;
			}
		}else{
			overheatingTime -= Time.deltaTime;
			if (overheatingTime <= 0) {
				isOverheated = false;
			}
		}
		if (overheatingTime < 0) {
			overheatingTime = 0f;
		}

		heatUI.updateOverheating (overheatingTime / timeUntilOverheat);
	}

	public void flipGun(){
		Vector2 localScale = gameObject.transform.localScale;
		localScale.y *= -1;
		transform.localScale = localScale;
	}

	void FireWeapon(){
		if(shotCooldown <= 0){
			var bullet = Instantiate (bulletPrefab) as Transform;
			bullet.position = transform.position;
			MoveScript move = bullet.gameObject.GetComponent<MoveScript> ();
			bullet.localRotation = this.transform.parent.localRotation;

			move.direction.x = bulletSpeed * Mathf.Cos (Mathf.Deg2Rad * transform.parent.localRotation.eulerAngles.z);
			move.direction.y = bulletSpeed * Mathf.Sin (Mathf.Deg2Rad * transform.parent.localRotation.eulerAngles.z);

			shotCooldown = shootingRate;
		}
	}

	Vector2 getHookHit(){
		float direction = Mathf.Deg2Rad * transform.parent.localRotation.eulerAngles.z;
		Debug.Log (transform.ToString ());
		//RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Mathf.Cos (direction), Mathf.Sin (direction)) * maxHookDistance,maxHookDistance,0);
		RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, new Vector2(Mathf.Cos (direction), Mathf.Sin (direction)) * maxHookDistance, maxHookDistance);
		Debug.DrawRay (transform.position, new Vector3(Mathf.Cos (direction), Mathf.Sin (direction),0) * maxHookDistance,Color.red,10.0f, false);
		//Debug.Log ((new Vector2(Mathf.Cos (direction), Mathf.Sin (direction)) * maxHookDistance).ToString ());
		for (int i = 0; i < hit.Length; i++) {
		
			if (hit[i].transform.gameObject.layer == 10) {
				Debug.Log (hit[i].collider.name + " " + hit[i].collider.gameObject.layer);
				return hit[i].point;
			}


		}
		return Vector2.zero;

	}


}
