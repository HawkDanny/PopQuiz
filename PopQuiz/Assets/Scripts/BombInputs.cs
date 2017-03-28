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


    void BlueWire()
    {
        if (Input.GetButtonDown("2"))
        {

        }
    }
	void RedWire() {
        if(Input.GetButtonDown("1")){

        }
        // b button input here


    }


	void YellowWire() {
        if (Input.GetButtonDown("3"))
        {

        }
        // y button input here


    }


	void GreenWire() {
        if (Input.GetButtonDown("0"))
        {

        }
        // a button input here

    }

	void LeftTrigger() {
		// decide how trigger will change the bomb
		// left trigger input here

	}

	void RightTrigger() {
		// decide how trigger will change the bomb
		// right trigger input here

	}

}
