using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public static BirdScript instance;

    [SerializeField]
    private Rigidbody2D myRigidBody;

    [SerializeField]
    private Animator anim;

    private float bounceSpeed = 4f;

    private bool didFlap = false;

    [HideInInspector]
    public bool isAlive = true;

    private Button flapButton;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip flapClip, diedClip;

    [HideInInspector]
    public int score;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        isAlive = true;
        score = 0;

        flapButton = GameObject.FindGameObjectWithTag("FlapButton").GetComponent<Button>();
        flapButton.onClick.AddListener(() => FlapTheBird());
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (myRigidBody.velocity.y >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                float angle = 0;
                angle = Mathf.Lerp(0, -70, -myRigidBody.velocity.y / 7);
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            if (didFlap)
            {
                //audioSource.clip = flapClip;
                audioSource.PlayOneShot(flapClip);
                didFlap = false;
                myRigidBody.velocity = new Vector2(0, bounceSpeed);
                anim.SetTrigger("flap");
            }
        }
    }

    public void FlapTheBird()
    {
        didFlap = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            if (isAlive) { 
                isAlive = false;
                anim.SetTrigger("birdDied");
                audioSource.PlayOneShot(diedClip);
                GameplayController.instance.PlayerDiedShowScore(score);
            }
        }
    }
}
