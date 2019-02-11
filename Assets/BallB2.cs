using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallB2 : MonoBehaviour
{
    

    public float speed = 5f;
    public int hitLimit = 0;

    Vector3 direction;

    Rigidbody2D ball;
    float dirY;

    float minX;
    float maxX;

    float rotAngle;
    int padHit;
    
    // Use this for initialization
    void Start ()
    {
        ball = GetComponent<Rigidbody2D>();
        ball.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rotAngle = 10f;
        padHit = 0;
        

        direction = new Vector3(0,1,0);
        findSizes();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position += direction * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Collector")
        {
            Destroy(gameObject);
        }

        float dirX = randomDirection() * Random.Range(-0.7f, 0.7f);

        if(collision.gameObject.tag == "Pad")
        {
            // Speed Up ball movement
            // after @hitLimit hits
            padHit++;
            if(padHit > hitLimit)
            {
                padHit = 0;
                speed += 0.5f;
            }
            if (transform.position.y > 0)
            {
                dirY = -1;
                rotAngle *= -1f;
            }
            else dirY = 1;
        }
        if(collision.gameObject.tag == "LeftBound")
        {
            if (dirX < 0)
            {
                dirX *= -1;
                rotAngle *= -1f;
            }
        }
        if (collision.gameObject.tag == "RightBound")
        {
            if (dirX > 0)
            {
                dirX *= -1;
                rotAngle *= -1f;
            }
        }

        direction = new Vector3(dirX, dirY, 0);
    }

    private float randomDirection()
    {
        float dirX = Random.Range(0, 2);
        if (dirX == 0) return dirX = -1;
        else return dirX;
    }

    void findSizes()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        // Calculations assume map is position at the origin
        minX = -(worldWidth / 2f);
        maxX = Mathf.Abs(minX);
        Debug.Log(minX + " | " + maxX);

    }
}
