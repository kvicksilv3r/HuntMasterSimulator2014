using UnityEngine;
using System.Collections;

public class BoarAi : MonoBehaviour {
	Vector3 playerPos;
	//int health = 3;
	public float speed = 30;
	bool enrage = false;
	bool alive;

	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Bullet") {
			if(!enrage) {
				rigidbody.AddForce(new Vector3(0, 300, 0), ForceMode.Force);
				enrage = true;
			}

			/*health -= coll.gameObject.GetComponent<BulletScript>().Damage;

			ParticleSystem ps = GameObject.Find ("Blod").GetComponent<ParticleSystem>();
			ps.transform.position = coll.contacts [0].point;
			ps.Emit (200);

			GameCtrlScript.Score += 100;
			GameObject.Destroy(coll.gameObject);*/
		}

		if (coll.gameObject.tag == "Environment" && enrage && alive)
		{
			rigidbody.AddForce(new Vector3(0, 300, 0), ForceMode.Force);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if(enrage && alive){
			playerPos = GameObject.Find("Player").transform.position;
			transform.position += (playerPos - transform.position).normalized * Time.deltaTime * speed;
			this.transform.LookAt(playerPos);
		}

		/*if(health <= 0){
			alive = false;
		}*/

		alive = GetComponent<HealthScript> ().health > 0;
		
		if (!alive) {
			GetComponent<HoverStabilizer>().enabled = false;
		}
	}
}
