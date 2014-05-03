using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

	public bool inWater = false;
	GameObject water = null;
	static Texture2D waterTexture = null;

	void Start() {
		if (waterTexture == null) {
			waterTexture = new Texture2D (1, 1);
			waterTexture.SetPixel (0, 0, new Color(0f,0f,1f,0.5f));
			waterTexture.Apply();
		}
	}

	void Update () {
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.tag == "Water") {
			inWater = true;
			water = c.gameObject;
		}
	}

	void OnTriggerExit(Collider c) {
		if (c.gameObject.tag == "Water") {
			inWater = false;
			water = null;
		}
	}

	void OnGUI() {
		if (inWater) {
			GUI.skin.box.normal.background = waterTexture;
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), GUIContent.none);
		}
	}
}
