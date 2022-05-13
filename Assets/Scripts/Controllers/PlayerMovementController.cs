using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    #region Self Variables

    #region Public Variables

    public MovementTypes Types;

    #endregion

    #region Serialized Variables

    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private float speed = 6;

    #endregion


    #region Private Variables

    private bool _isReadyToMove;


    private float _inputValues;

    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove)
        {
            MovePlayerVelocity();
        }
        else
        {
            StopPlayer();
        }
    }

    public void UpdateInputData(HorizontalnputParams inputValues)
    {
        _inputValues = inputValues.HorizontalInputValue;
    }

    public void ActivateMovement()
    {
        _isReadyToMove = true;
    }

    public void DeactivateMovement()
    {
        _isReadyToMove = false;
    }

    private void MovePlayerVelocity()
    {
        rigidbody.velocity = new Vector3(_inputValues * speed, rigidbody.velocity.y, _inputValues * speed);
    }
    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }
}
