using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour
{

    private Animator animator;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetMouseButtonDown(0))
	    {
	        animator.Play("smash");
	    }
	    if (Input.GetMouseButtonUp(0))
	    {
	        animator.Play("Hammer Up");
	    }

	}
}
