using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

	public AnimationCurve sizeCurve;

	float riseSpeed = 0.1f;
	float timer = 0f;
	float lifespan = 0.25f;
	Vector3 normalScale;

	void Start() {
		lifespan += Random.Range(-0.1f, 0.1f);
		transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		transform.localScale *= Random.Range(0.8f, 1.2f);
		normalScale = transform.localScale;
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= lifespan) {
			Destroy(gameObject);
		}
		transform.position += Vector3.up * riseSpeed;
		transform.localScale = normalScale * sizeCurve.Evaluate(timer / lifespan);
	}
}
