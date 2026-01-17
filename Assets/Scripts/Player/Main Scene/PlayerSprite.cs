using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    [SerializeField] private PlayerMovement PlayerMovement;
    private bool isFacingRight = true;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (isFacingRight && PlayerMovement.dir.x < 0f)
        {
            FlipSprite();
            isFacingRight = false;
        }

        else if (!isFacingRight && PlayerMovement.dir.x > 0f)
        {
            FlipSprite();
            isFacingRight = true;
        }
    }

    public void FlipSprite()
    {
        spriteRenderer.flipX = isFacingRight;
    }
}
