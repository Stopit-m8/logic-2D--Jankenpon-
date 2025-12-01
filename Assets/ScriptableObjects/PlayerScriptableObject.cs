using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public Sprite playerSprite;
    public RuntimeAnimatorController animatorController;

    public int maxHealth;
    public int damage;
}
