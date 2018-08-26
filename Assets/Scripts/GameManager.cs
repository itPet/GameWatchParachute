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
    public TextMesh levelLabel;
    public LivesController livesController;
    [Range(0.1f, 1)]
    public float moveDelay;
    [Range(0.1f, 0.3f)]
    public float reduceMoveDelay;
    [Range(1, 7)]
    public int spawnDelay;
    [Range(1, 10)]
    public int nextLevel;
    GameObject newTrooper;
    int score = 0;
    int level = 1;

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
        if (moveDelay > reduceMoveDelay || spawnDelay > 1) {
            level++;
            levelLabel.text = "Level: " + level;
            nextLevel *= 2;
        }

        if (moveDelay > reduceMoveDelay)
            moveDelay -= reduceMoveDelay;
        if (spawnDelay > 1)
            spawnDelay -= 1;
    }
}
