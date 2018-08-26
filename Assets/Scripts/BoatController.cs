using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

    public Transform boatPositions;
    SpriteRenderer spriteRenderer;
    int currentPosition = 1;

    private void Start() {
        transform.position = boatPositions.GetChild(currentPosition).position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        InputsController.ClickedLeft += MoveLeft;
        InputsController.ClickedRight += MoveRight;
    }

    private void OnDisable() {
        InputsController.ClickedLeft -= MoveLeft;
        InputsController.ClickedRight -= MoveRight;
    }

    void MoveLeft() {
        if (currentPosition > 0)
            currentPosition--;
        
        transform.position = boatPositions.GetChild(currentPosition).position;
        spriteRenderer.flipX = false;
    }

    void MoveRight() {
        if (currentPosition < boatPositions.childCount - 1)
            currentPosition++;
        
        transform.position = boatPositions.GetChild(currentPosition).position;
        spriteRenderer.flipX = true;
    }
}
