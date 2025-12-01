using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public string enemyName;

    public Sprite enemySprite;
    public RuntimeAnimatorController animatorController;

    public int maxHealth;
    public int damage;
}
