using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;


public class GameManager : MonoBehaviour {

    public List<string> pageData;

    public enum GameState { Study,
                                Defuse,
                                Menu,
                                Lose,
                                Win};
    public GameState currentGame;
    private GameState lastGame;

    public Text studyGuidePage;
    private int currentPage;

    private bool startToggle;

    public Canvas menu;
    public Canvas studyGuide;

    public GameObject studyDefault;
    public GameObject defuseDefault;
    public GameObject menuDefault;
    public GameObject loseDefault;
    public GameObject winDefault;

    private GameObject lastButton;

    public GameObject eventSystem;

	// Use this for initialization
	void Start () {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
        currentGame = GameState.Study;

        currentPage = 0;

        pageData = new List<string>();

        LoadPageData();

        studyGuidePage.text = pageData[currentPage];

        startToggle = false;
    }
	
	// Update is called once per frame
	void Update () {
        
		// check that you're in the defusing part of the game
		if (currentGame == GameState.Defuse) {
			// bomb input methods
			BombInputs.CutBlueWire();
			BombInputs.CutRedWire();
			BombInputs.CutYellowWire();
			BombInputs.CutGreenWire();
		}
			

        if(Input.GetKey(KeyCode.Joystick1Button7) && !startToggle)
        {
            ToggleMenu();
        }

        startToggle = Input.GetKey(KeyCode.Joystick1Button7);

    }

    public void NextPage()
    {
        if(currentPage != pageData.Count - 1)
        {
            currentPage++;
            studyGuidePage.text = pageData[currentPage];
        }
    }

    public void LastPage()
    {
        if (currentPage != 0)
        {
            currentPage--;
            studyGuidePage.text = pageData[currentPage];
        }
    }

    public void CloseStudyGuide()
    {
        studyGuide.gameObject.SetActive(false);
    }

    void ToggleMenu()
    {
        if(currentGame == GameState.Menu)
        {
            currentGame = lastGame;

            menu.gameObject.SetActive(false);

            EventSystem.current.SetSelectedGameObject(lastButton);
        }
        else
        {
            lastGame = currentGame;

            switch (currentGame)
            {
                case GameState.Study:
                    lastButton = studyDefault;
                    break;
                case GameState.Defuse:
                    lastButton = defuseDefault;
                    break;
            }

            currentGame = GameState.Menu;

            menu.gameObject.SetActive(true);

            EventSystem.current.SetSelectedGameObject(menuDefault);
        }
    }

    public void LoadPageData()
    {
        StreamReader sr;

        string line = "";

        for(int i = 1; i < 7; i++)
        {
            sr = File.OpenText("Assets\\PageData\\" + i + ".txt");

            pageData.Add("");

            while ((line = sr.ReadLine()) != null)
            {
                pageData[i - 1] += line;
            }
        }
    }
}
