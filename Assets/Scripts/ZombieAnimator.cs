using UnityEngine;
using System.Collections;

public class ZombieAnimator : MonoBehaviour 
{
    Animator anim;
    int attackHash = Animator.StringToHash("attack");
    int walkStateHash = Animator.StringToHash("walk");
    public bool isAttacking = false; 

    void Start ()
    {
        anim = GetComponent<Animator>();
    }


    void Update ()
    {
        // float move = Input.GetAxis ("Vertical");
        // anim.SetFloat("Forward", move);

        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(isAttacking && stateInfo.nameHash == walkStateHash)
        {
            anim.SetTrigger (attackHash);
        }
    }
}