using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInputs : MonoBehaviour {

	// Bomb model parts//
	public GameObject[] roundButtons = new GameObject[4];
	public GameObject redWire;
	public GameObject blueWire;

	// Renderers
	private Renderer redWireRend;
	private Renderer blueWireRend;


	private bool blueConnection = true;
    private bool redConnection = true;
    private bool greenConnection = true;
    private bool yellowConnection = true;
    private enum dPadDir {up, down, left, right};
    private List<dPadDir> dpadInput;

    // Use this for initialization
    void Start () {
        dpadInput = new List<dPadDir>();

		redWireRend = redWire.GetComponent<Renderer> ();
		blueWireRend = blueWire.GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {}

	// x button (OR Alternative Keyboard input: numerical keys above abc keys)
    public void CutBlueWire() {
		if (Input.GetButtonDown("2") || Input.GetKey(KeyCode.Alpha2)) {	
			// show output (unrender blue wire)
			//blueWireRend.enabled = false;
            blueConnection = false;
			Debug.Log ("CutBlueWire() called and inside GetButtonDown(2) check.");
        }
    }

	// b button
	public void CutRedWire() {
		if(Input.GetButtonDown("1")|| Input.GetKey(KeyCode.Alpha1)) {
			//redWireRend.enabled = false;
            redConnection = false;
			Debug.Log ("CutRedWire() called and inside GetButtonDown(1) check.");
        }
        // b button input here

    }

	// y button
	public void CutYellowWire() {
		if (Input.GetButtonDown("3") || Input.GetKey(KeyCode.Alpha3))
  		{
            yellowConnection = false;
			Debug.Log ("CutYellowWire() called and inside GetButtonDown(3) check.");

        }
        // y button input here
    }

	// a button
	public void CutGreenWire() {
		if (Input.GetButtonDown("0") || Input.GetKey(KeyCode.Alpha0))
        {
            greenConnection = false;
			Debug.Log ("CutGreenWire() called and inside GetButtonDown(0) check.");
        }
        // a button input here

    }

	// left trigger
	public void LeftTrigger() {
		// decide how trigger will change the bomb
		// left trigger input here
	}

	// right trigger
	public void RightTrigger() {
		// decide how trigger will change the bomb
		// right trigger input here
	}

	// d pad up
	public void DPadUp() {
		if (Input.GetButtonDown("5") || Input.GetKey(KeyCode.Alpha5))
        {
            dpadInput.Add(dPadDir.up);
			Debug.Log ("DPadUp() called and inside GetButtonDown(5) check.");

        }
    }

	// d pad down
	public void DPadDown() {
		if (Input.GetButtonDown("6") || Input.GetKey(KeyCode.Alpha6))
        {
            dpadInput.Add(dPadDir.down);
			Debug.Log ("DPadDown() called and inside GetButtonDown(6) check.");
        }
    }

	// d pad left
	public void DPadLeft() {
		if (Input.GetButtonDown("7") || Input.GetKey(KeyCode.Alpha7))
        {
            dpadInput.Add(dPadDir.left);
			Debug.Log ("DPadLeft() called and inside GetButtonDown(7) check.");

        }
    }

	// d pad right
	public void DPadRight() {
		if (Input.GetButtonDown("8") || Input.GetKey(KeyCode.Alpha8))
        {
            dpadInput.Add(dPadDir.right);
			Debug.Log ("DPadRight() called and inside GetButtonDown(8) check.");

        }
    }

	// bumper? 
}
