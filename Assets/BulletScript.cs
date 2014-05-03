using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public int Damage = 1;
	public GameObject Gun;

	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag != "Enemy") {
			return;
		}

		GameObject bodyPart = collision.contacts [0].otherCollider.gameObject;
		DamageScript ds = bodyPart.GetComponent<DamageScript> ();
		ds.Hurt (Damage);

		print ("SHOT " + bodyPart.transform.parent.name +
		       " IN THE " + bodyPart.name +
		       " WITH " + Gun.name);

		ParticleSystem ps = GameObject.Find ("Blod").GetComponent<ParticleSystem>();
		
		for (int i = 0; i<collision.contacts.Length; i++) {
			ps.transform.position = collision.contacts [i].point;
			ps.Emit (50 * ds.DamageMultiplier);
		}
		
		Destroy (gameObject);
		
		GameCtrlScript.Score += 100;
	}
}
