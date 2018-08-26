using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Collider2D boatCollider;
    public GameObject paratrooperPrefab;
    public Transform positionsA;
    public Transform positionsB;
    public Transform positionsC;
    public TextMesh scoreLabel;
    public LivesController livesController;
    public float moveDelay = 1f;
    public float reduceMoveDelay = 0.1f;
    public int spawnDelay = 7;
    public int nextLevel = 3;
    GameObject newTrooper;
    int score = 0;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnNewTroopers());
    }

    IEnumerator SpawnNewTroopers() {
        while (true) {
            NewTrooper();
            yield return new WaitForSeconds((moveDelay * spawnDelay));
        }
    }

    void NewTrooper() {
        newTrooper = Instantiate(paratrooperPrefab);
        newTrooper.GetComponent<ParatrooperController>().gameManager = this;
        newTrooper.GetComponent<ParatrooperController>().moveDelay = moveDelay;

        int random = (int)Random.Range(1, 4);
        switch (random)
        {
            case 1:
                newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsA;
                break;
            case 2:
                newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsB;
                break;
            case 3:
                newTrooper.GetComponent<ParatrooperController>().trooperPositions = positionsC;
                break;
        }
    }

    public void TrooperLanded(GameObject currentTrooper) {
        if (TrooperSurvived(currentTrooper))
            IncreaseScore();
        else
            LoseLife();
        Destroy(currentTrooper);
    }

    bool TrooperSurvived(GameObject currentTrooper) {
        return boatCollider.IsTouching(currentTrooper.GetComponent<Collider2D>());
    }

    void IncreaseScore() {
        score++;
        scoreLabel.text = "Score: " + score.ToString();
        if (score == nextLevel)
            LevelUp();
    }

    void LoseLife() {
        livesController.RemoveHeart();
        if (livesController.transform.childCount == 0)
            GameOver();
    }

    void GameOver() {
        Debug.Log("Game Over!");
    }

    void LevelUp() {
        nextLevel *= 2;
        if (moveDelay > reduceMoveDelay)
            moveDelay -= reduceMoveDelay;
        if (spawnDelay > 1)
            spawnDelay -= 1;
    }
}
