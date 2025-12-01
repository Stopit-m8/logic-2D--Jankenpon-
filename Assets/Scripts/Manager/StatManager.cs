using TMPro;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;
    public int enemyDefeated = 0;
    public int actionUsed = 0;

    public TMP_Text totalEnemyNum;
    public TMP_Text totalActionNum;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    private void Update()
    {
        totalActionNum.text = actionUsed.ToString();
        totalEnemyNum.text = enemyDefeated.ToString();
    }
}
