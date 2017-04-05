using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        Application.LoadLevel("Scenes/Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
