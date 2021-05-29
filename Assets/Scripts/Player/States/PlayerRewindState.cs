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
        
    }

    public override void EnterState()
    {
        StartCoroutine(Rewind(transform.position));

        InputManager.EnableInput(false);
    }

    public override void ExitState()
    {
        StartCoroutine(ResetRewind());
        PlayerStateMachine.instance.rewindStructArray.Clear();
    }

    private IEnumerator Rewind(Vector3 _initialPosition) {
        PlayerStateMachine.instance.isRewinding = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<ExtraGravity>().enabled = false;

        RewindStruct rewindStruct = PlayerStateMachine.instance.rewindPosition;

        float time = 0f;

        while(time <= rewindTime) {
            float t = time / rewindTime;

            volume = FindObjectOfType<PostProcessVolume>().GetComponent<PostProcessVolume>();
            volume.profile.TryGetSettings(out lensDistortion);
            lensDistortion.intensity.value = Mathf.Lerp(0f, -100f, t);

            transform.position = Vector3.Lerp(_initialPosition, rewindStruct.position + Vector3.up, t);

            time += Time.deltaTime;
            yield return null;
        }

        PlayerStateMachine.instance.isRewinding = false;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<ExtraGravity>().enabled = true;
    }

    private IEnumerator ResetRewind() {
        float time = 0;

        while (time <= 0.3f)
        {
            float t = time / 0.3f;

            lensDistortion.intensity.value = Mathf.Lerp(-100, 0, t);

            time += Time.deltaTime;
            yield return null;
        }

        InputManager.EnableInput(true);
    }
}

[Serializable]
public struct RewindStruct {
    public Vector3 position;
    public Quaternion rotation;
    public float horizontal;
    public float vertical;
}
