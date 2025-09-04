using UnityEngine;
public class SkillManager : MonoBehaviour
{
    public GameObject flashlight;
    FlashlightSkill fl;
    Flashbangshoot fs;
    private void Start()
    {
        fl = flashlight.GetComponent<FlashlightSkill>();
        fs = GetComponent<Flashbangshoot>();
    }
    public void OnFlash()
    {
        fl.Flash();
    }
    public void OnFlashbang()
    {
        fs.Bang();
    }
}
