using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : State
{
    [Header("REFERENCES")]
    private Animator anim;

    [Header("ATTACK ANIMATIONS")]
    private int attackIndex = 0;

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

        if (PlayerStateMachine.instance.isAttacking) return;

        attackIndex++;
        attackIndex = attackIndex >= 2 ? 0 : attackIndex;
        anim.SetTrigger("attack");
        anim.SetFloat("attackDir", attackIndex);

        CameraController.instance.StartScreenShake(0.3f, 0.06f, 1f);

        PlayerStateMachine.instance.isAttacking = true;
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
