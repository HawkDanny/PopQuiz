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
        Debug.Log("start game selected");
        Application.LoadLevel("Scenes/Game");
    }

    public void QuitGame()
    {
        Debug.Log("quit game selected");
        Application.Quit();
    }
}
