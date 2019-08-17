using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;

    [SerializeField]
    private GameObject fadeCanvas;

    [SerializeField]
    private Animator anim;

    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeIn(string levelName)
    {
        StartCoroutine(FadeInAnimation(levelName));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutAnimation());
    }

    IEnumerator FadeInAnimation(string levelName)
    {
        fadeCanvas.SetActive(true);
        anim.Play("FadeIn");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(.7f);

        SceneManager.LoadScene(levelName, LoadSceneMode.Single);

        FadeOut();
    }

    IEnumerator FadeOutAnimation()
    {
        anim.Play("FadeOut");
        yield return new WaitForSeconds(1f);
        fadeCanvas.SetActive(false);
    }
}
