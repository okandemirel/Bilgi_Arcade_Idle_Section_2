using Assets.Scripts.Enums;
//using RayFire;
using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerPhysicsController physicsController;
    [SerializeField] private PlayerAnimationController animationController;

    #endregion

    #endregion

    private void Start()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventManager.Instance.onInputTaken += OnInputTaken;
        EventManager.Instance.onInputDragged += OnInputDragged;
        EventManager.Instance.onInputReleased += OnInputReleased;
    }

    private void UnSubscribeEvents()
    {
        EventManager.Instance.onInputTaken -= OnInputTaken;
        EventManager.Instance.onInputDragged -= OnInputDragged;
        EventManager.Instance.onInputReleased -= OnInputReleased;
    }
    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void OnInputTaken()
    {
        animationController.SetAnimationStateToWalk();
    }
    private void OnInputDragged(JoystickInputParams inputValues)
    {
        movementController.UpdateInputData(inputValues);
        movementController.ActivateMovement();
    }

    private void OnInputReleased()
    {
        movementController.DeactivateMovement();
        animationController.SetAnimationStateToIdle();
    }

    public void ChangeAnimationState(AnimationStates state)
    {
        animationController.ChangeAnimationState(state);
    }

    //public void CutCuttable(RayfireRigid rigid)
    //{
    //    rigid.ApplyDamage(15, new Vector3(rigid.transform.position.x, 0, rigid.transform.position.z), 5);
    //}
}
