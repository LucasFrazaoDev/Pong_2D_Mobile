using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    private int _playerScore;
    private int _computerScore;

    public void PlayerScore()
    {
        _playerScore++;
        ball.ResetPosition();
    }

    public void ComputerScore()
    {
        _computerScore++;
        ball.ResetPosition();
    }
}
