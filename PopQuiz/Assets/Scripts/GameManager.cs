using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;


public class GameManager : MonoBehaviour {

    //instructions for the study guide
    public List<string> pageData;

    //different states of the game
    public enum GameState { Study,
                                Defuse,
                                Menu,
                                Results};

    //the current GameState
    public GameState currentGame;

    //the last GameState, used for going into the menu
    private GameState lastGame;

    //Text on the studyGuide
    public Text studyGuidePage;

    //number page that the user is on in the study guide
    private int currentPage;

    //bool for toggling the menu when pushing start
    private bool startToggle;

    //the menu canvas
    public Canvas menu;
    //the studyguide canvas
    public Canvas studyGuide;
    //the results screen canvas
    public Canvas results;

    //the button to have focus in the studyguide
    public GameObject studyDefault;
    //the button to have focus in the menu
    public GameObject menuDefault;
    //the button to have focus on the results screen
    public GameObject resultsDefault;


	public GameObject bombInputsObject; 	// GameObject with BombInputs Script
	private BombInputs BombInput;			// BombInputs Script of above object

    //the button to give focus to when leaving the menu
    private GameObject lastButton;

    //float for the timer
    private float timer;
    //text that displays the timer
    public Text timerText;


    // Use this for initialization
    void Start () {

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        

		// Get script from bombInputsObject
		BombInput = bombInputsObject.GetComponent<BombInputs> ();

        //set default values and initialize
        currentGame = GameState.Study;

        currentPage = 0;

        pageData = new List<string>();

        LoadPageData();

        studyGuidePage.text = pageData[currentPage];

        startToggle = false;

        timer = 300f;

        //Updated upstream

        //timerText.text = timer;
        //Stashed changes
    }
	
	// Update is called once per frame
	void Update () {

        //check to toggle the menu
        if(Input.GetKey(KeyCode.Joystick1Button7) && !startToggle && currentGame != GameState.Results )
        {
            ToggleMenu();
        }

        //if the timer has run out, open the results
        if(timer <= 0)
        {
            OpenResults();
        }

        //if the game is not displaying the results
        if(currentGame != GameState.Results)
        {
            //decriment the timer
            timer -= Time.deltaTime;

            //show the formatted timer
            MakeTimerFormat(timer);
        }

        //change startToggle so menue is not toggle every update if start is help down
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

    //close the game
    public void CloseGame()
    {
        Application.Quit();
    }

    //resume the game from the menu
    public void Resume()
    {
        //got to the last GameState
        currentGame = lastGame;

        //disable the menu ui
        menu.gameObject.SetActive(false);

        //set the button to have focus
        EventSystem.current.SetSelectedGameObject(lastButton);
    }

    //restart the game
    public void Restart()
    {
        //go to studyguide GameState
        currentGame = GameState.Study;

        //disable all ui except for the gameUI and the studyGuide
        menu.gameObject.SetActive(false);
        results.gameObject.SetActive(false);
        studyGuide.gameObject.SetActive(true);

        //set the default to the studyGuide's default button
        EventSystem.current.SetSelectedGameObject(studyDefault);

        //set the page to the first
        currentPage = 0;

        //rest the timer
        timer = 300;

        //load in the studyGuide page data
        studyGuidePage.text = pageData[currentPage];
    }

    //load the next page
    public void NextPage()
    {
        //check if the user is on the last page
        if(currentPage != pageData.Count - 1)
        {
            //if not, go to the next page and display
            currentPage++;
            studyGuidePage.text = pageData[currentPage];
        }
    }

    //load the previous page
    public void LastPage()
    {
        //check if the user is on the first page
        if (currentPage != 0)
        {
            //if not, go the the previous page and display
            currentPage--;
            studyGuidePage.text = pageData[currentPage];
        }
    }

    //Close the study guide
    public void CloseStudyGuide()
    {
        //hide the studyguide
        studyGuide.gameObject.SetActive(false);

        //set the GameState to the defuse state
        currentGame = GameState.Defuse;

        //set the selelected button to nothing
        EventSystem.current.SetSelectedGameObject(null);
    }

    //show the results menu
    public void OpenResults()
    {
        //set the GameState to the results
        currentGame = GameState.Results;

        //display the results screen
        results.gameObject.SetActive(true);

        //set the selected button to the default for the reults screen
        EventSystem.current.SetSelectedGameObject(resultsDefault);
    }

    //toggle the menu
    void ToggleMenu()
    {
        //if the game is in the menu
        if(currentGame == GameState.Menu)
        {
            //go to the last GameState
            currentGame = lastGame;

            //hide the menu
            menu.gameObject.SetActive(false);

            //set the active button to the last screens default button
            EventSystem.current.SetSelectedGameObject(lastButton);
        }
        else
        {
            //assign the GameState to return to
            lastGame = currentGame;

            //get the right button to return focus to
            switch (currentGame)
            {
                case GameState.Study:
                    lastButton = studyDefault;
                    break;
                case GameState.Defuse:
                    lastButton = null;
                    break;
            }

            //change the GameState to the menu
            currentGame = GameState.Menu;

            //display the menu
            menu.gameObject.SetActive(true);

            //set the button to have focus now
            EventSystem.current.SetSelectedGameObject(menuDefault);
        }
    }

    //display the timer with correct format
    private void MakeTimerFormat(float time)
    {
        //get the minutes component
        int minutes = (int)(time / 60);
        //get the seconds component
        int seconds = (int)(time % 60);

        //string to add for formatting
        string extraZero = "";

        //add an extra zero if the seconds is single digit
        if (seconds < 10) extraZero = "0";

        //set the timer text
        timerText.text = minutes.ToString() + ":" + extraZero + seconds.ToString();
    }

    //load in the study guide page data
    public void LoadPageData()
    {
        //stream reader to open the files
        StreamReader sr;

        //string to hold each line
        string line = "";

        //for the 3 pages
        for(int i = 1; i <= 3; i++)
        {
            //open each data file
            sr = File.OpenText("Assets/PageData/" + i + ".txt");

            //add a new string for each page
            pageData.Add("Page " + i + '\n' + '\n');

            //while there is info to read
            while ((line = sr.ReadLine()) != null)
            {
                //add the info
                pageData[i - 1] += line;
                //line break at the end of each line
                pageData[i - 1] += '\n';
            }
        }
    }
}
