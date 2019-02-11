using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    private NetworkStartPosition[] spawnPoints;

    
    Rigidbody2D pad;
    SpriteRenderer sr;
    public Camera camera;

    public float speed = 10f;


    private float minX;
     private float maxX;
     private float minY;
     private float maxY;

	// Use this for initialization
	void Start ()
    {
        pad = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if(isLocalPlayer)
        {
            if (transform.position.y > 0)
            {
                Instantiate(camera, new Vector3(0, 0, -10f), new Quaternion(0, 0, 180f, 0));
            }
            else
            {
                Instantiate(camera, new Vector3(0, 0, -10f), new Quaternion(0, 0, 0, 0));
            }

            findSizes();
        }

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        padMovement();
	}

    void padMovement()
    {
        if(isLocalPlayer)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 pos = new Vector3(Mathf.Clamp(mousePosition.x, minX, maxX), transform.position.y, transform.position.z);
            transform.position = Vector2.Lerp(transform.position, pos, speed);
        }
        
    }

    void findSizes()
    {
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

       
        // Calculations assume map is position at the origin
        minX = -(worldWidth / 2f);
        maxX = Mathf.Abs(minX);
        Debug.Log(worldHeight + " | " + worldWidth);
        
    }
}
