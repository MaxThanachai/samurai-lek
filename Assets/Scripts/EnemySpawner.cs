using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    /* [SerializeField]
     private GameObject swarmerPrefab;

     [SerializeField]
     private float swarmerInterval = 3.5f;

     void Start()
     {
         StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
     }

     private IEnumerator spawnEnemy(float interval, GameObject enemy)
     {
         yield return new WaitForSeconds(interval);
         GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), Random.Range(-5f, 5), 0), Quaternion.identity);
         StartCoroutine(spawnEnemy(interval, newEnemy));
     }*/

    /*[SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private bool canSpawn = true;

    private void Start()
    {
        StartCorotine(Spawner());
    }

    private IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, enemyPrefab.Length);
            GameObject enemyToSpawn = enemyPrefab[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }*/
    public int height = 20;
    public int width = 20;
    public GameObject theEnemy;
    private Vector3 playerPosition;
    private int enemyCount = 0;
    public int enemyLimit = 10;  
    public int enemyDistance = 7;

    void Start()
    {

        StartCoroutine(enemyDrop());
    }

    private IEnumerator enemyDrop()
    {
        while (enemyCount < enemyLimit)
        {   
            playerPosition = GameObject.Find("Player").transform.position;
            float xSpawner = transform.position.x;
            float ySpawner = transform.position.y;
            float xPos = Random.Range(xSpawner-(width/2),xSpawner + (width/2));
            float yPos = Random.Range(ySpawner - (height/2), ySpawner + (height/2));
            if (Mathf.Abs(playerPosition.x - xPos) > enemyDistance || Mathf.Abs(playerPosition.y - yPos) > enemyDistance)
            {
                Instantiate(theEnemy, new Vector3(xPos, yPos, 0), Quaternion.identity);
                enemyCount += 1;
                yield return new WaitForSeconds(3.5f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Color color = Color.red;
        color.a = 0.15f;
        Gizmos.color = color;
        Gizmos.DrawCube(transform.position,new Vector3(width, height, 0));
    }
}
