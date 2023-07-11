using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode up;
    public KeyCode down;

    private Rigidbody rb;

    public bool isPlayer = true;

    private Transform ballTransform;
    private Rigidbody ballRB;
    private BallController _ballController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballTransform = GameObject.FindGameObjectWithTag("Ball").transform;
        ballRB = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        _ballController = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
    }

    //float calculateXDist(float)
    // Update is called once per frame

    void Update()
    {

        if (this.isPlayer)
        {
            MoveByPlayer();
        }
        else
        {
            Debug.Log(Mathf.Sign(ballRB.velocity.x) == 1);
            if (!_ballController.stopped && Mathf.Sign(ballRB.velocity.x)== 1 )
            {
                MoveByComputer();

            }
           
        }
    }
    

    void MoveByPlayer()
        {
            bool upKeyPressed = Input.GetKey(this.up);
            bool downKeyPressed = Input.GetKey(this.down);

            if (upKeyPressed)
            {
                rb.velocity = Vector3.forward * speed;
            }

            if (downKeyPressed)
            {
                rb.velocity = Vector3.back * speed;
            }

            if (!upKeyPressed && !downKeyPressed)
            {
                rb.velocity = Vector3.zero;
            }
        }

        void MoveByComputer()
        {
            if (ballTransform.position.z > transform.position.z)
            {
                rb.velocity = Vector3.forward * speed;
            }

            else if (ballTransform.position.z < transform.position.z)
            {
                rb.velocity = Vector3.back * speed;
            }

            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

