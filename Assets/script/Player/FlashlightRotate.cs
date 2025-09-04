using UnityEngine;

public class FlashlightRotate : MonoBehaviour
{
    public GameObject offset;
    public Move move;

    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = 0f;

        Vector3 dir = mouseWorldPos - offset.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;

        if (move.IsFlip())
            angle = angle < 90 ? Mathf.Clamp(angle, -90, -10) : Mathf.Clamp(angle,190, 270);
        else
            angle = Mathf.Clamp(angle, 10, 170);
        offset.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
