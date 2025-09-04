using UnityEngine;
using DG.Tweening;
using Unity.Cinemachine;
using System.Collections;
public class ShakeCamera : MonoBehaviour
{
    public GameObject camera;
    public GameObject cinemachine;
    CinemachineImpulseSource impulseSource; 
    public float duration;
    public float strength;

    float dfDuration = .5f;
    float dfStrength = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Shake()
    {
        Shake(dfDuration, dfStrength);
    }
    public void Shake(float duration, float strength)
    {
        StartCoroutine(ShakeCoroutine(duration, strength));
    }

    IEnumerator ShakeCoroutine(float duration, float strength)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            Vector3 shakeVec = new Vector3(Random.Range(-strength, strength), Random.Range(-strength, strength));
            impulseSource.GenerateImpulse(shakeVec);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            Shake(2, 1);
    }
}
