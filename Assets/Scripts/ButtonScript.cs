using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject show;
    public GameObject hide;
    public void StartGame()
    {
        SceneManager.LoadScene("_Scene_0");
    }
    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShowHighScore(GameObject Score)
    {
        
        Score.SetActive(true);
        show.SetActive(false);
        hide.SetActive(true);
    }
    public void HideHighScore(GameObject Score)
    {
        Score.SetActive(false);
        show.SetActive(true);
        hide.SetActive(false);
    }
}
