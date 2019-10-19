//GameController.cs, John Knoop, 300835103, 10/19/2019, v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;


    public GameObject scoreboard;
    public GameObject score;


    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            if (_lives < 1)
            {

                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "Lives: " + _lives.ToString();
            }


        }

    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;



            if (scoreboard.GetComponent<Scoreboard>().highScore < _score)
            {
                scoreboard.GetComponent<Scoreboard>().highScore = _score;
            }
            scoreboard.GetComponent<Scoreboard>().score = _score;
            scoreboard.GetComponent<Scoreboard>().lives = _lives;



            if (_score == 200)
            {
                if (SceneManager.GetActiveScene().name == "Main")
                {
                    SceneManager.LoadScene("Level2");
                }
            }
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObjectInitialization();
        SceneConfiguration();
    }

    private void GameObjectInitialization()
    {
        scoreboard = GameObject.Find("HighScore");

        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
    }


    private void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                highScoreLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                break;
            case "Main":
                Lives = 5;
                Score = 0;
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;

                break;
            case "Level2":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                Lives = scoreboard.GetComponent<Scoreboard>().lives;
                Score = scoreboard.GetComponent<Scoreboard>().score;

                break;

            case "End":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                highScoreLabel.text = "High Score: " + scoreboard.GetComponent<Scoreboard>().score;

                break;
        }




        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Event Handlers
    public void OnStartButtonClick()
    {
        DontDestroyOnLoad(scoreboard);
        SceneManager.LoadScene("Main");
    }


    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
