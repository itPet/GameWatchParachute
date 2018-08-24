using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParatrooperController : MonoBehaviour {

    public Transform trooperPositions;
    int currentPosition = 0;
    float moveDelay = 0.5f;

    private void Start() {
        transform.position = trooperPositions.GetChild(currentPosition).position;
        StartCoroutine(MoveTrooper());
    }

    IEnumerator MoveTrooper() {
        while (true) {
            yield return new WaitForSeconds(moveDelay);
            if (currentPosition < trooperPositions.childCount - 1)
                currentPosition++;
            else
                currentPosition = 0;
            transform.position = trooperPositions.GetChild(currentPosition).position;
        }
    }

}
