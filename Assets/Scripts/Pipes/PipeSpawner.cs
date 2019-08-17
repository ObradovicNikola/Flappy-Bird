using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;

    private float minY = 1.2f, maxY = 4.5f;
    private float tmpY, startX = 1f, startZ = -31;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewObstacle());
    }

    IEnumerator SpawnNewObstacle()
    {
        //yield return new WaitForSeconds(Random.Range(2.1f, 4.5f));
        yield return new WaitForSeconds(Random.Range(1.1f, 1.4f));
        tmpY = Random.Range(minY, maxY);
        Vector3 tmp = new Vector3(startX, tmpY, startZ);
        Instantiate(obstacle, tmp, transform.rotation);


        StartCoroutine(SpawnNewObstacle());
    }
}
