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

            //Debug.LogWarning(Types);

            //switch (Types)
            //{

            //    case MovementTypes.Velocity:
            //        {
            //            MovePlayerVelocity();
            //            break;
            //        }
            //    case MovementTypes.AddForce:
            //        {
            //            MovePlayerAddForce();
            //            break;
            //        }
            //    case MovementTypes.Transform:
            //        {
            //            MovePlayerWithTransform();
            //            break;
            //        }
            //}

            MovePlayerVelocity();
        }
        else
        {
            StopPlayer();
        }
    }

    public void UpdateInputData(Vector2 inputValues)
    {
        _inputValues = inputValues;
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

    private void MovePlayerAddForce()
    {
        rigidbody.AddForce(new Vector3(_inputValues.x * speed, rigidbody.velocity.y, _inputValues.y * speed), ForceMode.Force);
    }

    private void MovePlayerWithTransform()
    {
        transform.position += new Vector3(_inputValues.x * speed, 0, _inputValues.y * speed);
    }

    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }
}
