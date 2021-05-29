using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerRewindState : State
{

    [SerializeField] private float rewindTime;

    private LensDistortion lensDistortion;
    private PostProcessVolume volume;

    public override void Init()
    {
        volume = GameObject.FindObjectOfType<PostProcessVolume>().GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out lensDistortion);
    }

    public override void EnterState()
    {
        if (PlayerStateMachine.instance.rewindLocation == null) {
            PlayerStateMachine.instance.rewindLocation = transform.position;
            CameraController.instance.StartScreenShake(0.2f, 0.02f, 1.0f);
            StartCoroutine(CantRewind());
            return;
        }

        StartCoroutine(Rewind(transform.position));

        InputManager.EnableInput(false);
    }

    private IEnumerator CantRewind() {
        yield return StartCoroutine(RewindEffect(0.1f, 0, 60));
        yield return StartCoroutine(RewindEffect(0.1f, 60, 0));
    }

    private IEnumerator Rewind(Vector3 _initialPosition) {
        PlayerStateMachine.instance.isRewinding = true;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Collider>().enabled = false;
        GetComponent<ExtraGravity>().enabled = false;

        Vector3 rewindLocation = PlayerStateMachine.instance.rewindLocation.Value;

        float time = 0f;
        while (time <= rewindTime) {
            float t = time / rewindTime;

            volume = FindObjectOfType<PostProcessVolume>().GetComponent<PostProcessVolume>();
            volume.profile.TryGetSettings(out lensDistortion);
            lensDistortion.intensity.value = Mathf.Lerp(0f, -100f, t);

            transform.position = Vector3.Lerp(_initialPosition, rewindLocation + Vector3.up, t);

            time += Time.deltaTime;
            yield return null;
        }

        PlayerStateMachine.instance.isRewinding = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<ExtraGravity>().enabled = true;
        PlayerStateMachine.instance.rewindLocation = null;

        yield return StartCoroutine(RewindEffect(0.3f, -100, 0));
    }

    public IEnumerator RewindEffect(float duration, float from, float to) {
        float time = 0;

        while (time <= duration)
        {
            float t = time / duration;

            lensDistortion.intensity.value = Mathf.Lerp(from, to, t);

            time += Time.deltaTime;
            yield return null;
        }

        InputManager.EnableInput(true);
    }
}
