using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;
    private Animator animator;
    public bool attackStarted;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (gInput.tryToAttack)
        {
            if (!attackStarted)
            {
                attackStarted = true;
                animator.SetBool("Attack", attackStarted);
            }
            gInput.tryToAttack = false;
        }
    }

    public void Reset()
    {
        attackStarted = false;
        // disable the attack collider

        // call this if you die
        animator.SetBool("Attack", attackStarted);
    }
}
