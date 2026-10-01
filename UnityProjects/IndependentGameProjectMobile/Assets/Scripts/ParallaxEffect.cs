// Parallax background code from Bluefever Software: https://youtu.be/W9aVuOsc_k0
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    float singleTextureWidth;
    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void CheckReset()
    {
        if( (Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupTexture();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        CheckReset();
    }
}
