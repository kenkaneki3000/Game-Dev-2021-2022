using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    void onEnable()
    {
        shootTime = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OntriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(damage);
        }            

        else
        {
             if(other.CompareTag("Enemy"))
             {
                 other.GetComponent<Enemy>().TakeDamage(damage);
                 gameObject.SetActive(false);
                 GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
                 Destroy(obj, 0.5f);
             }                
        }           

        //Disable bullet
        gameObject.SetActive(false);
        GameObject obj = intstantiate(bitParticle, transform,position);
        Destroy(obj, 0.5f);

    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifeTime)
         gameObject.SetActive(false);
    }
}
