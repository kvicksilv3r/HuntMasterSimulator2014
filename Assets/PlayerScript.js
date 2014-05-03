#pragma strict

var motor : CharacterMotor;
var inWater : boolean;

function Update () {
	//update so other js shit can reach it as well, WOOOO UNITY askfjaslkfjl
	inWater = GetComponent(WaterScript).inWater;
	
	if(inWater) {
		motor.movement.gravity = 2;
	} else {
		motor.movement.gravity = 10;
	}
	
	if(Input.GetButton("Sprint")) {
		motor.movement.maxForwardSpeed = 20;
	} else {
		motor.movement.maxForwardSpeed = 10;
	}
}