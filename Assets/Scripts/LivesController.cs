using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 2; i++) {
            AddHeart();
        }
    }
	
    public void AddHeart() {
        GameObject newHeart = Instantiate(transform.GetChild(transform.childCount - 1).gameObject);
        newHeart.transform.SetParent(transform);
        Vector3 pos = newHeart.transform.position;
        pos.x += 1;
        newHeart.transform.position = pos;
    }

    public void RemoveHeart() {
        if (transform.childCount != 0)
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
    }
}
