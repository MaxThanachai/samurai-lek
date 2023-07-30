using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int height = 20;
    public int width = 20;
    public GameObject theEnemy;
    private Vector3 playerPosition;
    private int enemyCount = 0;
    public int enemyLimit = 10;  
    public int enemyDistance = 7;

    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(enemyDrop());
    }

    private IEnumerator enemyDrop()
    {
        while (enemyCount < enemyLimit)
        {
            if (!player)
            {
                break;
            }
            playerPosition = player.transform.position;
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
