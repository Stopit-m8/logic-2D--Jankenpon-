using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class PauseMenuMain : MonoBehaviour
{
    [SerializeField] private bool isOpen;
    [SerializeField] private GameObject optionPanel;
    private void Awake()
    {
        isOpen = false;
    }

    public void BackToPrevScene()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        SceneTransition.Instance.TransitionLeave();
    }

    public void OpenPauseMenuMain(CallbackContext context)
    {
        if (context.performed)
        {
            if (!isOpen)
            {
                Time.timeScale = 0f;
                gameObject.SetActive(true);
                if (optionPanel != null)
                {
                    optionPanel.SetActive(false);
                }
                isOpen = true;
                
            }
            else
            {
                Time.timeScale = 1f;
                gameObject.SetActive(false);
                if (optionPanel != null)
                {
                    optionPanel.SetActive(false);
                }
                isOpen = false;
            }
        }
    }
}
