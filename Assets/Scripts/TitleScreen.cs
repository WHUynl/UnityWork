using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreen : MonoBehaviour
{

    // Use this for initialization
    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void toabout()
    {

        SceneManager.LoadScene("Instructions");
    }
    public void toscore()
    {

        SceneManager.LoadScene("highscore");
    }

}
