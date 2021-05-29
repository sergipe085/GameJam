using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    [Header("REFERENCES")]
    private Animator anim;

    private void Awake()
    {
        anim = Camera.main.transform.parent.GetComponentInChildren<Animator>();
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void EnterState()
    {
        base.EnterState();

        anim.SetTrigger("attack");
        CameraController.instance.StartScreenShake(0.3f, 0.06f, 1f);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
