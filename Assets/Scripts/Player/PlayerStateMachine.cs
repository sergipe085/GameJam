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
    [SerializeField] private int rewindLength = 120;
    public RewindStruct rewindPosition;
    public List<RewindStruct> rewindStructArray = new List<RewindStruct>();

    protected override void Awake() {
        base.Awake();
        instance = this;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (OnGround()) {
            RewindStruct rewindStruct = new RewindStruct();
            rewindStruct.position = transform.position;

            if (!isRewinding) {
                rewindStructArray.Add(rewindStruct);
                if (rewindStructArray.Count > rewindLength) {
                    rewindStructArray.RemoveAt(0);
                }
                rewindPosition = rewindStructArray[0];
            }
        }
    }

    protected override StatesTypes GetCurrentState() {
        InputStruct input = InputManager.CaptureInput();


        if (input.rewind || isRewinding) {
            return StatesTypes.Rewind;
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
