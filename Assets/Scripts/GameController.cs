using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


    public TMP_Text scoreTextLeft;
    public TMP_Text scoreTextRight;


    private bool started;
    private int scoreLeft;
    private int scoreRight;

    private Vector3 startingPosition;


    public GameObject ball;
    private BallController ballController;


    public Starter starter;


    // Start is called before the first frame update
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.started)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame() {
        this.ballController.Go();
    }

    public void ScoreGoalLeft() {
        this.scoreRight += 1;
        UpdateUI();
     
    }

    public void ScoreGoalRight() {
        this.scoreLeft += 1;
        UpdateUI();
       
    }


    private void UpdateUI()
    {
        ResetBall();
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }
    
    
    private void ResetBall() {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();

    }
    

}
