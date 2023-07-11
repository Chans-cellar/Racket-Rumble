using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;

    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection = 0.5f;

    public bool stopped;

    public GameObject sparkVFX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (stopped)
        {
            return;
        }
        this.rb.MovePosition(this.rb.position  + direction * (speed * Time.fixedDeltaTime) );
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject sparks = Instantiate(this.sparkVFX, transform.position, transform.rotation);
        Destroy(sparks, 4f);
        
        
        if (other.CompareTag("Wall"))
        {
            direction.z = -direction.z;
        }

        if (other.CompareTag("Racket"))
        {
            Vector3 newDirection = (this.transform.position - other.transform.position).normalized;
            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);
            direction = newDirection;
        }

        
    }


    /* 
    // CODE SNIPPET FOR RACKET DIRECTION CHANGE
    Vector3 newDirection = (transform.position - other.transform.position).normalized;

    newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
    newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

    direction = newDirection;
    */

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(UnityEngine.Random.Range(-1f,1f));
        float signY = Mathf.Sign(UnityEngine.Random.Range(-1f, 1f));

        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signY);
    }

    public void Stop() {
        this.stopped = true;
    }

    public void Go() {
        ChooseDirection();
        this.stopped = false;
    }

}
