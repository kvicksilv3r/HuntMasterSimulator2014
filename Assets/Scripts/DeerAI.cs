using UnityEngine;
using System.Collections;

public class DeerAI : MonoBehaviour {

	public int health = 3;

	public bool alive = true;

	public Vector3 Target;
	public float Speed = 5f;
	public GameObject BlodEffekt;

	// Update is called once per frame
	void Update () {
		if (alive) {
			Target = GameObject.Find ("Player").transform.position;

			if (Vector3.Distance (transform.position, Target) > 1) {
				transform.position += (Target - transform.position).normalized
				* Time.deltaTime * Speed;
			}

			Vector3 targetDirection =
			Target - transform.position;

			Quaternion targetLookRotation = Quaternion.LookRotation (targetDirection);

			transform.rotation = Quaternion.Slerp (
				transform.rotation,
				targetLookRotation,
				Time.deltaTime
			);
		}

		if (GetComponent<HealthScript>().health <= 0/*health <= 0*/) {
			alive = false;
		}
		
		if (!alive) {
			GetComponent<HoverStabilizer>().enabled = false;
		}
	}

	/*void OnCollisionEnter(Collision collision) {
		//print (collision.gameObject.name);
		print(collision.gameObject.name);

		if (collision.gameObject.tag != "Bullet") {
			return;
		}

		health -= collision.gameObject.GetComponent<BulletScript> ().Damage;

		ParticleSystem ps = GameObject.Find ("Blod").GetComponent<ParticleSystem>();
		//ParticleSystem ps = go.GetComponent<ParticleSystem> ();

		for (int i = 0; i<collision.contacts.Length; i++) {
			ps.transform.position = collision.contacts [i].point;
			ps.Emit (200);
		}

		Destroy (collision.gameObject);

		GameCtrlScript.Score += 100;
	}*/
}
