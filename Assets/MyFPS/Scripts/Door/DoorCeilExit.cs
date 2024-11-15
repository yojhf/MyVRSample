using MyFPS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCeilExit : Interactive
{
    [SerializeField] private string loadScene = "PlayScene02";

    public AudioSource openSound;
    public AudioSource mainBgm;

    Animator animator;

    protected override void Action()
    {
        animator.SetBool("isOpen", true);
        transform.GetComponent<Collider>().enabled = false;
        openSound.Play();

        ChangeScene();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeScene()
    {
        mainBgm.Stop();

        SceneFade.instance.FadeOut(loadScene);
    }
    
}
