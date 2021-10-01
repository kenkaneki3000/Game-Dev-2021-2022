using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject tank; 
    private Vector3 offset = new Vector3(0,58,-80);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Set the cameras position to the players(tank) position
        transform.position = tank.transform.position + offset;
    }
}
