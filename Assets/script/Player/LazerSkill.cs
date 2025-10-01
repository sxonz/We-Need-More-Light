using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class LazerSkill : MonoBehaviour
{
    Rigidbody2D rigid;

    int count = 1;
    int current = 0;

    public GameObject offset;
    public GameObject revoffset;
    GameObject Lazer;
    Queue<GameObject> Lazers = new();

    Ring ringComponent;
    public GameObject RingPrefab;
    GameObject ring;
    SpringJoint2D springJoint;
    Rigidbody2D ringRigid;
    bool jointed = false;
    bool end = false;

    bool isCool = false;
    Light2D LmodeFlashlight;
    
    public float dr;



    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        ring = Instantiate(RingPrefab, transform.position, Quaternion.identity);
        ringComponent = ring.GetComponent<Ring>();
        ringComponent.Set(this);
        ringRigid = ring.GetComponent<Rigidbody2D>();
        ring.SetActive(false);
    }

    public void CountUp()
    {
        count += 1;
        GameObject newLazer = Instantiate(Lazer, transform.position, Quaternion.identity);
        newLazer.SetActive(false);
        Lazers.Enqueue(newLazer);
    }
    public void LazerShoot()
    {
        if (count > current)
        {
            GameObject use = Lazers.Dequeue();
            use.SetActive(true);
        }
    }
    private void Update()
    {
    }
    public void RingEnd()
    {
        Hook();
    }
    public void RingShoot()
    {
        if (ringComponent.Flying)
        {
            return;
        }
        if (jointed)
        {
            Hook();
            return;
        }
        ring.SetActive(true);
        ring.transform.position = offset.transform.position;
        ring.transform.rotation = revoffset.transform.rotation;
        ringComponent.RingStart();
    }
    void Hook()
    {
        if (jointed)
        {
            HookEnd();
            return;
        }
        jointed = true;
        springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.connectedBody = ringRigid;
        springJoint.dampingRatio = dr;

    }
    void HookEnd()
    {
        if (end) return;
        end = true;
        StartCoroutine(HookDestroy());
    }
    IEnumerator HookDestroy()
    {
        springJoint.distance /= 2;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            yield return null;
        }

        Destroy(springJoint);
        springJoint = null;
        jointed = false;
        end = false;
        RingRelease();
    }
    public void RingRelease()
    {
        ring.transform.position = offset.transform.position;
        ring.SetActive(false);
    }
}
