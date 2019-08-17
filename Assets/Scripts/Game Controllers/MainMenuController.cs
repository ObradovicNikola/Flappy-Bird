using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdSelected, isRedBirdSelected, isDiamondBirdSelected;

    private void Awake()
    {
        MakeInstance();
    }
    // Start is called before the first frame update
    void Start()
    {
        birds[GameController.instance.GetSelectedBird()].SetActive(true);
        FindSelectedBird();
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void FindSelectedBird()
    {
        if(GameController.instance.GetRedBird() == 1)
        {
            isRedBirdSelected = true;
        } else if(GameController.instance.GetGreenBird() == 1)
        {
            isGreenBirdSelected = true;
        } else if (GameController.instance.GetDiamondBird() == 1)
        {
            isDiamondBirdSelected = true;
        }
    }
    public void PlayGame()
    {
        SceneFader.instance.FadeIn("Gameplay");
    }

    public void ChangeBird()
    {
        if (GameController.instance.GetSelectedBird() == 0)
        {
            GameController.instance.SetSelectedBird(1);
            birds[0].SetActive(false);
            birds[2].SetActive(false);
            birds[1].SetActive(true);
            birds[3].SetActive(false);
        } else if (GameController.instance.GetSelectedBird() == 1)
        {
            GameController.instance.SetSelectedBird(2);
            birds[1].SetActive(false);
            birds[0].SetActive(false);
            birds[2].SetActive(true);
            birds[3].SetActive(false);
        } else if ((GameController.instance.GetSelectedBird() == 2) && GameController.instance.GetDiamondBirdUnlocked() == 1)
        {
            GameController.instance.SetSelectedBird(3);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            birds[3].SetActive(true);
            birds[0].SetActive(false);
        } else
        {
            GameController.instance.SetSelectedBird(0);
            birds[1].SetActive(false);
            birds[2].SetActive(false);
            birds[0].SetActive(true);
            birds[3].SetActive(false);
        }
    }
}
