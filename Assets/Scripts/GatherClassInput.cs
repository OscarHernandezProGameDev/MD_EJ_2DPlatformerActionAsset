using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherClassInput : MonoBehaviour
{
    private Controls myControls;
    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    void Awake()
    {
        myControls = new Controls();
    }

    void OnEnable()
    {
        myControls.PlayerNormal.Jump.performed += JumpExample;
        myControls.PlayerNormal.Jump.canceled += JumpStopExample;
        myControls.PlayerNormal.Attack.performed += AttackExample;
        myControls.PlayerNormal.Attack.canceled += AttackStopExample;

        myControls.Enable();
    }

    void Update()
    {
        valueX = myControls.PlayerNormal.MoveHorizontal.ReadValue<float>();
        Debug.Log($"ValueX is {valueX}");
    }

    private void JumpExample(InputAction.CallbackContext context)
    {
        tryToJump = true;
    }

    private void JumpStopExample(InputAction.CallbackContext context)
    {
        tryToJump = false;
    }

    private void AttackExample(InputAction.CallbackContext context)
    {
        tryToAttack = true;
    }

    private void AttackStopExample(InputAction.CallbackContext context)
    {
        tryToAttack = false;
    }

    void OnDisable()
    {
        myControls.PlayerNormal.Jump.performed -= JumpExample;
        myControls.PlayerNormal.Jump.canceled -= JumpStopExample;
        myControls.PlayerNormal.Attack.performed -= AttackExample;
        myControls.PlayerNormal.Attack.canceled -= AttackStopExample;

        myControls.Disable();
    }
}