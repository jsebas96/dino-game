using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    void Update()
    {

    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            float minTime = 1.2f;
            float maxTime = 1.8f;
            float randomTime = Random.Range(minTime, maxTime);
            float terodactylHeight = Random.Range(0F, 0.4F);

            if (obstacles[randomIndex].layer == 6)
            {
                Instantiate(obstacles[randomIndex], new Vector3(transform.position.x, transform.position.y + terodactylHeight, transform.position.z), Quaternion.identity);

            }
            else
            {
                Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(randomTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
