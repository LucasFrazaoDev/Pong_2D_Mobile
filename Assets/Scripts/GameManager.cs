using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        int difficultySelected = PlayerPrefs.GetInt("difficultySelected");
        int highscoreSelected = PlayerPrefs.GetInt("highscoreSelected");

        SettingDifficutlySelected(difficultySelected);
    }

    public void PlayerScore()
    {
        _playerScore++;
        _playerScoreText.text = _playerScore.ToString();

        StartCoroutine(ResetRound());
    }

    public void ComputerScore()
    {
        _computerScore++;
        _computerScoreText.text = _computerScore.ToString();

        StartCoroutine(ResetRound());
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator ResetRound()
    {
        ball.ResetPosition();
        yield return new WaitForSeconds(2f);
        ball.AddStartForce();
    }

    private void SettingDifficutlySelected(int difficulty)
    {
        if (difficulty == 1)
        {
            _computerPaddle.Speed = 16f;
            _computerPaddle.GetComponent<BouncySurface>().BounceStrength += 50f;
        }
    }
}
