using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Init() {
        Debug.Log("Init Idle");
    }

    public override void Tick() {
        Debug.Log("Tick Idle");
    }
}
