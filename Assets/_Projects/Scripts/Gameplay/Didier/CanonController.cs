using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _InputMap;

    private void Start()
    {
        var map = _InputMap.FindActionMap("Player");
        bindAction(map.FindAction("Horizontal"), JoystickAction);
    }

    private void bindAction(InputAction binder, Action<InputAction.CallbackContext> action)
    {
        binder.started += action;
        binder.performed += action;
        binder.canceled += action;
    }

    private void JoystickAction(InputAction.CallbackContext context)
    {
        var dir = context.ReadValue<float>();
    }
}
