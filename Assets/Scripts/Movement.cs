using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5f;

	Vector2 direction = Vector2.zero;

	Rigidbody2D rb2d;

	void Start() {

		rb2d = this.GetComponent<Rigidbody2D>();
	}

	void Update() {

		if (Input.GetKey(KeyCode.W)) {
			direction.y = 1;
		} else if (Input.GetKey(KeyCode.S)) {
			direction.y = -1;
		} else { direction.y = 0; }

		if (Input.GetKey(KeyCode.A)) {
			direction.x = -1;
		} else if (Input.GetKey(KeyCode.D)) {
			direction.x = 1;
		} else { direction.x = 0; }

		//rb2d.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Impulse);

		//this.transform.position += (Vector3)direction * speed * Time.deltaTime;

		rb2d.velocity = direction * speed * Time.deltaTime;
	}
}
