using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Gun {

	public GameObject flame1, flame2, flame3;

	GameObject bullet;

	void Start() {

	}

	public override void Shoot(Vector2 direction) {

		bullet = Instantiate(flame1, shotOrigin.position, Quaternion.identity);
		bullet.GetComponent<Flames>().Spawn(Quaternion.Euler(0f, 0f, Random.Range(-5f, 5f)) * direction);
		bullet.transform.localScale *= 0.75f;

		bullet = Instantiate(flame2, shotOrigin.position, Quaternion.identity);
		bullet.GetComponent<Flames>().Spawn(Quaternion.Euler(0f, 0f, Random.Range(-10f, 10f)) * direction);

		bullet = Instantiate(flame3, shotOrigin.position, Quaternion.identity);
		bullet.GetComponent<Flames>().Spawn(Quaternion.Euler(0f, 0f, Random.Range(-15f, 15f)) * direction);
	}

	
	void Update() {
		base.Update();
	}
}
