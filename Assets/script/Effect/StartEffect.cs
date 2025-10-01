using UnityEngine;
using DG.Tweening;
public class StartEffect : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(new Vector3(3,3,0), 0.5f).SetEase(Ease.Flash);
        transform.DOScale(Vector3.zero, 1f).SetEase(Ease.InExpo).SetDelay(0.5f).OnComplete(End);
    }
    public void End()
    {
        Destroy(gameObject);
    }

}
