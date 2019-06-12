using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour {

	public float recoil;
	public Transform shotOrigin;
	public Vector2 lookDirection;


	public virtual void Shoot(Vector2 direction) {

	}

	public virtual void Update() {
		transform.parent.right = lookDirection;
	}

}
