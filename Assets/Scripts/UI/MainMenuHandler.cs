using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameStateSO GameStateSO;

    public void OnPlayButtonPress()
    {
        GameStateSO.SetGameState(GameState.IN_GAME);
        SceneManager.LoadScene("Main Game Scene");
    }

    public void OnOptionsButtonPress()
    {

    }
    public void OnQuitButtonPress()
    {
        Application.Quit();
    }
}
