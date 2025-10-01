using UnityEngine;
using DG.Tweening;
using System.Collections;
using Unity.VisualScripting;

public class Ring : MonoBehaviour
{
    public GameObject stareffect;
    LazerSkill ls;
    bool flying = false;
    bool hooked;
    public float stunTime;
    public bool Hooked { get { return hooked; } }
    public bool Flying { get { return flying; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Monster monster;
        collision.TryGetComponent<Monster>(out monster);
        if (monster)
        {
            monster.Stun(stunTime);
        }

        flying = false;
        ls.RingEnd();
        transform.DOPause();
        hooked = true;
    }
    public void Set(LazerSkill ls)
    {
        this.ls = ls;
    }
    
    public void RingStart()
    {
        flying = true;
        transform.DOMove(transform.position + transform.up * 10, 1f);
        StartCoroutine(Shot());
        StartCoroutine(Wait());
    }
    public void RingEnd()
    {
        flying = false;
        hooked = false;
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        flying = false;
        if (!hooked)
            ls.RingRelease();
    }
    public IEnumerator Shot()
    {
        while (flying)
        {
            yield return new WaitForSeconds(0.1f);
            Instantiate(stareffect, transform.position, Quaternion.identity);
        }
    }
    
}
