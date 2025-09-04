using UnityEngine;
public class HPManager : MonoBehaviour
{
    int maxHp;
    int currentHp;
    int block;
    public int MaxHP => maxHp;
    public int CurrentHP => currentHp;
    public int Block => block;
    public void SetStats(int maxHp, int block)
    {
        this.maxHp = maxHp;
        this.currentHp = maxHp;
        this.block = block;
    }
    public void Damaged(int damage)
    {
        currentHp -= Mathf.Clamp(damage - block, 0, currentHp);
        if (currentHp <= 0)
        {
            BroadcastMessage("Death");
        }
    }
    public void Heal(int heal)
    {
        currentHp += heal;
        if (currentHp > maxHp)
            currentHp = maxHp;

    }
}
