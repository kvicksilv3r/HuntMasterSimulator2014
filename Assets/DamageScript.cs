using UnityEngine;
using System.Collections;

public class DamageScript : MonoBehaviour {
	public int DamageMultiplier = 1;
	public int ScoreAward = 100;

	public void Hurt(int damage) {
		transform.parent.GetComponent<HealthScript> ().health -= DamageMultiplier * damage;
	}
}
