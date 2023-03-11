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
    private int _difficultySelected;
    private int _highScoreSelected;

    [Header("Panels")]
    [SerializeField] GameObject _panelMainMenu;
    [SerializeField] GameObject _panelSetGame;

    [Header("Toggle Groups")]
    [SerializeField] ToggleGroup _difficultyToggleGroup;
    [SerializeField] ToggleGroup _highScoreToggleGroup;

    private void Start()
    {
        _difficultySelected = 0;
        _highScoreSelected = 0;
    }

    #region MainMenu
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

    #region GameSet
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
        _difficultySelected = GetSelectedToggleIndex(_difficultyToggleGroup);
        Debug.Log("Selected toggle index: " + _difficultySelected);
    }

    public void OnHighScoreToggleChanged()
    {
        _highScoreSelected = GetSelectedToggleIndex(_highScoreToggleGroup);
        Debug.Log("Toggle index selecionado: " + _highScoreSelected);
    }

    private int GetSelectedToggleIndex(ToggleGroup toggleGroup)
    {
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

    #endregion
}
