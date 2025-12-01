using UnityEngine;
using UnityEngine.UI;

public interface IEntity
{
    int Health {  get; }
    int Damage {  get; }
    Sprite Sprite { get; }
    Animator Animator { get; }
    void TakeDamage(int amount);
}
