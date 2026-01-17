using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Debug.Log(playerMovement.isRunning);
        if (playerMovement.isRunning)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
