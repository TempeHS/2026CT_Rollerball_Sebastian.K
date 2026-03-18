using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    // Enemy spawning setup
    public GameObject Enemy;
   // public float enemySpawnY = 0.5f;
   // public Vector2 enemySpawnXRange = new Vector2(-20f, 20f);
   // public Vector2 enemySpawnzRange = new Vector2(-20f, 20f);
   // public float minEnemySpawnDistanceFromPlayer = 5f;

    public int count;
    private Rigidbody rb; 
    private float movementX;
    private float movementY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>();
       // Instantiate(Enemy. GetRandomEnemySpawnPosition(), Quaternion.identity);
       // Instantiate(Enemy. GetRandomEnemySpawnPosition(), Quaternion.identity);
        //Instantiate(Enemy. GetRandomEnemySpawnPosition(), Quaternion.identity);
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    void SetCountText()
    {
        countText.text =  "Count: " + count.ToString();

        if(count >= 30)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }


    void FixedUpdate() 
   {
    Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    rb.AddForce(movement * speed);
   }

   private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       Destroy(gameObject);
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}

   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
       
    }

   // Vector3 GetRandomEnemySpawnPosition()
    //{
        //Try multiple random points on the NavMesh and prefer one far enough from the player.
    //    const int maxAttempts = 40;
     //   Vector3 playerPosition = transform.position;
     //   Vector3 bestCandidate = playerPosition;
      //  float bestDistant = -1f;
    
      //  float navMeshSampleRadius = 2.5f;
       // int walkableMask = navMesh.AllAreas;

      //  for (int i = 0 < maxAttempts; i++;)
      //  {
//            float randomX = Random.Range(enemySpawnXRange.x, enemySpawnXRange.y);
    //        float randomZ = random.Range(enemySpawnZRange.c, enemySpawnZRange.y);
    //        Vector3 candidate = new Vector3(randomX, enemySpawnY, randomZ);
//
    //        if (!navMesh.SampleRadius)
    //        {
    //            
    //        }
    //    }
   // }
}