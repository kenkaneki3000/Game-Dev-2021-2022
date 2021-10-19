using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement
    public float moveSpeed;
    public float jumpForce;
    //camera
    public float lookSensitivity;   //mouse look sensitivity
    public float maxLookX; // lowest down position we can look at
    public float minLookX; //highest up we can look
    public float rotX; //Curent X rotation of the camera
    // GameObject and Components
    private Camera cam;
    private Rigidbody rb;
    private Weapons weapons;

    void Awake()
    {
        //Get the components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        weapon = Getcomponet<Weapons>();
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        //Jump when spacebar is pressed
        if(Input.GetButtonDown("Jump"))
        Jump();

        if(Input.GetButton("Fire"))
        {
            if(weapons.CanShoot())
            {
                weapons.Shoot();
            }
        }
    }
     void Move()
     {
         float x = Input.GetAxis("Horizontal") * moveSpeed;
         float z = Input.GetAxis("Vertical") * moveSpeed;

         // GFace the direction of camera
         Vector3 dir = transform.right * x + transform.forward * z;
         //jump derection
         dir.y = rb.velocity.y;
         //move in the derection of the camera
         rb.velocity = dir;
     }

     void Jump()
     {
         Ray ray = new Ray(transform.position, Vector3.down);
         if(Physics.Raycast(ray, 1.1f))
         {
             rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         }
     }

     void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
        //Clamps the camera up and down rotation
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        // Apply Rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }


}
