using UnityEngine;
using DG.Tweening;
public interface IFlyable
{
    float FlyHeight{ get; set; }
    float FlySpeed { get; set; }
    float FlyMaxDistance { get; set; }
    Ease FlyEase { get; set; }
    void FlytoPosition(Vector2 pos);
}

public interface IRanged
{
    GameObject Projectile { get; set; }
    float Range { get; set; }
    void RangeAttack(Transform target);
}

public abstract class Monster : Entity
{
    public int hp;
    public int block;
    protected HPManager hpManager;
    protected int checkRadius;
    protected GameObject player;
    protected Animator anim;
    protected bool isLive;
    private void Start()
    {
        hpManager = GetComponent<HPManager>();
        hpManager.SetStats(hp,block);
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        AnotherStart();
    }
    protected abstract void UpdateState();
    protected abstract void Move();
    protected abstract void AnimManagement();
    protected abstract void Death();
    public abstract void HitByLight(int damage);
    protected virtual void AnotherStart()
    {
        
    }
    public virtual void Stun(float time)
    {

    }
    private void Update()
    {
        UpdateState();
        Move();
        AnimManagement();
    }
}
