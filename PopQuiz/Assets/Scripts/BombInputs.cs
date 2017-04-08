using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombInputs : MonoBehaviour {

    // Bomb model parts//
    public GameObject[] roundButtons = new GameObject[4];
    public GameObject redWire;
    public GameObject blueWire;
    public GameObject greenWire;
    public GameObject yellowWire;

    // Renderers
    private Renderer redWireRend;
    private Renderer blueWireRend;
    private Renderer greenWireRend;
    private Renderer yellowWireRend;

    private bool blueConnection = true;
    private bool redConnection = true;
    private bool greenConnection = true;
    private bool yellowConnection = true;
    private bool triggerDown = true;
    private bool leftBumper = false;
    private bool rightBumper = false;
    private bool leftStick = false;
    private bool rightStick = false;
    float lastVert;
    float lastHoriz;
    enum inputs { a, x, y, b, green, red, blue, yellow, up, down, left, right };
    List<inputs> inputList;

    // Use this for initialization
    void Start() {
        inputList = new List<inputs>();

        redWireRend = redWire.GetComponent<Renderer>();
        blueWireRend = blueWire.GetComponent<Renderer>();
        greenWireRend = greenWire.GetComponent<Renderer>();
        yellowWireRend = yellowWire.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update() {
        CutBlueWire();
        CutRedWire();
        CutYellowWire();
        CutGreenWire();
        LeftStickClick();
        RightStickClick();
        DPadUp();
        DPadDown();
        DPadLeft();
        DPadRight();
        lastVert = Input.GetAxis("Vertical");
        lastHoriz = Input.GetAxis("Horizontal");
    }

    // x button (OR Alternative Keyboard input: numerical keys above abc keys)
    public void CutBlueWire() {
        if (Input.GetKeyDown("joystick button 2") || Input.GetKey(KeyCode.Alpha2))
        {
            // show output (unrender blue wire)
            if (!LeftBumper() && !RightBumper())
            {
                inputList.Add(inputs.x);
            }
            else
            {
                if (blueConnection)
                {
                    inputList.Add(inputs.blue);
                    blueConnection = false;
                    blueWireRend.enabled = false;
                }
            }
            Debug.Log("CutBlueWire() called and inside GetButtonDown(2) check.");
        }
    }

    // b button
    public void CutRedWire() {
        if (Input.GetKeyDown("joystick button 1") || Input.GetKey(KeyCode.Alpha1)) {
            //redWireRend.enabled = false;
            if (!LeftBumper() && !RightBumper())
            {
                inputList.Add(inputs.b);
            }
            else
            {
                if (redConnection)
                {
                    inputList.Add(inputs.red);
                    redConnection = false;
                    redWireRend.enabled = false;
                }
            }
            Debug.Log("CutRedWire() called and inside GetButtonDown(1) check.");
        }
    }

    // y button
    public void CutYellowWire()
    {
        if (Input.GetKeyDown("joystick button 3") || Input.GetKey(KeyCode.Alpha3))
        {
            if (!LeftBumper() &&  !RightBumper())
            {
                inputList.Add(inputs.y);
            }
            else
            {
                if (yellowConnection)
                {
                    inputList.Add(inputs.yellow);
                    yellowConnection = false;
                    yellowWireRend.enabled = false;
                }
            }
            Debug.Log("CutYellowWire() called and inside GetButtonDown(3) check.");
        }
    }

    // a button
    public void CutGreenWire() {
        if (Input.GetKeyDown("joystick button 0") || Input.GetKey(KeyCode.Alpha0))
        {
            if (!LeftBumper() && !RightBumper())
            {
                inputList.Add(inputs.a);
            }
            else
            {
                if (greenConnection)
                {
                    inputList.Add(inputs.green);
                    greenConnection = false;
                    greenWireRend.enabled = false;
                }
            }
            Debug.Log("CutGreenWire() called and inside GetButtonDown(0) check.");
        }
    }

	// d pad up
	public void DPadUp() {
        float tempVert = Input.GetAxis("Vertical");
        if (tempVert == 1 || Input.GetKey(KeyCode.Alpha5))
        {
            if (tempVert != lastVert)
            {
                inputList.Add(inputs.up);
                Debug.Log("DPadUp() called and inside GetButtonDown(5) check.");
            }

        }
    }

	// d pad down
	public void DPadDown() {
        float tempVert = Input.GetAxis("Vertical");
        if (tempVert == -1 || Input.GetKey(KeyCode.Alpha6))
        {
            if (tempVert != lastVert)
            {
                inputList.Add(inputs.down);
                Debug.Log("DPadDown() called and inside GetButtonDown(6) check.");
            }
        }
    }

	// d pad left
	public void DPadLeft() {
        float tempHoriz = Input.GetAxis("Horizontal");
        if (tempHoriz == -1 || Input.GetKey(KeyCode.Alpha7))
        {
            if (tempHoriz != lastHoriz)
            {
                inputList.Add(inputs.left);
                Debug.Log("DPadLeft() called and inside GetButtonDown(7) check.");
            }

        }
    }

	// d pad right
	public void DPadRight() {
        float tempHoriz = Input.GetAxis("Horizontal");
        if (tempHoriz == 1 || Input.GetKey(KeyCode.Alpha8))
        {
            if (tempHoriz != lastHoriz)
            {
                inputList.Add(inputs.right);
                Debug.Log("DPadRight() called and inside GetButtonDown(8) check.");
            }

        }
    }

    //For left bumper
    public bool LeftBumper()
    {
        if (Input.GetKey("joystick button 4"))
        {
            leftBumper = true;
            Debug.Log("LeftBumper() called and inside GetButtonDown(4) check.");
            return true;
        }
        return false;
    }

    //For right bumper
    public bool RightBumper()
    {
        if (Input.GetKey("joystick button 5"))
        {
            leftBumper = true;
            Debug.Log("RightBumper() called and inside GetButtonDown(5) check.");
            return true;
        }
        return false;
    }

    //For left stick click
    public void LeftStickClick()
    {
        if (Input.GetKeyDown("joystick button 8"))
        {
            leftStick = true;
            Debug.Log("LeftStickClick() called and inside GetButtonDown(8) check.");
        }
    }

    //For right stick click
    public void RightStickClick()
    {
        if (Input.GetKeyDown("joystick button 9"))
        {
            rightStick = true;
            Debug.Log("RightStickClick() called and inside GetButtonDown(9) check.");
        }
    }
    // bumper? 
}
