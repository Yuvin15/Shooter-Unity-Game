using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions OnFoot;
    private Player_Motor motor;
    private PlayerLook look;


    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        OnFoot = playerInput.OnFoot;
        
        motor = GetComponent<Player_Motor>();
        look = GetComponent<PlayerLook>();

        OnFoot.Jump.performed += ctx => motor.Jump();
    }

    //Update is called once per frame
    void Update()
    {
        motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}