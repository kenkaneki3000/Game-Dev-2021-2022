using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
 {
    Health,
    Ammo
 }
 
 public class PickUp : MonoBehaviour
{
    public PickupType type;
    public int value;
    [header ("bobber anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    public bool bobbingUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("Player"))
        {
        PlayerController player = other.GetComponent<PlayerController>();
        switch(type)
        {
            case PickupType.Health;
            player.GiveHealth(value);
            break;

            case PickupType.Ammo;
            player.GiveAmmo(value)
        }
        
    }
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
       Vector3 offset = bobb
    }
}
