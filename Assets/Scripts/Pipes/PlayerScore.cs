using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private GameObject player;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip pointClip;

    private bool scored;
    private BirdScript script;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = player.GetComponent<AudioSource>();
        script = player.GetComponent<BirdScript>();
        scored = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.localPosition.x-1.2f > transform.localPosition.x) && !scored)
        {
            scored = true;
            audioSource.PlayOneShot(pointClip);
            script.score++;
            GameplayController.instance.SetScore(script.score);
        }
    }
}
