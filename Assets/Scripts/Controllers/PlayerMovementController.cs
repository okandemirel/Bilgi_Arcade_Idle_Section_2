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


    private Vector2 _inputValues;

    #endregion

    #endregion


    private void FixedUpdate()
    {
        if (_isReadyToMove)
        {
            MovePlayerVelocity();
            RotatePlayer();
        }
        else
        {
            StopPlayer();
        }
    }

    public void UpdateInputData(JoystickInputParams inputValues)
    {
        _inputValues = new Vector2(inputValues.HorizontalInputValue, inputValues.VerticalInputValue);
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
        rigidbody.velocity = new Vector3(_inputValues.x * speed, rigidbody.velocity.y, _inputValues.y * speed);
    }
    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }

    private void RotatePlayer()
    {
        var moveDirection = new Vector3(_inputValues.x,
            0,
            _inputValues.y);
        rigidbody.MoveRotation(Quaternion.LookRotation(moveDirection, Vector3.up));
    }
}
