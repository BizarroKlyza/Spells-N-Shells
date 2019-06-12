using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	Vector2 direction = Vector2.zero;
	float rollStamina = 20f;
	float rollSpeed = 8f;
	float staminaRegen = 15;

	bool regenStopped = false;
	bool rolling = false;

	Rigidbody2D rb2d;
	Player player;

	IEnumerator Roll() {
		rb2d.velocity = direction * rollSpeed;
		rolling = true;
		yield return new WaitForSeconds(0.35f);
		rolling = false;
	}

	IEnumerator StopRegen() {
		regenStopped = true;
		yield return new WaitForSeconds(2f);
		regenStopped = false;
	}

	void Start() {

		rb2d = GetComponent<Rigidbody2D>();
		player = GetComponent<Player>();

	}

	void Update() {

		direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

		if (!rolling) {

			rb2d.velocity = direction * player.speed;
			if (Input.GetKeyDown(KeyCode.Space) && direction.magnitude > 0f) {
				if (player.stamina > 0f) {
					player.stamina -= rollStamina;
					StartCoroutine(Roll());
					StartCoroutine(StopRegen());
				}
			}
		}

		if (!regenStopped) {
			player.stamina += Time.deltaTime * staminaRegen;
			player.stamina = Mathf.Clamp(player.stamina, 0f, player.maxStamina);

		}


	}
}