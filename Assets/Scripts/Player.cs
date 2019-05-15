using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bullet;
	float playerAngle;

	float Angle(Vector3 u, Vector3 v) {
		//return Vector3.Angle(Vector3.right, v - u) * ((v.y < u.y) ? -1f : 1f);
		return Mathf.Rad2Deg * Mathf.Atan2(v.y-u.y, v.x-u.x);
	}

	void Start() {

	}

	void Update() {

		//this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		playerAngle = Angle(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

		Debug.Log(playerAngle);

		if (-90f < playerAngle && playerAngle < 90f) {
			this.transform.localScale = new Vector3(-1, 1, 1);
		} else {
			this.transform.localScale = Vector3.one;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0)) {

			GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
			bulletClone.GetComponent<Bullet>().Spawn(playerAngle);

		}
	}

	/*float PPU = 16;

	void LateUpdate() {
		Vector3 position = transform.localPosition;

		position.x = (Mathf.Round(transform.position.x * PPU) / PPU) - transform.position.x;
		position.y = (Mathf.Round(transform.position.y * PPU) / PPU) - transform.position.y;

		transform.localPosition = position;
	}*/
}
