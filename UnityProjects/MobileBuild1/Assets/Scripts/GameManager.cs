using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public TMP_Text distanceText;
    public float distanceIncrease = 1f;
    public float speedIncrease = 1.5f;
    public float increaseInterval = 5f;

    private float distanceTravelled = 0f;
    private float timeSinceLastIncrease = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += distanceIncrease * Time.deltaTime;

        if (timeSinceLastIncrease >= increaseInterval)
        {
            distanceIncrease += speedIncrease;
            timeSinceLastIncrease = 0f;
        }

        distanceText.text = $"Distance: {Mathf.FloorToInt(distanceTravelled)}m";
    }
}
