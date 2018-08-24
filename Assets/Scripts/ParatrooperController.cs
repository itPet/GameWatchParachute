using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParatrooperController : MonoBehaviour {
    
    public Transform trooperPositions;
    public GameManager gameManager;
    int currentPosition = 0;
    float moveDelay = 0.2f;

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
            yield return new WaitForSeconds(0.05f);
            DestroyTrooper();
        }
    }

    void DestroyTrooper() {
        if (currentPosition == trooperPositions.childCount - 1) {
            if (gameManager.TrooperSaved()) {
                Debug.Log("Trooper saved!");
            }
            else {
                Debug.Log("Trooper died!");
            }
            Destroy(gameObject);
        }
    }


}
