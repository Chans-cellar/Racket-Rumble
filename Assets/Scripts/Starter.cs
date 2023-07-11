using UnityEngine;

public class Starter : MonoBehaviour
{


    private GameController gameController;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        _animator = this.GetComponent<Animator>();
    }

    public void StartCountdown()
    {
        _animator.SetTrigger("StartCountdown");
    }

    public void StartGame()
    {
        this.gameController.StartGame();
    }
}
