using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : State
{
    [Header("REFERENCES")]
    private Rigidbody rig = null;

    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    public override void Init() {
        base.Init();
    }

    public override void Tick() {
        base.Tick();

        rig.velocity = Vector3.Lerp(rig.velocity, Vector3.zero, Time.fixedDeltaTime * 5);
    }

    public override void EnterState() {
        base.EnterState();
    }

    public override void ExitState() {
        base.ExitState();
    }
}
