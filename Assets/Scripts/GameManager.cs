using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Components")]
    public Ball ball;
    [SerializeField] private Paddle _playerPaddle;
    [SerializeField] private Paddle _computerPaddle;

    [Header("UI GameObjects")]
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _computerScoreText;
    [SerializeField] private GameObject _panelFinishedGame;
    [SerializeField ] private TextMeshProUGUI _mensageText;

    private int _highscore; 
    private int _playerScore;
    private int _computerScore;

    private void Start()
    {
        int difficultySelected = PlayerPrefs.GetInt("difficultySelected");
        int highscoreSelected = PlayerPrefs.GetInt("highscoreSelected");

        SettingDifficutlySelected(difficultySelected);
        SettingHighscoreSelected(highscoreSelected);
    }

    public void PlayerScore()
    {
        _playerScore++;
        _playerScoreText.text = _playerScore.ToString();

        CheckingForWinner();
        StartCoroutine(ResetRound());
    }

    public void ComputerScore()
    {
        _computerScore++;
        _computerScoreText.text = _computerScore.ToString();

        CheckingForWinner();
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
            _computerPaddle.Speed = 18f;
            _computerPaddle.GetComponent<BouncySurface>().BounceStrength += 50f;
        }
    }

    private void SettingHighscoreSelected(int score)
    {
        switch (score)
        {
            case 0:
                _highscore = 5;
                break;
                case 1:
                _highscore = 9;
                break;
                case 2:
                _highscore = 15;
                break;
        }
    }

    private void CheckingForWinner()
    {
        if (_playerScore == _highscore)
        {
            _panelFinishedGame.SetActive(true);
            _mensageText.text = "Congratulations, you win!!";
        }
        else if (_computerScore == _highscore)
        {
            _panelFinishedGame.SetActive(true);
            _mensageText.text = "You lose!";
        }
    }
}
