using UnityEngine;

public class CitizenSpawner : MonoBehaviour
{
    public GameObject citizenPrefab;
    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnCitizen", 0f, spawnInterval);
    }

    void SpawnCitizen()
    {
        Instantiate(citizenPrefab, transform.position, Quaternion.identity);
    }
}