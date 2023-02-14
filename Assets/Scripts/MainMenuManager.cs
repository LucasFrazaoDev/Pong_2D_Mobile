using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject panelMainMenu;
    [SerializeField] GameObject panelSetGame;

    #region MainMenu
    public void NewGame()
    {
        panelMainMenu.SetActive(false);
        panelSetGame.SetActive(true);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
    #endregion

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetGameBackToMainMenu()
    {
        panelMainMenu.SetActive(true);
        panelSetGame.SetActive(false);
    }
}
