using UnityEngine;

public class Draw : MonoBehaviour
{
    public int textureWidth = 256;
    public int textureHeight = 256;
    public Color drawColor = Color.black;

    private Texture2D texture;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        // �� �ؽ�ó ����
        texture = new Texture2D(textureWidth, textureHeight, TextureFormat.ARGB32, false);
        ClearTexture();

        // Sprite�� ����� SpriteRenderer�� �ֱ�
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, textureWidth, textureHeight), new Vector2(0.5f, 0.5f), 100f);
        sr.sprite = sprite;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int pixel = WorldToPixel(mouseWorldPos);

            if (pixel.x >= 0 && pixel.x < textureWidth && pixel.y >= 0 && pixel.y < textureHeight)
            {
                texture.SetPixel(pixel.x, pixel.y, drawColor);
                texture.Apply(); // �ݵ�� ȣ���ؾ� �ݿ���
            }
        }
    }

    Vector2Int WorldToPixel(Vector2 worldPos)
    {
        Vector2 localPos = transform.InverseTransformPoint(worldPos);
        float unitsPerPixel = 1f / textureWidth; // ��������Ʈ�� 1x1 ���� ũ���� �� ����
        int px = Mathf.FloorToInt((localPos.x + 0.5f) * textureWidth);
        int py = Mathf.FloorToInt((localPos.y + 0.5f) * textureHeight);
        return new Vector2Int(px, py);
    }

    void ClearTexture()
    {
        Color clearColor = new Color(1, 1, 1, 0); // ������ ���
        Color[] pixels = new Color[textureWidth * textureHeight];
        for (int i = 0; i < pixels.Length; i++) pixels[i] = clearColor;
        texture.SetPixels(pixels);
        texture.Apply();
    }
}
