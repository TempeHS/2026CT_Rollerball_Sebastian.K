using UnityEngine;

public class spawning : MonoBehaviour


{
    [SerializeField]
    private float spawntime = 10f;
    [SerializeField]
    private GameObject enemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (spawntime != 0)
        {
            spawntime--;
        }

        if (spawntime == 0)
        {
            spawntime = 10;

        }

        StartCoroutine(spawnEnemy(spawntime, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSecond(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(0, 0.5, 0, Quaternion.identity));
        StartCoroutine(spawnEnemy(interval, enemy)); 
    }
}
