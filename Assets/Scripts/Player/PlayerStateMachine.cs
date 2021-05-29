using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public static PlayerStateMachine instance;

    [Header("STATES CHECKERS")]
    [HideInInspector] public bool isAttacking = false;
    [HideInInspector] public bool isRewinding = false;

    [Header("REWIND")]
    [SerializeField] private int rewindLength = 120;
    public List<RewindStruct> rewindPositions = new List<RewindStruct>();

    protected override void Awake() {
        base.Awake();
        instance = this;
    }

    protected override void Update()
    {
        base.Update();

        if (!isRewinding) {
            RewindStruct rewindStruct = new RewindStruct();

            rewindStruct.position = transform.position;
            rewindStruct.rotation = Camera.main.transform.parent.transform.rotation;
            rewindStruct.horizontal = PlayerController.instance.horizontal;
            rewindStruct.vertical = PlayerController.instance.vertical;

            rewindPositions.Add(rewindStruct);
            if (rewindPositions.Count > rewindLength) {
                rewindPositions.RemoveAt(0);
            }
        }
    }

    protected override StatesTypes GetCurrentState() {
        InputStruct input = InputManager.CaptureInput();


        if (input.rewind || isRewinding) {
            return StatesTypes.Rewind;
        }

        if (input.jump) {
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
}
