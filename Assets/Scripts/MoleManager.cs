
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoleManager : MonoBehaviour {

    public List<GameObject> moleList = new List<GameObject>(); 

	// Use this for initialization
	void Start ()
	{

	    InvokeRepeating("UpMoleRandomly", 1f, 3f);

	}
	
	// Update is called once per frame
	void Update () {
        
	
	}

    void UpMoleRandomly()
    {
        moleList[Random.Range(0,9)].GetComponentInChildren<Mole>().Up();
    }
}
