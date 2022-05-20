using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [Header("Manager")] [SerializeField] private PlayerManager manager;
    [Space]
    [SerializeField] private Animator animator;

    #endregion

    #region Private Variables

    private const string Idle = "Idle";
    private const string Walk = "Walk";


    #endregion

    #endregion

    public void SetAnimationStateToIdle()
    {
        animator.SetTrigger(Idle);
    }

    public void SetAnimationStateToWalk()
    {
        animator.SetTrigger(Walk);
    }
}
