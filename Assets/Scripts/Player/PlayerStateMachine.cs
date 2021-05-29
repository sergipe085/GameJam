using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public static PlayerStateMachine instance;

    [Header("CORE")]
    [SerializeField] LayerMask groundLayer;

    [Header("STATES CHECKERS")]
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isRewinding = false;

    [Header("REWIND")]
    public Vector3? rewindLocation = null;

    protected override void Awake() {
        base.Awake();
        instance = this;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override StatesTypes GetCurrentState() {
        InputStruct input = InputManager.CaptureInput();


        if (input.rewind || isRewinding) {
            return StatesTypes.Rewind;
        }

        if (input.interact) {
            return StatesTypes.Interact;
        }

        if (input.jump && OnGround()) {
            return StatesTypes.Jump;
        }

        if (input.attack) {
            return StatesTypes.Attack;
        }

        if (input.move.magnitude != 0 && !isRewinding) {
            return StatesTypes.Walk;
        }

        return StatesTypes.Idle;
    }

    private bool OnGround() {
        return Physics.Raycast(transform.position, Vector3.down, 0.2f, groundLayer);
    }
}
