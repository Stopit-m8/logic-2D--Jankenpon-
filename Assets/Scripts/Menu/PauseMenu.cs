using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject optionPanel;
    public CanvasGroup cardSlotsGroup;
    public Player player;
    private void Awake()
    {
        isOpen = false;
    }

    public void BackToPrevScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        SceneTransition.Instance.TransitionLeave();
    }

    public void OpenPauseMenu(CallbackContext context)
    {
        if (context.performed)
        {
            if (!isOpen && player.isDead == false)
            {
                Time.timeScale = 0f;
                if (cardSlotsGroup != null)
                {
                    cardSlotsGroup.interactable = false;
                    cardSlotsGroup.blocksRaycasts = false;
                }
                
                gameObject.SetActive(true);
                isOpen = true;
            }
            else if(player.isDead == false)
            {
                Time.timeScale = 1f;
                if (cardSlotsGroup != null)
                {
                    cardSlotsGroup.interactable = true;
                    cardSlotsGroup.blocksRaycasts = true;
                }
                gameObject.SetActive(false);
                if(optionPanel != null)
                {
                    optionPanel.SetActive(false);
                }
                isOpen = false;
            }
        }
    }
}
