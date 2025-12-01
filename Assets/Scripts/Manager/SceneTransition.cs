using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    [SerializeField] private Animator TransitionAnimator;
    [SerializeField] private CanvasGroup canvasGroup;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public void TransitionEnter()
    {
        StartCoroutine(TransitionLevelEnter());
    }

    public void TransitionLeave()
    {
        StartCoroutine(TransitionLevelLeave());
    }

    public void TransitionReload()
    {
        StartCoroutine(TransitionLevelRestart());
    }

    IEnumerator TransitionLevelEnter()
    {
        TransitionAnimator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        TransitionAnimator.SetTrigger("Start");
    }

    IEnumerator TransitionLevelLeave()
    {
        TransitionAnimator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        TransitionAnimator.SetTrigger("Start");
    }

    IEnumerator TransitionLevelRestart()
    {
        TransitionAnimator.SetTrigger("End");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        TransitionAnimator.SetTrigger("Start");
    }
}
