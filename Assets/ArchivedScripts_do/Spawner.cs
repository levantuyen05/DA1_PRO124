using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;

    private void Start()
    {
    }

    public void spawnEnemy(GameObject boss)
    {
        Instantiate(boss, transform.position, Quaternion.identity);
    }
}