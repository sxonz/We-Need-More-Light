using UnityEngine;
using DG.Tweening;
public class Move : MonoBehaviour
{
    bool isflip;
    public int moveSpeed = 5;
    Rigidbody2D rigid;
    SpriteRenderer sr;
    Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0)
        {

            anim.SetBool("iswalk", true);
            if (x < 0)
            {
                isflip = true;
                transform.DOScale(new Vector3(-1, 1, 1),0.1f);
            }
            else
            {
                isflip = false;
                transform.DOScale(new Vector3(1, 1, 1), 0.1f);
            }
        }
        else
            anim.SetBool("iswalk", false);

        Vector2 pos = transform.position;
        pos += Vector2.right * x * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public bool IsFlip()
    {
        return isflip;
    }

}
