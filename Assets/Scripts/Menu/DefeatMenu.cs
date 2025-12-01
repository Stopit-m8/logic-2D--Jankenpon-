using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public void ReloadGame()
    {
        Time.timeScale = 1f;
        SceneTransition.Instance.TransitionReload();
    }
    public void BackToMainMenu()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex - 1);
        SceneTransition.Instance.TransitionLeave();
    }
}
