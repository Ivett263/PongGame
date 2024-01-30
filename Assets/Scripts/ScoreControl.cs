using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreControl : MonoBehaviour
{

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public GameObject textScore1;
    public GameObject textScore2;


    public int goalToWin;

    // Update is called once per frame
    void Update()
    {
        if(this.scorePlayer1 >= this.goalToWin || this.scorePlayer2 >= this.goalToWin)
        {
            SceneManager.LoadScene("GameEnded");
        }
    }

    private void FixedUpdate()
    {
        Text tagScore1 = this.textScore1.GetComponent<Text>();
        tagScore1.text = this.scorePlayer1.ToString();
        Text tagScore2 = this.textScore2.GetComponent<Text>();
        tagScore2.text = this.scorePlayer2.ToString();
    }

    public void PointPlayer1 ()
    {
        this.scorePlayer1++;
    }

    public void PointPlayer2()
    {
        this.scorePlayer2++;
    }
}
