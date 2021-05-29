using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    [Header("SCREENSHAKE")]
    private float ssTime  = 0.0f;
    private float ssForce = 0.0f;
    private float ssMult  = 0.0f;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, 5.0f * Time.deltaTime);

        ScreenShake();
    }

    public void StartScreenShake(float _time, float _force, float _mult) {
        ssTime  = _time;
        ssForce = _force;
        ssMult  = _mult;
    }

    private void ScreenShake() {
        if (ssTime > 0) {
            transform.localPosition += new Vector3(Random.Range(-ssForce, ssForce), Random.Range(-ssForce, ssForce), 0);
            ssForce *= ssMult;

            ssTime -= Time.deltaTime;
        }
    }
}
