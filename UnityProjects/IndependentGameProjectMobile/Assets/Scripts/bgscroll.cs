using UnityEngine;

public class bgscroll : MonoBehaviour
{
    public float speed;
    public Renderer rend;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(Time.time * -speed, 0); //move the texture on the renderer along with each moment of time the game is active
    }
}
