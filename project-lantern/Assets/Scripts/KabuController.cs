using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class KabuController : MonoBehaviour
{
    [SerializeField] bool isHidden;
    private Light2D kabuLight;
    private int changeTime = 0;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        kabuLight = GetComponent<Light2D>();

        if (isHidden) kabuLight.intensity = 0;
        else kabuLight.intensity = 1;
        
        anim.SetBool("isHidden", isHidden);
    }
    void Update()
    {
        if (isHidden && changeTime == 3) {
            changeTime = 0;
            isHidden = false;

            kabuLight.intensity = 1;

            anim.SetBool("isHidden", false);
            anim.SetBool("Appeared", true);
            anim.SetBool("Hid", false);
        } else if (!isHidden && changeTime == 2) {
            changeTime = 0;
            isHidden = true;

            kabuLight.intensity = 0;

            anim.SetBool("isHidden", true);
            anim.SetBool("Appeared", false);
            anim.SetBool("Hid", true);
        }
    }

    public void ChangeState() {
        changeTime++;
    }

    public bool GetIsHidden() {
        return isHidden;
    }
}
