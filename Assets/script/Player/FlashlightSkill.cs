using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System;
using UnityEditor;
public class FlashlightSkill : LightSource
{
    bool isCool;
    public float innerRadius;
    public float outerRadius;
    public float outerAngle;
    public float duration;
    public float recharge;
    public float coolTime;

    void Start()
    {
        lightComponent = GetComponent<Light2D>();
    }
    public void Flash()
    {
        if (isCool)
            return;
        isCool = true;
        DOTween.To(() => outerRadius, x => lightComponent.pointLightOuterRadius = x, outerRadius * 3, 0.2f).SetEase(Ease.OutBack).OnComplete(Test);
        DOTween.To(() => innerRadius, x => lightComponent.pointLightInnerRadius = x, outerRadius * 1.5f, 0.25f).SetEase(Ease.OutCubic);
        DOTween.To(() => outerAngle, x => lightComponent.pointLightOuterAngle = x, outerAngle + 20, 0.2f);

        DOTween.To(() => outerRadius * 3, x => lightComponent.pointLightOuterRadius = x, outerRadius, 0.2f).SetEase(Ease.OutBack).SetDelay(duration);
        DOTween.To(() => outerRadius*1.5f, x => lightComponent.pointLightInnerRadius = x, innerRadius, 1f).SetEase(Ease.InCubic).SetDelay(duration);
        DOTween.To(() => outerAngle+20, x => lightComponent.pointLightOuterAngle = x, outerAngle, 0.2f).SetDelay(duration);

        DOTween.To(() => lightComponent.intensity, x => lightComponent.intensity = x, 0, 0.5f).SetEase(Ease.InOutBounce).SetDelay(duration+0.3f);
        DOTween.To(() => 0, x => lightComponent.intensity = x, 1, recharge).SetDelay(duration + 0.8f).OnComplete(FlashEnd);
    }
    private void Test()
    {
        Lighting();
    }
    private void FlashEnd()
    {
        StartCoroutine(Wait(coolTime,SetCooltime));
    }
    private void SetCooltime()
    {
        isCool = false;
    }
    IEnumerator Wait(float second, Action set)
    {
        yield return new WaitForSeconds(second);
        set();
    }

}
