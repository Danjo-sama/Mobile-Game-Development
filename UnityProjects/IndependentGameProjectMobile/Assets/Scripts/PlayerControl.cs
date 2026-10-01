using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontalInput;
    public float moveForce = 0.03f;
    public bool onGround;
    public float speed = 5.0f;
    
    public Animator animator;

    public AudioSource audioSource;
    public AudioClip moneySound;
    public AudioClip explosionSound;

    // Checking if the player is on the ground surface so that the correct collision is in place to keep the player from falling through the ground
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.collider.CompareTag("Surface"))
        {
            onGround = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 )
        {
            GetComponent<Rigidbody2D>().AddForceX(moveForce, ForceMode2D.Impulse); // Using an AddForce system to make the player slide on the road to give an effect of acceleration on a road
        }

        if (horizontalInput < 0)
        {
            GetComponent<Rigidbody2D>().AddForceX(-moveForce, ForceMode2D.Impulse);
        }

        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("IsOpen", true); //send signal to set the player sprite to the open bag while Fire1 is held
        }
        else
        {
            animator.SetBool("IsOpen", false); //send signal to set the player sprite to the closed bag when Fire1 is not held
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetButton("Fire1") && collision.gameObject.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(moneySound);
            GameManager.instance.AddScore(100); //call the instance of GameManager script to add 100 to the score
        }

        if (Input.GetButton("Fire1") && collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(explosionSound);
            GameManager.instance.GameOver(); //call the instance of GameManager to call a Game Over Screen
        }
    }


}
