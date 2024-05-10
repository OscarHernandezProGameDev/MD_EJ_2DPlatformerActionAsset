using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;

    void Update()
    {
        if (gInput.tryToAttack)
        {
            gInput.tryToAttack = false;
        }
    }
}