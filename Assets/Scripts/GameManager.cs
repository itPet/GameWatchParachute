using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Collider2D boatCollider;
    public Collider2D trooperCollider;
    public GameObject paratrooperPrefab;
    public Transform positionsA;
    public Transform positionsB;
    public Transform positionsC;
    GameObject newTrooper;

	// Use this for initialization
	void Start () {
        Debug.Log("Trooper Created");
        NewTrooper();
	}
	
    void NewTrooper() {
        newTrooper = Instantiate(paratrooperPrefab);
        newTrooper.GetComponent<ParatrooperController>().gameManager = this;
        trooperCollider = newTrooper.GetComponent<Collider2D>();

        int random = (int)Random.Range(1, 4);
        if (random == 1)    
            newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsA;
        else if (random == 2)
            newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsB;
        else if (random == 3)
            newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsC;
    }

    public bool TrooperSaved() {
        if (boatCollider.IsTouching(trooperCollider)) {
            NewTrooper();
            return true;
        } else {
            NewTrooper();
            return false;
        }

    }
}
