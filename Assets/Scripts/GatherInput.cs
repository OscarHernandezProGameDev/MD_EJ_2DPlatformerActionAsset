using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    public InputActionAsset actionAsset;

    private InputActionMap playerNormal;
    private InputAction jumpAction;
    private InputAction moveAction;
    private InputAction attackAction;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;

    void Awake()
    {
        playerNormal = actionAsset.FindActionMap("PlayerNormal");
        jumpAction = playerNormal.FindAction("Jump");
        moveAction = playerNormal.FindAction("MoveHorizontal");
        attackAction = playerNormal.FindAction("Attack");
    }

    void OnEnable()
    {
        jumpAction.performed += JumpExample;
        jumpAction.canceled += JumpStopExample;

        attackAction.performed += AttackExample;
        attackAction.canceled += AttackStopExample;

        actionAsset.Enable();
        playerNormal.Enable();
    }

    void Update()
    {
        valueX = moveAction.ReadValue<float>();
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
        jumpAction.performed -= JumpExample;
        jumpAction.canceled -= JumpStopExample;

        attackAction.performed -= AttackExample;
        attackAction.canceled -= AttackStopExample;

        actionAsset.Disable();
        playerNormal.Disable();
    }
}
