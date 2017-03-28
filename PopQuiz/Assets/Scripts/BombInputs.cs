using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInputs : MonoBehaviour {

    bool blueConnection = true;
    bool redConnection = true;
    bool greenConnection = true;
    bool yellowConnection = true;
    enum dPadDir {up, down, left, right};
    List<dPadDir> dpadInput;
    // Use this for initialization
    void Start () {
        dpadInput = new List<dPadDir>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// x button
    void CutBlueWire() {
        if (Input.GetButtonDown("2")) {
            blueConnection = false;
        }
    }

	// b button
	void CutRedWire() {
        if(Input.GetButtonDown("1")){
            redConnection = false;
        }
        // b button input here
    }

	// y button
	void CutYellowWire() {
        if (Input.GetButtonDown("3"))
        {
            yellowConnection = false;
        }
        // y button input here
    }

	// a button
	void CutGreenWire() {
        if (Input.GetButtonDown("0"))
        {
            greenConnection = false;
        }
        // a button input here
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
        if (Input.GetButtonDown("5"))
        {
            dpadInput.Add(dPadDir.up);
        }
    }

	// d pad down
	void DPadDown() {
        if (Input.GetButtonDown("6"))
        {
            dpadInput.Add(dPadDir.down);
        }
    }

	// d pad left
	void DPadLeft() {
        if (Input.GetButtonDown("7"))
        {
            dpadInput.Add(dPadDir.left);
        }
    }

	// d pad right
	void DPadRight() {
        if (Input.GetButtonDown("8"))
        {
            dpadInput.Add(dPadDir.right);
        }
    }

	// bumper? 
}
