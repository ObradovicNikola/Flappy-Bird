using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private const string HIGH_SCORE = "High Score";
    private const string SELECTED_BIRD = "Selected Bird";
    private const string GREEN_BIRD = "Green Bird";
    private const string RED_BIRD = "Red Bird";
    private const string DIAMOND_BIRD = "Diamond Bird";
    private const string DIAMOND_BIRD_UNLOCKED = "Diamond Bird Unlocked";

    private void Awake()
    {
        MakeSingleton();
        if (PlayerPrefs.HasKey("GameStartedForTheFirstTime"))
        {
            InitializeGame();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InitializeGame()
    {
        PlayerPrefs.SetInt("GameStartedForTheFirstTime", 1);
        PlayerPrefs.SetInt(HIGH_SCORE, 0);
        PlayerPrefs.SetInt(SELECTED_BIRD, 0);
        PlayerPrefs.SetInt(GREEN_BIRD, 0);
        PlayerPrefs.SetInt(RED_BIRD, 0);
        PlayerPrefs.SetInt(DIAMOND_BIRD, 0);
        PlayerPrefs.SetInt(DIAMOND_BIRD_UNLOCKED, 0);
}

    public void SetHighscore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighscore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }

    public void SetSelectedBird(int selectedBird)
    {
        PlayerPrefs.SetInt(SELECTED_BIRD, selectedBird);
    }

    public int GetSelectedBird()
    {
        return PlayerPrefs.GetInt(SELECTED_BIRD);
    }
    public void SetGreenBird(int value)
    {
        PlayerPrefs.SetInt(GREEN_BIRD, value);
    }

    public int GetGreenBird()
    {
        return PlayerPrefs.GetInt(GREEN_BIRD);
    }

    public void SetRedBird(int value)
    {
        PlayerPrefs.SetInt(RED_BIRD, value);
    }

    public int GetRedBird()
    {
        return PlayerPrefs.GetInt(RED_BIRD);
    }

    public void SetDiamondBird(int value)
    {
        PlayerPrefs.SetInt(DIAMOND_BIRD, value);
    }

    public int GetDiamondBird()
    {
        return PlayerPrefs.GetInt(DIAMOND_BIRD);
    }
    public void UnlockDiamondBird()
    {
        PlayerPrefs.SetInt(DIAMOND_BIRD_UNLOCKED, 1);
    }
    public int GetDiamondBirdUnlocked()
    {
        return PlayerPrefs.GetInt(DIAMOND_BIRD_UNLOCKED);
    }
}
