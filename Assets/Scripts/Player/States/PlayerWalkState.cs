using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : State
{
    [Header("VALUES")]
    [SerializeField] private float speed = 10.0f;
    private Vector3 currentVel = Vector3.zero;

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
    }

    public override void FixedTick() {
        Vector3 desiredVelocity = transform.forward * input.move.y + transform.right * input.move.x;
        desiredVelocity.Normalize();

        rig.velocity = Vector3.Lerp(rig.velocity, new Vector3(desiredVelocity.x * speed, rig.velocity.y, desiredVelocity.z * speed), Time.deltaTime * 10);
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }
}
