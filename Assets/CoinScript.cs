using UnityEngine;

public class CoinScript : MonoBehaviour
{
public GameObject coinPrefab;
    public int numberOfCoins = 20;
    public Terrain terrain;
    public Transform player;
    public float spawnRadius = 20f;

    void Start()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        Vector3 terrainPos = terrain.transform.position;
        Vector3 terrainSize = terrain.terrainData.size;

        int coinsSpawned = 0;
        int attempts = 0;
        int maxAttempts = numberOfCoins * 10;

        while (coinsSpawned < numberOfCoins && attempts < maxAttempts)
        {
            attempts++;

            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
            float x = player.position.x + randomCircle.x;
            float z = player.position.z + randomCircle.y;

            if (x < terrainPos.x || x > terrainPos.x + terrainSize.x ||
                z < terrainPos.z || z > terrainPos.z + terrainSize.z)
                continue; // skip if outside terrain bounds

            float y = terrain.SampleHeight(new Vector3(x, 0, z)) + terrainPos.y;
            Vector3 spawnPos = new Vector3(x, y + 1, z);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            coinsSpawned++;
        }
    }
}
