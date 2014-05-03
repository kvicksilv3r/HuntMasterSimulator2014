using UnityEngine;
using System.Collections;

public class GameCtrlScript : MonoBehaviour {

	public static int Score = 0;
	public static int activeWeapon = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Box (new Rect (0, 0, 128, 32), ""+Score);
	}
}
