using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour {

	float timer = 0f;

	void Update() {
		timer += Time.deltaTime;
		if (timer > 0.1f) {
			Destroy(gameObject);
		}
	}

}
