using DG.Tweening;
using UnityEngine;
enum State
{
    Idle, Track
}
public class Poisonaly : Monster,IFlyable
{
    public float FlyHeight { get; set; } = 5f;
    public float FlySpeed { get; set; } = 5f;
    public float FlyMaxDistance { get; set; } = 6f;
    public Ease FlyEase { get; set; } = Ease.InElastic;

    float yClamp = 1f;
    Vector2 move;
    protected override void Move()
    {
        transform.DOMove(move, 1).SetEase(FlyEase);
    }
    protected override void UpdateState()
    {
       
    }
    protected override void AnimManagement()
    {
       
    }
    protected override void Death()
    {
        
    }
    public void FlytoPosition(Vector2 pos)
    {

    }

}
