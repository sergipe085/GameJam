using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRewindState : State
{
    List<RewindStruct> positions;

    public override void EnterState()
    {
        positions = PlayerStateMachine.instance.rewindPositions;
        
        StartCoroutine(Rewind());

        InputManager.EnableInput(false);
    }

    private IEnumerator Rewind() {
        PlayerStateMachine.instance.isRewinding = true;

        for (int i = positions.Count - 1; i > 0; i--) {
            transform.position = Vector3.Lerp(transform.position, positions[i].position, 20f * Time.deltaTime);
            PlayerController.instance.horizontal = positions[i].horizontal;
            PlayerController.instance.vertical = positions[i].vertical;

            yield return null;
        }
        PlayerStateMachine.instance.rewindPositions.Clear();
        PlayerStateMachine.instance.isRewinding = false;

        InputManager.EnableInput(true);
    }
}

public struct RewindStruct {
    public Vector3 position;
    public Quaternion rotation;
    public float horizontal;
    public float vertical;
}
