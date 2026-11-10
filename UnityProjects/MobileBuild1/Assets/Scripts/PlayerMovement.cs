using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 10f;
    

    public InputActionReference tapAction;

    private bool isAtTop = false;
    private bool onPlatform = false;

    private float topY;
    private float fixedX;

    private Rigidbody2D rb;
    private Camera cam;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Start()
    {
        fixedX = transform.position.x;

        float cameraDepth = transform.position.z
                          - cam.transform.position.z;

        topY = cam.ViewportToWorldPoint(
            new Vector3(0.5f, 0.5f, cameraDepth)
        ).y;
    }

    void OnEnable()
    {
        if (tapAction != null)
        {
            tapAction.action.performed += OnTap;
            tapAction.action.Enable();
        }
    }

    void OnDisable()
    {
        if (tapAction != null)
        {
            tapAction.action.performed -= OnTap;
            tapAction.action.Disable();
        }
    }

    void OnTap(InputAction.CallbackContext context)
    {
        if (onPlatform)
        {
            isAtTop = !isAtTop;

            onPlatform = false;
        }
        
    }

    void FixedUpdate()
    {
        if (onPlatform)
            return;

        float direction = isAtTop ? 1f : -1f;

        Vector2 movement = new Vector2(
            fixedX,
            rb.position.y + direction * moveSpeed * Time.fixedDeltaTime
        );

        rb.MovePosition(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            onPlatform = false;
        }
    }
}
    