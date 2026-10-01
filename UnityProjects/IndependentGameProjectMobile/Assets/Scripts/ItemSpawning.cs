using UnityEngine;
using System.Collections;

public class ItemSpawning : MonoBehaviour
{
    public GameObject Money;
    public GameObject Bomb;

    public float minForce = 0.0f;
    public float maxForce = 2.0f;

    public float initialSpawnInterval = 2.0f; 
    public float minSpawnInterval = 0.2f;
    public float spawnRate = 0.95f;   

    private float currentSpawnInterval;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(currentSpawnInterval);

            currentSpawnInterval *= spawnRate; //multiplies the spawn interval by the 0.95f spawn rate to grdually lessen the time between spawn intervals
            if (currentSpawnInterval < minSpawnInterval) //makes sure the minimum Spawn interval is not surpassed
                currentSpawnInterval = minSpawnInterval;
        }
    }

    void Spawn()
    {
        GameObject SpawnedItem = (Random.value < 0.2f) ? Bomb : Money;
        GameObject Item = Instantiate(SpawnedItem, transform.position, Quaternion.identity);
        Rigidbody2D rb = Item.GetComponent<Rigidbody2D>(); //refer to the rigidbody2d of the item being spawned as rb
        float xForce = Random.Range(minForce, maxForce); //generate a random value for the items to travel along the x axis (in general)
        Vector2 Launch = new Vector2(xForce, 8.0f);
        rb.AddForce(Launch, ForceMode2D.Impulse);
    }
}
