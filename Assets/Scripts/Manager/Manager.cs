using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Image enemyChoice;
    public Player player;
    public Enemy enemy;

    public string[] choices;
    public Sprite rock, paper, scissors;

    public GameObject defeatPanel;
    public CanvasGroup cardSlotsGroup;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public void PlayerWin()
    {
        Debug.Log("Win");
        StartCoroutine(AttackCooldownPlayer());
    }
    public void EnemyWin()
    {
        Debug.Log("Lose");
        StartCoroutine(AttackCooldownEnemy());
    }
    public void PlayGame(string myChoice)
    {
        StatManager.instance.actionUsed++;
        string randomChoice = choices[Random.Range(0, choices.Length)];

        if(randomChoice == "Rock")
        {
            enemyChoice.sprite = rock;
            if(myChoice == "Rock")
            {
                Debug.Log("Tie");
            }
            else if (myChoice == "Paper")
            {
                PlayerWin();
            }
            else if (myChoice == "Scissors")
            {
                EnemyWin();
            }
        }
        else if(randomChoice == "Paper"){
            enemyChoice.sprite = paper;
            if (myChoice == "Rock")
            {
                EnemyWin();
            }
            else if (myChoice == "Paper")
            {
                Debug.Log("Tie");
            }
            else if (myChoice == "Scissors")
            {
                PlayerWin();
            }
        }
        else if(randomChoice == "Scissors"){
            enemyChoice.sprite = scissors;
            if (myChoice == "Rock")
            {
                PlayerWin();
            }
            else if (myChoice == "Paper")
            {
                EnemyWin();
            }
            else if (myChoice == "Scissors")
            {
                Debug.Log("Tie");
            }
        }
    }

    public void Defeat()
    {
        Time.timeScale = 0f;

        cardSlotsGroup.interactable = false;
        cardSlotsGroup.blocksRaycasts = false;

        // Show defeat screen
        defeatPanel.SetActive(true);
    }

    private IEnumerator AttackCooldownPlayer()
    {
        cardSlotsGroup.interactable = false;
        cardSlotsGroup.blocksRaycasts = false;
        player.Attack();
        enemy.TakeDamage(player.Damage);
        yield return new WaitForSeconds(1f);
        cardSlotsGroup.interactable = true;
        cardSlotsGroup.blocksRaycasts = true;
    }

    private IEnumerator AttackCooldownEnemy()
    {
        cardSlotsGroup.interactable = false;
        cardSlotsGroup.blocksRaycasts = false;
        enemy.Attack();
        player.TakeDamage(enemy.Damage);
        yield return new WaitForSeconds(1f);
        cardSlotsGroup.interactable = true;
        cardSlotsGroup.blocksRaycasts = true;
    }

}
