using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjects : MonoBehaviour
{
    public static PersistentObjects instance;

    private void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
