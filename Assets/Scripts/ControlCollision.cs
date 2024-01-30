using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCollision : MonoBehaviour
{
    public MoveBall moveBall;
    public ScoreControl scoreControl;

    void reboundWithRacket(Collision2D c) //c is the element where it will collide
    {
        Vector3 positionBall = this.transform.position;
        Vector3 positionRacket = c.gameObject.transform.position;
        float heightRacket = c.collider.bounds.size.y;

        float x;
        if(c.gameObject.name == "Player1")
        {
            x = 1;
        } else
        {
            x = -1;
        }

        float y = (positionBall.y - positionRacket.y) / heightRacket;

        this.moveBall.IncreaseHitCounter();
        this.moveBall.MoveBallAfterStrike(new Vector2(x, y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            this.reboundWithRacket(collision);
        }
        else if (collision.gameObject.name == "LeftWall") {
            this.scoreControl.PointPlayer2();
            StartCoroutine(this.moveBall.StartBall(true));
        }
        else if (collision.gameObject.name == "RightWall")
        {
            this.scoreControl.PointPlayer1();
            StartCoroutine(this.moveBall.StartBall(false));
        }
    }
}
