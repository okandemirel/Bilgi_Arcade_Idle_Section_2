using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityTemplateProjects.Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public CD_Input InputData;
        [Header("Additional Variables")] public bool IsAvailableForTouch;

        #endregion

        #region Serialized Variables

        [SerializeField] private bool isFirstTimeTouchTaken;
        [SerializeField] private Joystick joystick;

        #endregion

        #region Private Variables

        private bool _isTouching;

        private float _currentVelocity; //ref type
        private Vector2? _mousePosition; //ref type
        private Vector3 _moveVector; //ref type

        #endregion

        #endregion

        private void OnEnable()
        {
            EventManager.Instance.onReset += ResetData;
            EventManager.Instance.onPlay += OnPlay;
        }

        private void OnDisable()
        {
            EventManager.Instance.onReset -= ResetData;
            EventManager.Instance.onPlay -= OnPlay;
        }

        private void Update()
        {
            if (!IsAvailableForTouch) return;

            if (Input.GetMouseButtonUp(0))
            {
                _isTouching = false;

                EventManager.Instance.onInputReleased?.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                _isTouching = true;
                EventManager.Instance.onInputTaken?.Invoke();
                if (!isFirstTimeTouchTaken)
                {
                    isFirstTimeTouchTaken = true;
                    //onFirstTimeTouchTaken?.Invoke();
                }

                _mousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                if (_isTouching)
                {
                    if (_mousePosition != null)
                    {
                        //Vector2 mouseDeltaPos = (Vector2)Input.mousePosition - _mousePosition.Value;


                        //if (mouseDeltaPos.x > InputData.Data.HorizontalInputSpeed)
                        //    _moveVector.x = InputData.Data.HorizontalInputSpeed / 10f * mouseDeltaPos.x;
                        //else if (mouseDeltaPos.x < -InputData.Data.HorizontalInputSpeed)
                        //    _moveVector.x = -InputData.Data.HorizontalInputSpeed / 10f * -mouseDeltaPos.x;
                        //else
                        //    _moveVector.x = Mathf.SmoothDamp(_moveVector.x, 0f, ref _currentVelocity,
                        //        InputData.Data.HorizontalInputClampStopValue);

                        //_mousePosition = Input.mousePosition;

                        //EventManager.Instance.onInputDragged?.Invoke(new HorizontalnputParams()
                        //{
                        //    HorizontalInputValue = _moveVector.x,
                        //    HorizontalInputClampNegativeSide = InputData.Data.HorizontalInputClampNegativeSide,
                        //    HorizontalInputClampPositiveSide = InputData.Data.HorizontalInputClampPositiveSide
                        //});

                        EventManager.Instance.onInputDragged?.Invoke(new JoystickInputParams()
                        {
                            HorizontalInputValue = joystick.Horizontal,
                            VerticalInputValue = joystick.Vertical,
                            HorizontalInputClampNegativeSide = InputData.Data.HorizontalInputClampNegativeSide,
                            HorizontalInputClampPositiveSide = InputData.Data.HorizontalInputClampPositiveSide
                        });
                    }
                }
            }
        }

        private void OnPlay()
        {
            IsAvailableForTouch = true;
        }

        private bool IsPointerOverUIElement()
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            return results.Count > 0;
        }

        private void ResetData()
        {
            _isTouching = false;
            isFirstTimeTouchTaken = false;
        }
    }
}