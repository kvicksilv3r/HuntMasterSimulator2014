//Rippat från http://answers.unity3d.com/questions/10425/how-to-stabilize-angular-motion-alignment-of-hover.html

using UnityEngine;
using System.Collections;

public class HoverStabilizer : MonoBehaviour {
	
	public float stability = 0.3f;
	public float speed = 2.0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 predictedUp = Quaternion.AngleAxis(
			rigidbody.angularVelocity.magnitude * Mathf.Rad2Deg * stability / speed,
			rigidbody.angularVelocity
			) * transform.up;
		
		Vector3 torqueVector = Vector3.Cross(predictedUp, Vector3.up);
		rigidbody.AddTorque(torqueVector * speed * speed);
	}
}