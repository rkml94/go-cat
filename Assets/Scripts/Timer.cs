using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{

    private Text timerText;

    private float startTime = 30f;

	// Use this for initialization
	void Start ()
	{

	    timerText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update ()
	{

	    //startTime -= Time.deltaTime;

	    startTime = 30f - Time.time;

        if (startTime < 0)
        {
            GameOver();
        }

	    timerText.text = startTime.ToString();

	}

    void GameOver()
    {
        Debug.Log("game over");

        if (Score.Instance.GetScore() > 5)
            Win();
        else
            Lose();
        
    }

    void Win()
    {
        Application.LoadLevel("win");
    }

    void Lose()
    {
        Application.LoadLevel("lose");
        
    }
}
