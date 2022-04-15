using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;

    #endregion

    #endregion

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onInputDragged += OnInputDragged;
        EventManager.Instance.onInputReleased += OnInputReleased;
    }
    private void UnSubscribeEvents()
    {
        EventManager.Instance.onInputDragged -= OnInputDragged;
        EventManager.Instance.onInputReleased -= OnInputReleased;
    }
    private void OnDisable()
    {
        UnSubscribeEvents();
    }
    private void OnInputDragged(Vector2 inputValues)
    {
        movementController.UpdateInputData(inputValues);
        movementController.ActivateMovement();
    }

    private void OnInputReleased()
    {
        movementController.DeactivateMovement();
    }
}
