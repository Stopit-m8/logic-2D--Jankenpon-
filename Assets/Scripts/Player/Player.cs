using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{
    public PlayerScriptableObject playerData;
    private SpriteRenderer spriteRenderer;
    public ScoreManager scoreManager;
    public Manager manager;

    public bool isDead = false;
    public int Health { get; private set; }
    public int Damage { get; private set; }
    public Sprite Sprite { get; private set; }
    public Animator Animator { get; private set; }

    public TMP_Text maxHealthText;
    public TMP_Text currentHealthText;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Health = playerData.maxHealth;
        Damage = playerData.damage;
        Sprite = playerData.playerSprite;
        spriteRenderer.sprite = Sprite;
        Animator.runtimeAnimatorController = playerData.animatorController;
        maxHealthText.text = Health.ToString();
        currentHealthText.text = Health.ToString();
    }
    public void TakeDamage(int amount)
    {
        Health = Mathf.Max(0, Health - amount);
        currentHealthText.text = Health.ToString();
    }
    public void Attack()
    {
        Animator.SetTrigger("Attack");
        AudioManager.instance.PlaySFX(AudioManager.instance.attackSfx);
    }
    private void Update()
    {
        if (!isDead && Health <= 0)
        {
            isDead = true;
            Animator.SetBool("isDead", true);
            AudioManager.instance.PlaySFX(AudioManager.instance.DeathSfx);

            StartCoroutine(ShowDefeatScreen());

            scoreManager.SetBestScore();
        }
    }

    IEnumerator ShowDefeatScreen()
    {
        yield return new WaitForSecondsRealtime(1f);
        manager.Defeat();
    }
}
