using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game Components")]
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle _playerPaddle;
    [SerializeField] private Paddle _computerPaddle;

    [Header("UI GameObjects")]
    [SerializeField] private TextMeshProUGUI _playerScoreText;
    [SerializeField] private TextMeshProUGUI _computerScoreText;
    [SerializeField] private TextMeshProUGUI _mensageText;
    [SerializeField] private GameObject _panelFinishedGame;
    [SerializeField] private GameObject _panelPaused;
    [SerializeField] private Button _pauseButton;

    private int _highscore; 
    private int _playerScore;
    private int _computerScore;
    private bool _isPaused;

    private void Start()
    {
        int difficultySelected = PlayerPrefs.GetInt("difficultySelected");
        int highscoreSelected = PlayerPrefs.GetInt("highscoreSelected");

        SettingDifficutlySelected(difficultySelected);
        SettingHighscoreSelected(highscoreSelected);
    }

    #region UILogicMethods
    public void ButtonPauseGame()
    {
        Time.timeScale = 0f;
        _isPaused = true;
        _panelPaused.SetActive(true);
    }

    public void ButtonResumeGame()
    {
        Time.timeScale = 1f;
        _isPaused = false;
        _panelPaused.SetActive(false);
    }

    public void RestartGame()
    {
        if (_isPaused)
        {
            Time.timeScale = 1f;
            _isPaused = false;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        if (_isPaused)
        {
            Time.timeScale = 1f;
            _isPaused = false;
        }
        SceneManager.LoadScene(0);
    }
    #endregion

    #region ScoreMethods
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

    private IEnumerator ResetRound()
    {
        ball.ResetPosition();

        if (_panelFinishedGame.activeSelf)
            yield break;

        yield return new WaitForSeconds(2f);
        ball.AddStartForce();
    }

    private void CheckingForWinner()
    {
        if (_playerScore == _highscore)
        {
            _pauseButton.enabled = false;
            _panelFinishedGame.SetActive(true);
            _mensageText.text = "Congratulations, you win!!";
        }
        else if (_computerScore == _highscore)
        {
            _pauseButton.enabled = false;
            _panelFinishedGame.SetActive(true);
            _mensageText.text = "You lose!";
        }
    }
    #endregion

    #region GameSettingsMethods
    private void SettingDifficutlySelected(int difficulty)
    {
        if (difficulty == 1)
        {
            _computerPaddle.Speed = 20f;
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
                _highscore = 12;
                break;
        }
    }
    #endregion
}
