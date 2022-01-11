using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    //Instance of game manager
    public static GameManager instance;
    

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;
        
        // toggle pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);
        
        //toggel mouse cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void AddScore(int score)
    {
        curScore += score;
        
        GameUI.instance.UpdateScoreText(curScore);
        //add score to win
        if(curScore >= scoreToWin)
        {
            WinGame();
        }
    }
    public void WinGame()
    {
        GameUI.instance.GetEndGameScreen(true,curScore);
    }
    public void LoseGame()
    {
        //set the endgame screen
        GameUI.instance.GetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
