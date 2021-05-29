using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : State
{
    public override void EnterState() {
        base.EnterState();

        Vector3 dir = Camera.main.transform.forward;
        Vector3 origin = Camera.main.transform.position;
        if (Physics.Raycast(origin, dir, out RaycastHit hit, 3.0f, 11)) {
            Button btn = hit.transform.GetComponent<Button>();
            btn?.Click();
        }
    }
}
