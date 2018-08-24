using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsController : MonoBehaviour {

    public bool isLeft;
    public delegate void PlayerClicked();
    public static event PlayerClicked ClickedLeft;
    public static event PlayerClicked ClickedRight;

    private void OnMouseDown()
    {
        if (isLeft)
            ClickedLeft();
        else
            ClickedRight();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
