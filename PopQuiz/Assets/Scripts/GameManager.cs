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
                                Results};
    public GameState currentGame;
    private GameState lastGame;

    public Text studyGuidePage;
    private int currentPage;

    private bool startToggle;

    public Canvas menu;
    public Canvas studyGuide;
    public Canvas results;

    public GameObject studyDefault;
    public GameObject menuDefault;
    public GameObject resultsDefault;

	public GameObject bombInputsObject; 	// GameObject with BombInputs Script
	private BombInputs BombInput;			// BombInputs Script of above object

    private GameObject lastButton;

    public GameObject eventSystem;

    private float timer;
    public Text timerText;


    // Use this for initialization
    void Start () {
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
        currentGame = GameState.Study;

		// Get script from bombInputsObject
		BombInput = bombInputsObject.GetComponent<BombInputs> ();

        currentPage = 0;

        pageData = new List<string>();

        LoadPageData();

        studyGuidePage.text = pageData[currentPage];

        startToggle = false;

        timer = 300f;


    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKey(KeyCode.Joystick1Button7) && !startToggle && currentGame != GameState.Results )
        {
            ToggleMenu();
        }

        if(timer <= 0)
        {
            OpenResults();
        }

        if(currentGame != GameState.Results)
        {
            timer -= Time.deltaTime;

            MakeTimerFormat(timer);
        }

        startToggle = Input.GetKey(KeyCode.Joystick1Button7);

		// Button Handling in DEFUSE State
		if (currentGame == GameState.Defuse)
		{ 
			// bomb input methods
			//BombInput.CutBlueWire();
			//BombInput.CutRedWire();
			//BombInput.CutYellowWire();
			//BombInput.CutGreenWire();
			//BombInput.DPadDown();
			//BombInput.DPadUp();
			//BombInput.DPadRight();
			//BombInput.DPadLeft();
		}
			
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        currentGame = lastGame;

        menu.gameObject.SetActive(false);

        EventSystem.current.SetSelectedGameObject(lastButton);
    }

    public void Restart()
    {
        //todo
        currentGame = GameState.Study;

        menu.gameObject.SetActive(false);
        results.gameObject.SetActive(false);
        studyGuide.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(studyDefault);

        currentPage = 0;

        studyGuidePage.text = pageData[currentPage];
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

        currentGame = GameState.Defuse;
    }

    public void OpenResults()
    {
        currentGame = GameState.Results;

        results.gameObject.SetActive(true);

        EventSystem.current.SetSelectedGameObject(resultsDefault);
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
                    lastButton = null;
                    break;
            }

            currentGame = GameState.Menu;

            menu.gameObject.SetActive(true);

            EventSystem.current.SetSelectedGameObject(menuDefault);
        }
    }

    private void MakeTimerFormat(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);

        timerText.text = minutes.ToString() + ":" + seconds.ToString();
    }

    public void LoadPageData()
    {
        StreamReader sr;

        string line = "";

        for(int i = 1; i <= 3; i++)
        {
            sr = File.OpenText("Assets/PageData/" + i + ".txt");

            pageData.Add("");

            while ((line = sr.ReadLine()) != null)
            {
                pageData[i - 1] += line;
                pageData[i - 1] += '\n';
            }
        }
    }
}
