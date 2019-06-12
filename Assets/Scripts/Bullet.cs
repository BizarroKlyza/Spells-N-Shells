using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
	float speed = 10f;
	float timer = 0f;
	float lifetime = 3f;

	void Start() {
		transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		transform.localScale *= Random.Range(0.8f, 1.2f);
		
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= lifetime) {
			Destroy(gameObject);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			Destroy(gameObject);
		}
	}

	public void Spawn(float angle) {

		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * speed;
	}
}
