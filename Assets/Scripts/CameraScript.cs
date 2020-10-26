using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject cam;

    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float botLimit;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(cam.transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(cam.transform.position.y, botLimit, topLimit),
            transform.position.z
            );
    }
}
