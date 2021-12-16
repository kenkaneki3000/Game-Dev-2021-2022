using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManger.LoadScene("Game");
    }
    public void OnQuitButton()
    {
        Appliiction.Quit();
    }
}
