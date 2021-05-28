using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "a", fileName = "")]
public class WalkState : State
{
    public override void Init() {
        Debug.Log("Init Walk");
    }

    public override void Tick() {
        Debug.Log("Tick Walk");
    }
}
