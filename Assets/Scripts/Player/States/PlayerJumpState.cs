using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : State
{
    [Header("VALUES")]
    [SerializeField] private float jumpForce = 10.0f;

    [Header("REFERENCES")]
    private Rigidbody   rig   = null;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    public override void Init() {
        base.Init();
    }

    public override void Tick() {
        base.Tick();
    }

    public override void EnterState() {
        base.EnterState();

        rig.velocity = Vector3.zero;
        rig.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    public override void ExitState() {
        base.ExitState();
    }
}
