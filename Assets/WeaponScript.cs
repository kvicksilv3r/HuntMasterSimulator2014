using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public float FireRate;
	public int Damage;
	public bool Automatic;
	public GameObject bullet;
	public GameObject muzzleFlash;
	public Vector3 MinimumKick;
	public Vector3 MaximumKick;
	public AudioClip FireSound;
	public int bulletSpeed = 2000;

	float cooldown;

	void Update() {
		if (cooldown > 0) {
			cooldown -= Time.deltaTime;
		}
	}

	public bool CanFire() {
		return cooldown <= 0;
	}

	public void Fire() {
		if (!gameObject.activeSelf)
			return;

		cooldown = FireRate;

		GameObject b = Instantiate (
			bullet,
			transform.Find("BulletSpawn").transform.position,
			Camera.main.transform.rotation * Quaternion.AngleAxis(-90, Vector3.up)
		) as GameObject;

		if(muzzleFlash != null){
		GameObject m = Instantiate (
			muzzleFlash,
			transform.Find("BulletSpawn").transform.position,
				Camera.main.transform.rotation * muzzleFlash.transform.rotation
			) as GameObject;
		}

		if(FireSound != null){
			GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().audio.Stop();
			GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().audio.clip = FireSound;
			GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>().audio.Play();
		}
		
		b.rigidbody.AddForce (Camera.main.transform.forward * bulletSpeed);
		b.GetComponent<BulletScript> ().Damage = Damage;
		b.GetComponent<BulletScript> ().Gun = gameObject;

		Camera.main.GetComponent<CameraScript>().gunOffset +=
			new Vector3(
				Random.Range(MinimumKick.x, MaximumKick.x),
				Random.Range(MinimumKick.y, MaximumKick.y),
				Random.Range(MinimumKick.z, MaximumKick.z)
		);
	}
}
