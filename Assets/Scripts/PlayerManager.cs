using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;

    #endregion

    #endregion


    private void Update()
    {
        if (Input.anyKey)
        {
            movementController.UpdateInputData(InputValues);
            movementController.ActivateMovement();
        }
        else
        {
            movementController.DeactivateMovement();
        }
    }

    private Vector2 InputValues => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

}
