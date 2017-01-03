using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var mousePos = Input.mousePosition;
	    var adjustedPos = Camera.main.ScreenToWorldPoint(mousePos);
	    adjustedPos.z = 0;
        transform.position = adjustedPos;
	
	}
}
