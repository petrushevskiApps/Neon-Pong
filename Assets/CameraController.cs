using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CameraController : NetworkBehaviour
{
    Camera camera;

	
    public void cameraRotate()
    {
        camera = GetComponent<Camera>();
        camera.transform.rotation = new Quaternion(0, 0, 180f, 0);
    }
}
