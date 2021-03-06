using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHP;
    public int maxHP;
    public int scoreToGive;
    
    [Header("Movment")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;
    private List<Vector3> path;
    private Weapons weapons;
    private GameObject target;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponent<Weapons>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    
    }
    void UpdatePath()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
        return;
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);
        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
        path.RemoveAt(0);
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0)
        Die();
    }
     void Die()
     {
         rb.constraints = RigidbodyConstraints.None;
         Destroy(gameObject,1);
         GameManager.instance.AddScore(scoreToGive);
     }

    // Update is called once per frame
    void Update()
    {
        
    }
}
