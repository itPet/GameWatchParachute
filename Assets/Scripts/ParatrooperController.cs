using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParatrooperController : MonoBehaviour {
    
    public Transform trooperPositions;
    public GameManager gameManager;
    int currentPosition = 0;
    public float moveDelay;

    private void Start() {
        transform.position = trooperPositions.GetChild(currentPosition).position;
        StartCoroutine(MoveTrooper());
    }

    IEnumerator MoveTrooper() {
        while (true) {
            yield return new WaitForSeconds(moveDelay);
            if (currentPosition < trooperPositions.childCount - 1) {
                currentPosition++;
                transform.position = trooperPositions.GetChild(currentPosition).position;
            }
            if (LastPosition())
                gameManager.TrooperLanded(gameObject);
        }
    }

    bool LastPosition() {
        return (currentPosition == trooperPositions.childCount - 1);
    }
}
