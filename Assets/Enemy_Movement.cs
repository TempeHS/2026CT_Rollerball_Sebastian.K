using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy_Movement : MonoBehaviour
{

    public Transform player;
    private int count;
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

        if (Input.GetKeyDown(KeyCode.R))
             {
                 Resetbutton();
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

    public void Resetbutton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

