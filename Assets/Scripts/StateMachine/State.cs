using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual void Init() {
        
    }

    public virtual void Tick() {

    }

    public virtual void EnterState() {
        print("Enter on " + this.ToString());
    }

    public virtual void ExitState() {
        print("Exit from " + this.ToString());
    }
}
