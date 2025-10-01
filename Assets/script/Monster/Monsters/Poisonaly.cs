using DG.Tweening;
using UnityEngine;
enum State
{
    Idle, Track,Hit
}
public class Poisonaly : Monster,IFlyable
{
    public float FlyHeight { get; set; } = 3f;
    public float FlySpeed { get; set; } = 5f;
    public float FlyMaxDistance { get; set; } = 6f;
    public Ease FlyEase { get; set; } = Ease.InOutCubic;
    float yClamp = 1f;

    float curTime = 0;
    float flyTIme = 2f;
    Vector2 move;
    State state = State.Idle;
    public int size = 2;
    protected override void AnotherStart()
    {
        checkRadius = 10;
        isLive = true;
    }
    protected override void Move()
    {
        if (isLive == false)
        {
            return;
        }
        curTime += Time.deltaTime;
        if (curTime >= flyTIme)
        {
            if (state != State.Hit)
                state = State.Track;
            if (move.x - transform.position.x > 0)
            {
                transform.DOScaleX(-size, 0.2f);
            }
            else
            {
                transform.DOScaleX(size, 0.2f);
            }
            transform.DOMove(move, 1.5f + Random.Range(-.2f, .2f)).SetEase(FlyEase).OnComplete(MoveEnd);
            curTime = 0;
        }
    }
    public void MoveEnd()
    {
        if (state != State.Hit)
            state = State.Idle;
    }
    protected override void UpdateState()
    {
       if (Vector2.Distance(player.transform.position,transform.position) <= checkRadius)
        {
            move = player.transform.position;
            move.y += FlyHeight;
            move += new Vector2(Random.Range(-.3f,.3f), Random.Range(-.3f,.3f));
            Vector2 vt = transform.position;
            if ((move - vt).magnitude > FlyMaxDistance)
                move = vt + (move - vt).normalized * FlyMaxDistance;
        }
        else
        {
         
        }
    }
    protected override void AnimManagement()
    {
        if (state == State.Idle)
        {
            anim.SetBool("IsFly", false);
            anim.SetBool("IsHit", false);
        }
        else if (state == State.Track)
        {
            anim.SetBool("IsHit", false);
            anim.SetBool("IsFly", true);
        }
        else if(state == State.Hit)
        {
            anim.SetBool("IsHit", true);
        }
    }
    public override void Stun(float time)
    {
        transform.DOShakePosition(time, 5, 10);
    }
    public override void HitByLight(int damage)
    {
        Debug.Log("fuckstart");
        state = State.Hit;
        hpManager.Damaged(damage);
    }
    public void HitEnd()
    {
        Debug.Log("fuckend");
        state = State.Track;
        AnimManagement();
    }
    protected override void Death()
    {
        isLive = false;
        Rigidbody2D rigid = this.gameObject.AddComponent<Rigidbody2D>();
    }
    public void FlytoPosition(Vector2 pos)
    {

    }

}
