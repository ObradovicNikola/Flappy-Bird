using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton, instructionsButton;

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image medalImage;

    [SerializeField]
    private GameObject pipeSpawner;

    private void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PauseGame()
    {
        if(BirdScript.instance != null)
        {
            if (BirdScript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                endScore.text = BirdScript.instance.score.ToString();
                bestScore.text = GameController.instance.GetHighscore().ToString();
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners();
                restartGameButton.onClick.AddListener(() => ResumeGame());
            }
        }
    }

    public void GoToMenuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneFader.instance.FadeIn("Gameplay");
    }

    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        instructionsButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pipeSpawner.SetActive(true);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void PlayerDiedShowScore(int score)
    {
        pausePanel.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = score.ToString();

        if(score > GameController.instance.GetHighscore())
        {
            GameController.instance.SetHighscore(score);
        }

        bestScore.text = GameController.instance.GetHighscore().ToString();
        
        if(score <= 15)
        {
            medalImage.sprite = medals[0];
        } else if (score <= 30)
        {
            medalImage.sprite = medals[1];
        } else if (score <= 50)
        {
            medalImage.sprite = medals[2];
        }
        else
        {
            medalImage.sprite = medals[3];
            GameController.instance.UnlockDiamondBird();
        }

        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());
        Time.timeScale = 0f;
    }
    void MakeSingleton()
    {
        if (instance == null)
            instance = this;
    }
}
