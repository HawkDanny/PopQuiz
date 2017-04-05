using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInputs : MonoBehaviour {

    bool blueConnection = true;
    bool redConnection = true;
    bool greenConnection = true;
    bool yellowConnection = true;
    bool triggerDown = true;
    bool leftBumper = false;
    bool rightBumper = false;
    bool leftStick = false;
    bool rightStick = false;
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
    void BlueWire() {
        if (Input.GetButtonDown("2")) {
            blueConnection = !blueConnection;
        }
    }

	// b button
	void RedWire() {
        if(Input.GetButtonDown("1")){
            redConnection = !redConnection;
        }
        // b button input here
    }

	// y button
	void YellowWire() {
        if (Input.GetButtonDown("3"))
        {
            yellowConnection = !yellowConnection;
        }
        // y button input here
    }

	// a button
	void GreenWire() {
        if (Input.GetButtonDown("0"))
        {
            greenConnection = !greenConnection;
        }
        // a button input here
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

    void LeftBumper()
    {
        if (Input.GetButtonDown("4"))
        {
            leftBumper = true;
        }
    }

    void RightBumper()
    {
        if (Input.GetButtonDown("4"))
        {
            leftBumper = true;
        }
    }

    void LeftStickClick()
    {
        if (Input.GetButtonDown("8"))
        {
            leftStick = true;
        }
    }

    void RightStickClick()
    {
        if (Input.GetButtonDown("9"))
        {
            rightStick = true;
        }
    }
    // bumper? 
}
