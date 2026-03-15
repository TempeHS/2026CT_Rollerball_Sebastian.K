using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public Transform player;
    public GameObject Enemy;
    
    private int count;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Instantiate(Enemy, 0, 0, 5, Quaternion.identity);
    }

  
    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Enemy"))
        {
            navMeshAgent.SetDestination(player.position);
        }

       // if(gameObject.CompareTag("Enemy 2"))
       // {
       //    if(count > 3)
       //     {
       //       navMeshAgent.SetDestination(player.position);  
       //     } 
       // }
//
       //  if(gameObject.CompareTag("Enemy 3"))
       // {
       //   if(count > 5)
       //     {
       //        navMeshAgent.SetDestination(player.position); 
       //     }  
       // }
    }

public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
        }
    }
}

