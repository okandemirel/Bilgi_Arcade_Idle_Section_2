using Assets.Scripts.Enums;
using Assets.Scripts.Keys;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

    #region Singleton

    public static EventManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    #endregion

    public UnityAction<JoystickInputParams> onInputDragged = delegate { };
    public UnityAction onInputReleased = delegate { };
    public UnityAction onInputTaken = delegate { };
    public UnityEvent onClick;

    public UnityAction onReset = delegate { };
    public UnityAction onPlay = delegate { };

    public UnityAction<int> onLevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };

    public UnityAction<GameSaveDataParams> onSaveGameData = delegate { };
    public UnityAction<GameStates> onUpdateGameState = delegate { };

    public UnityAction<CollectableTypes, int> onUpdateInGameEconomy = delegate { };
    public UnityAction<CollectableTypes, int> onUpdateUIInGameEconomy = delegate { };
}
