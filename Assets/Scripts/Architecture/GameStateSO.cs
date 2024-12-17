using UnityEngine;
using UnityEngine.Events;


public enum GameState
{
    MAIN_MENU,
    IN_GAME,
    PAUSED,
    GAME_OVER,
}

[CreateAssetMenu(menuName = "Template/GameStateSO")]
public class GameStateSO : ScriptableObject
{
    [SerializeField] private GameState _currentGameState;

    public UnityEvent OnGameStateChanged;


    public GameState CurrentGameState()
    {
        return _currentGameState;
    }

    public void SetGameState(GameState newGameState)
    {
        _currentGameState = newGameState;
        OnGameStateChanged.Invoke();
    }
}
