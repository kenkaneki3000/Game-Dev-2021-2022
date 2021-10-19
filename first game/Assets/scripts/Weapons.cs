using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate; 
    private float lastShootTime;
    private bool isPlayer;
    void Awake()
    {
        //are we attached to the player
        if(getComponet<PlayerController>())
        {
            isPlayer = true;
        }
    }
    public bool Canshoot()
    {
        if(Time.time - lastShootTime >= true)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
               return false;
        }
    }
    public void Shoot()
    {
        LastShootTime = Time.time;
        curAmmo--;

        GameObject bullet = Instatiante(bulletPrefab, muzzle.position, muzzle.rotation);

        //set velocity
        bullet.getComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
