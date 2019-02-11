using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallSpawnerControl : NetworkBehaviour
{
    
    public GameObject prefab;

        // Use this for initialization
    void Start ()
    {
        CmdCreateBall();
    }

    [Command]
	public void CmdCreateBall()
    {
        NetworkServer.Spawn(Instantiate(prefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)));
    }

	// Update is called once per frame
	void Update () {
		
	}
}
