using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagment;

public class GameUI : MonoBehaviour
{
    [Header("Header")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;
    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateHealthBar(int curHP, int MaxHP)
    {
        healthBarFill. fillAmount = (float)cupHp / (float)maxHP;
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }
    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }
    public void SetEndGameScreen(bool won, int score)
    {
        endGameHeaderText.text = won == true ? "You Win, Go to Taco Bell" : "You Lose, No Taco Bell for you!!";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = " <b>Score/B>\n" + score;
    }

    public void OnResumeButton()
    {

    }
    public void OnRestartButton()
    {
        SceneManger.
    }
}
