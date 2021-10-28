using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Ling;
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
    private List<vector3> path;
    private Weapon weapon;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<weapon>();
        target = FindObjectOffset<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    
    }
    void UpdatePath()
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        navMesh.CalculatePath(transform.position, target.transform.position, navMesh.AllAreas, newMeshPath);

        path = navMeshPath.corners.ToList();
    }
    void ChaseTarget()
    {
        if(path.Count == 0)
        return;
        transform.position = Vector3.MoveTowards(tansform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * time.deltaTime);
        if(transform.postion == path[0] + new vector3(0, yPathOffset))
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
