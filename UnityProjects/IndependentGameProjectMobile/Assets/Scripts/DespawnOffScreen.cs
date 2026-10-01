using UnityEngine;

public class LoseIfOffScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 blockPos = Camera.main.WorldToScreenPoint(transform.position); //tracks the position of items relative to if they are on screen or not
        if (blockPos.y < 0) //if the items fall below the bottom of the screen: then destroy object
        {
            Destroy(gameObject);
        }

    }
}