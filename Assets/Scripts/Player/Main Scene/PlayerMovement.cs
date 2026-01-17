using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public Vector2 dir;
    public bool isRunning;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Movement(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        if (ctx.performed && dir.x > 0f || dir.x < 0f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.normalized.x * speed, rb.linearVelocityY);
    }
}
