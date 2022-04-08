using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    #region Self Variables

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
            MovePlayer();
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

    private void MovePlayer()
    {
        rigidbody.velocity = new Vector3(_inputValues.x * speed, rigidbody.velocity.y, _inputValues.y * speed);
    }

    private void StopPlayer()
    {
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
    }
}
