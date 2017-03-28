using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInputs : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// x button
    void BlueWire() {
        if (Input.GetButtonDown("2")) {

        }
    }

	// b button
	void RedWire() {
        if(Input.GetButtonDown("1")){

        }
    }

	// y button
	void YellowWire() {
        if (Input.GetButtonDown("3"))
        {

        }
    }

	// a button
	void GreenWire() {
        if (Input.GetButtonDown("0"))
        {

        }
    }

	// left trigger
	void LeftTrigger() {
		// decide how trigger will change the bomb
		// left trigger input here

	}

	// right trigger
	void RightTrigger() {
		// decide how trigger will change the bomb
		// right trigger input here

	}

	// d pad up
	void DPadUp() {
		
	}

	// d pad down
	void DPadDown() {

	}

	// d pad left
	void DPadLeft() {

	}

	// d pad right
	void DPadRight() {

	}

	// bumper? 

	// controller vibration
	void VibrateController() {

	}

}
