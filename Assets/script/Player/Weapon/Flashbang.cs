using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class Flashbang : LightSource
{
    public Move PlayerMove { get; set; }
    public GameObject pistol;
    public GameObject fbLight;
    public float Force { get; set; }
    Rigidbody2D rigid;
    public ShakeCamera Shake { get; set; }

    public float outerRadius;
    public float intensity;

    bool active = false;

    private void Start()
    {
        lightComponent = fbLight.GetComponent<Light2D>();
    }
    private void Update()
    {
        lightComponent.falloffIntensity = Random.Range(0.45f, 0.55f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!active)
        {
            StartCoroutine(Flash());
            active = true;
        }
    }
    public void SetComponent()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Shoot()
    {
        gameObject.SetActive(true);
        transform.position = pistol.transform.position;
        Vector2 vel = pistol.transform.right * Force;
        if (PlayerMove.IsFlip())
            vel *= -1;
        rigid.linearVelocity = vel;
    }
    
    public void Release()
    {
        transform.position = pistol.transform.position;
        active = false;
        gameObject.SetActive(false);
    }
    public IEnumerator Flash()
    {
        yield return new WaitForSeconds(1);
        Lighting();
        DOTween.To(() => outerRadius, x => lightComponent.pointLightOuterRadius = x, outerRadius * 10, 0.5f).SetEase(Ease.OutExpo).OnComplete(Light);
        DOTween.To(() => outerRadius*10, x => lightComponent.pointLightOuterRadius = x, outerRadius, 0.5f).SetEase(Ease.InExpo).SetDelay(1.5f);
        yield return new WaitForSeconds(3);
        Release();
    }
    public void Light()
    {
        Lighting();
    }
}
