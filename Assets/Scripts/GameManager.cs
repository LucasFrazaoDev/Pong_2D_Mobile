using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;

    [SerializeField] Paddle _playerPaddle;
    [SerializeField] Paddle _computerPaddle;

    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _computerScoreText;

    private int _playerScore;
    private int _computerScore;

    public void PlayerScore()
    {
        _playerScore++;
        _playerScoreText.text = _playerScore.ToString();

        ResetRound();
    }

    public void ComputerScore()
    {
        _computerScore++;
        _computerScoreText.text = _computerScore.ToString();

        ResetRound();
    }

    private void ResetRound()
    {
        _playerPaddle.ResetPosition();
        _computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartForce();
    }
}
