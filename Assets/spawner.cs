using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour


{
    
    public float spawntime = 10f;
  
    public GameObject enemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(spawnEnemy(spawntime, enemyPrefab));
    }

    public IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(0f, 0.5f, 0f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy)); 
    }
}
