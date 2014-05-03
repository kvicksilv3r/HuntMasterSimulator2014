using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraScript : MonoBehaviour {
	public WeaponScript Weapon;

	GameObject gun;
	bool ads = false;

	GameObject originalPosition;
	GameObject adsPosition;

	public Vector3 gunOffset;

	public GameObject bullet;

	//List<WeaponScript> weapons;
	public WeaponScript[] weapons;
	int weaponCounter = 0;

	void Start () {
		/* DEV SHIT GOES HERE */
		//weapons = new WeaponScript[2];
		/*weapons = new List<WeaponScript> ();
		weapons.Add (GameObject.Find ("MP9").GetComponent<WeaponScript> ());
		weapons.Add (GameObject.Find ("MP5K").GetComponent<WeaponScript> ());*/
		Weapon = GameObject.Find ("MP5K").GetComponent<WeaponScript> ();
		/* DEV SHIT GOES HERE */

		originalPosition = GameObject.Find ("OriginalGunPosition");
		adsPosition = GameObject.Find ("adsGunPosition");

		Physics.IgnoreLayerCollision(
			LayerMask.NameToLayer("Bullet"),
			LayerMask.NameToLayer("IgnoreBullets")
		);
	}

	void Update () {

		GameCtrlScript.activeWeapon = weaponCounter;
		bool fire = false;
		if(Weapon.Automatic && Input.GetButton("Fire1")) { fire = true; }
		if(!Weapon.Automatic && Input.GetButtonDown("Fire1")) { fire = true; }

		if(fire && Weapon.CanFire()) {
			Screen.lockCursor = true;
			Weapon.Fire();
		}

		for (int i = 0; i < weapons.Length; i++) {
			weapons[i].transform.localPosition = new Vector3(1000,0,0);
		}

		if (Input.GetButtonDown ("Weapon1"))
			weaponCounter -= 1;
			//weaponCounter = (weaponCounter + 1) % weapons.Length;//Weapon = weapons [0];
		else if (Input.GetButtonDown ("Weapon2")) {
			//print (weaponCounter);
			weaponCounter += 1;
			//weaponCounter = (weaponCounter - 1) % weapons.Length;//Weapon = weapons[1];
		}
		if(weaponCounter >= weapons.Length) weaponCounter -= weapons.Length;
		if(weaponCounter < 0) weaponCounter += weapons.Length;

		Weapon = weapons [weaponCounter];

		gun = Weapon.gameObject;
		ads = Input.GetButton ("Fire2");

		gun.transform.localPosition =
			ads ?
				//adsPosition.transform.localPosition :
				gun.transform.Find ("adsGunPosition").transform.localPosition :
				//originalPosition.transform.localPosition
				gun.transform.Find ("OriginalGunPosition").transform.localPosition
			;
		gun.transform.localPosition += gunOffset;

		gunOffset -= gunOffset * 3f * Time.deltaTime;
		Camera.main.fieldOfView = ads ? 45 : 60;
	}
}
