using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    float timer = 0f;

    void Update() {

        timer += Time.deltaTime;
        this.transform.localScale += new Vector3(20 * Time.deltaTime, 20 * Time.deltaTime, 20 * Time.deltaTime);
        if (timer >= 0.1f)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
        if (timer > 2f)
        {
            Destroy(this.gameObject);

        }
    }
}
