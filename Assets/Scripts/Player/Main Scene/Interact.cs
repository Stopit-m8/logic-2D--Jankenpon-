using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    private bool canInteract;

    public void InteractPress(InputAction.CallbackContext ctx)
    {
        if (ctx.started && canInteract)
        {
            Debug.Log("Interact");
            SceneTransition.Instance.TransitionEnter();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gate"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}
