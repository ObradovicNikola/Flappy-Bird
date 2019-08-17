using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D myRigidBody = null;

    [SerializeField]
    private float speed = -2.5f;

    private void Awake()
    {
        myRigidBody.velocity = new Vector2(speed, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
