using System.Collections;
using UnityEngine;

public class MovementAction : MonoBehaviour {
    [SerializeField] private float moveDuration;

    [SerializeField] private Transform[] newTransforms;
    private int currentIndex = 0;

    public void Move() {
        StartCoroutine(MoveEnumerator(transform.position, transform.rotation));
    }

    private IEnumerator MoveEnumerator(Vector3 _initialPosition, Quaternion _initialRotation) {
        float time = 0;

        while(time <= moveDuration) {
            float t = time / moveDuration;

            transform.position = Vector3.Lerp(_initialPosition, newTransforms[currentIndex].position, t);
            transform.rotation = Quaternion.Lerp(_initialRotation, newTransforms[currentIndex].rotation, t);

            time += Time.deltaTime;
            yield return null;
        }

        currentIndex++;
    }
}