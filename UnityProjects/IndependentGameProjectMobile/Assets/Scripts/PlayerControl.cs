using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    InputAction moveAction;
    InputAction bagAction;

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

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        bagAction = InputSystem.actions.FindAction("OpenBag");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();
        if (move == Vector2.right)
        {
            GetComponent<Rigidbody2D>().AddForceX(moveForce, ForceMode2D.Impulse); // Using an AddForce system to make the player slide on the road to give an effect of acceleration on a road
        }

        if (move == Vector2.left)
        {
            GetComponent<Rigidbody2D>().AddForceX(-moveForce, ForceMode2D.Impulse);
        }

        if (bagAction.IsPressed())
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
        if (bagAction.IsPressed() && collision.gameObject.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(moneySound);
            GameManager.instance.AddScore(100); //call the instance of GameManager script to add 100 to the score
        }

        if (bagAction.IsPressed() && collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(explosionSound);
            GameManager.instance.GameOver(); //call the instance of GameManager to call a Game Over Screen
        }
    }


}
