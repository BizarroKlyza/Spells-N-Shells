using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	
	IEnumerator ShootIE(Vector3 d) {
		this.transform.parent.position += d * 0.1f;
		yield return null;
		Camera.main.transform.parent.position -= d * 0.1f;

	}

	public void Shoot(Vector3 direction) {
		StartCoroutine(ShootIE(direction));
	}
}
