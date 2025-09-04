using UnityEngine;

enum Effect
{
    stunned,
    poisoned,
    slowed,
    blooded,
    EffectCount
}
public class Entity : MonoBehaviour
{
    public int[] remainTime = new int[(int)Effect.EffectCount];
    public int[] amount = new int[(int)Effect.EffectCount];
}
