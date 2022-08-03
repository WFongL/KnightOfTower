using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSkeletController : MonoBehaviour
{
    [SerializeField] private GameObject[] _skeletPrefabes;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 1, 3);
    }

    private void SpawnRandomEnemy()
    {
        int randomPosX = Random.Range(-2, 3);
        Vector3 spawnPos = new Vector3(randomPosX, 0.5f, 30);
        //int randomEnemy = Random.Range(0, _enemyPrefabes.Length);
        GameObject skelet = Instantiate(_skeletPrefabes[0], spawnPos, Quaternion.identity, transform);
        skelet.transform.Rotate(0, 180, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<KnightController>())
        {
            Destroy(other.gameObject);
        }
    }
}
