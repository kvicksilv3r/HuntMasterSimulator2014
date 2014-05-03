using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public GameObject bullet;

	void Update () {
		if(!gameObject.activeInHierarchy) return;

		if(Input.GetButtonDown("Fire1")) {

			Screen.lockCursor = true;

			GameObject b = Instantiate (
				bullet,
				GameObject.Find ("BulletSpawn").transform.position,
				transform.rotation * Quaternion.AngleAxis(-90, Vector3.up)
			) as GameObject;

			b.rigidbody.AddForce (transform.forward * 2000);

			GetComponent<CameraScript>().gunOffset +=
				new Vector3(
					Random.Range(-0.05f, 0.05f),
					Random.Range(-0.05f, 0.05f),
					Random.Range(-0.1f, 0f)
				);
		}
	}
}
