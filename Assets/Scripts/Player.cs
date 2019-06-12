using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Gun gun;

	public GameObject bullet;
	public GameObject bullet2;
	public GameObject bullet3;
	public GameObject smoke;

	public GameObject muzzleFlash;
	public CameraShake cameraShake;
	Vector3 mouseDirection;
	float mouseDistance;

	public float health = 100f;
	public float maxHealth = 100f;
	public float stamina = 100f;
	public float maxStamina = 100f;
	public float speed = 5f;

	public Transform crosshair;

	float Angle(Vector3 u, Vector3 v) {
		return Mathf.Atan2(v.y - u.y, v.x - u.x);
	}

	Vector2 Ang2Vec(float angle) {
		return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}

	void Start() {
		Cursor.visible = false;
	}

	void Update() {

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float angle = Angle(transform.position, mousePos);
		mouseDirection = Ang2Vec(angle);
		mouseDistance = Vector3.Distance(transform.position, mousePos);
		Camera.main.transform.parent.parent.position = this.transform.position + -Vector3.forward + mouseDirection * mouseDistance * 0.15f;
		crosshair.position = mousePos;

		gun.lookDirection = new Vector2(Mathf.Abs(mouseDirection.x), (mouseDirection.x > 0f ? 1f : -1f) * mouseDirection.y);

		if (-Mathf.PI * 0.5f < angle && angle < Mathf.PI * 0.5f) {
			transform.localScale = new Vector3(-1, 1, 1);
		} else {
			transform.localScale = Vector3.one;
		}

		if (Input.GetKey(KeyCode.Mouse0)) {
			GetComponent<Rigidbody2D>().AddForce(-mouseDirection * 100f);
			gun.Shoot(mouseDirection);

			Instantiate(muzzleFlash, transform.position + mouseDirection * 0.3f + -Vector3.forward, Quaternion.identity);
			cameraShake.Shoot(Random.insideUnitCircle.normalized);

		}
	}


	void TakeDamage(float damage) {
		health -= damage;
		health = Mathf.Clamp(health, 0f, maxHealth);
	}

}
