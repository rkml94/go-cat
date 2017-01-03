using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static Score Instance;

    private float score = 0f;
    private Text scoreText;

	// Use this for initialization
	void Start ()
	{
	    Instance = this;
	    scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
	{

	    scoreText.text = "Score: " + score.ToString();

	}

    public void IncrementScore()
    {
        score++;
    }

    public float GetScore()
    {
        return score;
    }

    void OnDisable()
    {
        Instance = null;
    }
}
