using UnityEngine;
using UnityEngine.Events;

public class ButtonAction : MonoBehaviour {
    public UnityEvent buttonAction = null;

    public void DoAction() {
        buttonAction.Invoke();
    }
}