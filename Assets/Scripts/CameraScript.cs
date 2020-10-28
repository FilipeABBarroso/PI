using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector2 posOffset;

    public float leftLimit;
    public float rigthLimit;
    public float topLimit;
    public float botLimit;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Camera start position
        Vector3 startPos = transform.position;
        
        //Player start position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        transform.position = new Vector3
            (
                Mathf.Clamp(transform.position.x, leftLimit, rigthLimit),
                Mathf.Clamp(transform.position.y, botLimit, topLimit),
                transform.position.z
            );
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rigthLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rigthLimit, topLimit), new Vector2(rigthLimit, botLimit));
        Gizmos.DrawLine(new Vector2(rigthLimit, botLimit), new Vector2(leftLimit, botLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, botLimit), new Vector2(leftLimit, topLimit));
    }

}
