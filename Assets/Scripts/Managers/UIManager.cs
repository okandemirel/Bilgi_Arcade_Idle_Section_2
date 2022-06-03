using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region Self Variables


    #region Serialized Variables

    [SerializeField] private GameObject startPanel, winPanel, failPanel, joystickPanel;
    [SerializeField] private TextMeshProUGUI woodText, stoneText, goldText;

    #endregion

    #endregion


    #region Event Subscriptions

    private void Start()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onPlay += OnOpenJoystickPanel;
        EventManager.Instance.onPlay += OnCloseStartPanel;
        EventManager.Instance.onUpdateUIInGameEconomy += OnUpdateUIInGameEconomy;
    }

    private void UnsubscribeEvents()
    {
        EventManager.Instance.onPlay -= OnOpenJoystickPanel;
        EventManager.Instance.onPlay -= OnCloseStartPanel;
        EventManager.Instance.onUpdateUIInGameEconomy -= OnUpdateUIInGameEconomy;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }


    #endregion

    private void OnOpenJoystickPanel()
    {
        joystickPanel.SetActive(true);
    }

    private void OnCloseStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void Play()
    {
        EventManager.Instance.onPlay?.Invoke();
    }

    private void OnUpdateUIInGameEconomy(CollectableTypes type, int value)
    {
        switch (type)
        {
            case CollectableTypes.Wood:
                {
                    woodText.DOText(value.ToString(), .75f, true, ScrambleMode.Numerals);
                    break;
                }
            case CollectableTypes.Stone:
                {
                    stoneText.DOText(value.ToString(), .75f, true, ScrambleMode.Numerals);
                    break;
                }
            case CollectableTypes.Gold:
                {
                    goldText.DOText(value.ToString(), .75f, true, ScrambleMode.Numerals);
                    break;
                }
        }
    }
}
