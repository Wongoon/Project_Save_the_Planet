using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReact : MonoBehaviour
{
    public void ChangeScene(string SceneName)
    {
        if(SceneName == "ExitScene")
        {
            Application.Quit();
            return;
        }
        SceneManager.LoadScene(SceneName);
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
