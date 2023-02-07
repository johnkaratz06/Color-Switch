using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, ball.position.y, transform.position.z);
    }
}
