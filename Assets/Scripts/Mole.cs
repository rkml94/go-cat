using UnityEngine;
using System.Collections;

public class Mole : MonoBehaviour
{

    private Animator animator;

    private bool up = false;

	// Use this for initialization
	void Start ()
	{

	    animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

	    if (up)
	    {
	        StartCoroutine(GoDownAfterSeconds(3f));
	    }
	
	}

    public void Up()
    {
        if (up) return;
        animator.Play("up");
        up = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag =="Hammer")
        {
            animator.Play("hit");
            up = false;
            Score.Instance.IncrementScore();
        }
    }

    IEnumerator GoDownAfterSeconds(float time)
    {
        up = false;
        yield return new WaitForSeconds(time);
        animator.Play("hit");
    }
}
