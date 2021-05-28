using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual void Init() {
        print("INIT");
    }

    public virtual void Tick() {

    }
}
