using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScopeInScript : MonoBehaviour {

	public Texture2D scopeTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(Input.GetMouseButton(1) &&
		   GameCtrlScript.activeWeapon == 3){
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), scopeTexture);
		}
	}
}
