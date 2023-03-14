using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] GameObject _panelMainMenu;
    [SerializeField] GameObject _panelSetGame;

    [Header("Toggle Groups")]
    [SerializeField] ToggleGroup _difficultyToggleGroup;
    [SerializeField] ToggleGroup _highScoreToggleGroup;

    [Header("Start Game Button")]
    [SerializeField] Button _startGameButton;

    private void Start()
    {
        // Verifica se os toggles est�o marcados ao iniciar o jogo
        CheckTogglesSelected();
    }

    #region MainMenuScreenMethods
    public void NewGame()
    {
        _panelMainMenu.SetActive(false);
        _panelSetGame.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion

    #region GameSetScreen&LogicMethods
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetGameBackToMainMenu()
    {
        _panelMainMenu.SetActive(true);
        _panelSetGame.SetActive(false);
    }

    public void OnDifficultyToggleChanged()
    {
        int difficultySelected = GetSelectedToggleIndex(_difficultyToggleGroup);
        PlayerPrefs.SetInt("difficultySelected", difficultySelected);

        CheckTogglesSelected();
    }

    public void OnHighScoreToggleChanged()
    {
        int highScoreSelected = GetSelectedToggleIndex(_highScoreToggleGroup);
        PlayerPrefs.SetInt("highscoreSelected", highScoreSelected);

        CheckTogglesSelected();
    }

    private int GetSelectedToggleIndex(ToggleGroup toggleGroup)
    {
        // Retorna o valor inteiro indicando o toggle selecionado
        // 0 e 1 para dificuldade; de 0 a 2 para pontua��o m�xima 
        Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                return i;
            }
        }

        return 0;
    }

    private void CheckTogglesSelected()
    {
        // Verifica se os dois toggles est�o marcados
        bool difficultySelected = _difficultyToggleGroup.AnyTogglesOn();
        bool highScoreSelected = _highScoreToggleGroup.AnyTogglesOn();
        // Debug.Log("Testando m�todo");

        // Habilita ou desabilita o bot�o de iniciar o jogo
        _startGameButton.interactable = difficultySelected && highScoreSelected;
    }

    #endregion
}
