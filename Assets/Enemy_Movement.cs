using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{

    public Transform player;
    
    public int count;
    private NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

  
    // Update is called once per frame
    void Update()
    {
        if(gameObject.CompareTag("Enemy"))
        {
            navMeshAgent.SetDestination(player.position);
        }

        if(gameObject.CompareTag("Enemy 2"))
        {
           if(count > 3)
            {
              navMeshAgent.SetDestination(player.position);  
            } 
        }

         if(count > 5 ++ gameObject.CompareTag("Enemy 3"))
        {
            navMeshAgent.SetDestination(player.position);
        }
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

