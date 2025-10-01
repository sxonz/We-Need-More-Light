using UnityEngine;
enum Mode
{
    Flash, Lazer, Interactive
}
public class SkillManager : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flash;
    public GameObject lazer;
    FlashlightSkill fl;
    Flashbangshoot fs;
    LazerSkill ls;
    Mode mode = Mode.Flash;
    void ChangeMode(Mode changed)
    {
        switch (changed)
        {
            case Mode.Flash:
            {
                    mode = Mode.Flash;
                    flashlight.SetActive(true);
                    lazer.SetActive(false);

                    break;
            }
            case Mode.Lazer:
            {
                    mode = Mode.Lazer;
                    flashlight.SetActive(false);
                    lazer.SetActive(true);
                    break;
            }
            default:
            {
               
                break;
            }
        }
    }
    private void Start()
    {
        fl = flashlight.GetComponent<FlashlightSkill>();
        fs = GetComponent<Flashbangshoot>();
        ls = GetComponent<LazerSkill>();
    }
    public void OnFlash()
    {
        if (mode != Mode.Flash)
        {
            ChangeMode(Mode.Flash);
            return;
        }
        fl.Flash();
    }
    public void OnFlashbang()
    {
        if (mode != Mode.Flash)
        {
            ChangeMode(Mode.Flash);
            return;
        }
        fs.Bang();
    }
    public void OnLazer()
    {
        if (mode != Mode.Lazer)
        {
            ChangeMode(Mode.Lazer);
            return;
        }
        ls.LazerShoot();

    }
    public void OnRing()
    {
        if (mode != Mode.Lazer)
        {
            ChangeMode(Mode.Lazer);
            return;
        }
        ls.RingShoot();
    }
}
