using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{

    public float speedMouvement;
    public float speedExtraByStrike;
    public float speedExtraMax;

    int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    public IEnumerator StartBall(bool startPlayer1 = true)
    {
        this.PositioningBall(startPlayer1);

        this.hitCounter = 0;

        yield return new WaitForSeconds(2);

        if (startPlayer1)
        {
            this.MoveBallAfterStrike(new Vector2(-1, 0));
        } else
        {
            this.MoveBallAfterStrike(new Vector2(1, 0));
        }
    }

    void PositioningBall(bool startPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (startPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-100, 0, 0);
        } else
        {
            this.gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }

    public void MoveBallAfterStrike(Vector2 dir)
    {
        dir = dir.normalized;

        float velocity = this.speedMouvement + this.hitCounter * this.speedExtraByStrike;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = dir * velocity;
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.speedExtraByStrike <= this.speedExtraMax)
        {
            this.hitCounter++;
        }
    }

}
