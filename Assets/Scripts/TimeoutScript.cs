using UnityEngine;
using System.Collections;

public class TimeoutScript : MonoBehaviour {

	public float lifetime = 1f;

	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime < 0) {
			Destroy( gameObject );
		}
	}
}
