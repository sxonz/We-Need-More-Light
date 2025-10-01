using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
public class LightSource : MonoBehaviour
{
    public Light2D lightComponent;
    public Collider2D colliderComponent;
    [SerializeField] private LayerMask targetLayers = -1;
    [SerializeField] private int rayCount = 30;

    protected List<GameObject> Lighting()
    {
        HashSet<GameObject> objects = new HashSet<GameObject>();

        float range = lightComponent.pointLightOuterRadius;
        float halfAngle = lightComponent.pointLightOuterAngle / 2f;
        Vector3 lightDirection = transform.up;

        for (int i = 0; i < rayCount; i++)
        {
            float angle = Mathf.Lerp(-halfAngle, halfAngle, (float)i / (rayCount - 1));
            Vector3 rayDirection = Quaternion.AngleAxis(angle, Vector3.forward) * lightDirection;

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, rayDirection, range, targetLayers);

            foreach(RaycastHit2D hit in hits)
            {
                if (hit.collider != null)
                {
                    GameObject g = hit.collider.gameObject;
                    if (objects.Contains(g) || g == this.gameObject)
                        continue;
                    objects.Add(hit.collider.gameObject);
                    Debug.Log($"Hit: {hit.collider.name} at distance: {hit.distance}"); 
                }
            }
        }

        return new List<GameObject>(objects);
    }
    protected virtual List<GameObject> ColliderLighting()
    {
        List<GameObject> objects = new();

        return objects;
    }
}