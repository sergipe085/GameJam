using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : State
{
    [Header("VALUES")]
    [SerializeField] private float speed = 10.0f;

    [Header("REFERENCES")]
    private Rigidbody   rig   = null;
    private InputStruct input;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    public override void Init() {
        base.Init();
    }

    public override void Tick() {
        base.Tick();

        input = InputManager.CaptureInput();

        Vector3 desiredVelocity = transform.forward * input.move.y + transform.right * input.move.x;
        rig.velocity = Vector3.Lerp(rig.velocity, desiredVelocity.normalized * speed, Time.fixedDeltaTime * 5);
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }
}
