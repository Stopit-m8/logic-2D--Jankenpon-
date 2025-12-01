using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IEntity
{
    public EnemyScriptableObject[] enemyData;
    private SpriteRenderer spriteRenderer;

    public int Health { get; private set; }
    public int Damage { get; private set; }
    public Sprite Sprite { get; private set; }
    public Animator Animator { get; private set; }

    private int randomNumber;
    private bool isDying;
    public TMP_Text maxHealthText;
    public TMP_Text currentHealthText;


    private void Awake()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        LoadRandomEnemy();
    }
    private void Update()
    {
        currentHealthText.text = Health.ToString();

        if (Health <= 0 && !isDying)
        {
            StartCoroutine(DeathAnimation());
        }
    }
    public void TakeDamage(int amount)
    {
        Health = Mathf.Max(0, Health - amount);
    }

    private void LoadRandomEnemy()
    {
        randomNumber = Random.Range(0, enemyData.Length);
        Health = enemyData[randomNumber].maxHealth;
        Damage = enemyData[randomNumber].damage;
        Sprite = enemyData[randomNumber].enemySprite;
        Animator.runtimeAnimatorController = enemyData[randomNumber].animatorController;
        spriteRenderer.sprite = Sprite;
        maxHealthText.text = Health.ToString();
    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
    }

    IEnumerator DeathAnimation()
    {
        if (isDying) yield break;   // prevents multiple triggers
        isDying = true;

        Animator.SetBool("isDead", true);

        // wait for death animation
        yield return new WaitForSecondsRealtime(1f);

        // reset animation
        Animator.SetBool("isDead", false);
        Animator.Rebind(); // resets Animator to default state
        Animator.Update(0f);

        // give points
        ScoreManager.Instance.score += 2000;
        StatManager.instance.enemyDefeated++;

        // load the next enemy
        LoadRandomEnemy();

        isDying = false;
    }
}
