using System.Collections;
using UnityEngine;

public class Flashbangshoot : MonoBehaviour {
    public GameObject pistol;
    public GameObject flashbangObject;
    GameObject flash;
    Flashbang fb;
    public float force;
    public bool isCool = false;
    public void Bang()
    {
        if (flash == null)
        {
            flash = Instantiate(flashbangObject, pistol.transform.position, Quaternion.identity);
            fb = flash.GetComponent<Flashbang>();
            fb.SetComponent();
            fb.pistol = pistol;
            fb.Force = force;
            fb.PlayerMove = GetComponent<Move>();
        }
        if (isCool == false)
        {
            fb.Shoot();
            isCool = true;
            StartCoroutine(Wait());
        }
        
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        isCool = false;
    }
}
