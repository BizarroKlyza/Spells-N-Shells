using UnityEngine;

public class SnapToGrid : MonoBehaviour {

	void LateUpdate() {
		Vector3 position = transform.localPosition;

		position.x = (Mathf.Round(transform.parent.position.x * 16) * 0.0625f) - transform.parent.position.x;
		position.y = (Mathf.Round(transform.parent.position.y * 16) * 0.0625f) - transform.parent.position.y;

		transform.localPosition = position;
	}
}