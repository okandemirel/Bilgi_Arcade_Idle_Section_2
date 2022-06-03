using Assets.Scripts.Enums;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class InGameEconomyManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        #endregion

        #region Private Variables

        [ShowInInspector] private int _wood, _stone, _gold;

        #endregion

        #endregion


        #region Event Subscriptions
        private void Start()
        {
            SubscribeEvents();

            DOVirtual.DelayedCall(.2f, GetEconomyData);
        }
        private void SubscribeEvents()
        {
            EventManager.Instance.onUpdateInGameEconomy += OnUpdateInGameEconomy;
        }

        private void UnsubscribeEvents()
        {
            EventManager.Instance.onUpdateInGameEconomy -= OnUpdateInGameEconomy;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void GetEconomyData()
        {
            if (ES3.FileExists())
            {
                if (ES3.KeyExists("Wood"))
                {
                    _wood = ES3.Load<int>("Wood");
                    EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(CollectableTypes.Wood, _wood);
                }
                if (ES3.KeyExists("Stone"))
                {
                    _stone = ES3.Load<int>("Stone");
                    EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(CollectableTypes.Stone, _stone);
                }
                if (ES3.KeyExists("Gold"))
                {
                    _gold = ES3.Load<int>("Gold");
                    EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(CollectableTypes.Gold, _gold);
                }
            }
        }

        private void OnUpdateInGameEconomy(CollectableTypes type, int value)
        {
            switch (type)
            {
                case CollectableTypes.Wood:
                    {
                        _wood += value;
                        ES3.Save("Wood", _wood);
                        EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(type, _wood);
                        break;
                    }
                case CollectableTypes.Stone:
                    {
                        _stone += value;
                        ES3.Save("Stone", _stone);
                        EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(type, _stone);
                        break;
                    }
                case CollectableTypes.Gold:
                    {
                        _gold += value;
                        ES3.Save("Gold", _gold);
                        EventManager.Instance.onUpdateUIInGameEconomy?.Invoke(type, _gold);
                        break;
                    }
            }
        }
    }
}
