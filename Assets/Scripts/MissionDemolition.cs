using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public Text uitLevel;
    public Text uitShots;
    public Text uitScore;
    public Text uitButton;
    public Vector3 castlePos;
    public GameObject[] castles;

    [Header("Set Dynamically")]
    public int level;
    public int levelMax;
    public int shotsTaken;
    public GameObject castle;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";
    private int scoreeee = 0;

    // Start is called before the first frame update
    void Start()
    {
        S = this;

        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }

    void StartLevel()
    {
        if(castle != null)
        {
            Destroy(castle);
        }

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        castle = Instantiate<GameObject>(castles[level]);
        castle.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
        uitScore.text = "Score: " + scoreeee;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if (mode == GameMode.playing)
        {
            if (S.shotsTaken >= 5 && FollowCam.POI == null)
            {
                PlayerPrefs.SetInt("HighScore", scoreeee);
                SceneManager.LoadScene("GameOver");
            }
            if (Goal.goalMet)
            {
                Debug.Log("1");
                mode = GameMode.levelEnd;
                SwitchView("Show Both");
                Invoke("NextLevel", 2f);
            } 
        }
    }
    
    void NextLevel()
    {
        Debug.Log(level);
        if (level == castles.Length -1)
        {
            Debug.Log("2");
            scoreeee++;
            PlayerPrefs.SetInt("HighScore", scoreeee);
            SceneManager.LoadScene("Win");
        }
        else
        {
            level++;
            scoreeee++;
            StartLevel();
        }
        
    }

    public void SwitchView(string eView = "")
    {
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;

            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;

            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
        
    }

    
}
