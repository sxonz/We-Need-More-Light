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
    public Ease FlyEase { get; set; } = Ease.InCubic;

    float yClamp = 1f;

    float curTime = 0;
    float flyTIme = 1.5f;
    Vector2 move;
    protected override void AnotherStart()
    {
        checkRadius = 10;
    }
    protected override void Move()
    {
        curTime += Time.deltaTime;
        if (curTime >= flyTIme)
        {
            transform.DOMove(move, 1).SetEase(FlyEase);
            curTime = 0;
        }

    }
    protected override void UpdateState()
    {
       if (Vector2.Distance(player.transform.position,transform.position) <= checkRadius)
        {
            move = player.transform.position;
            move.y += FlyHeight;
        }
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
