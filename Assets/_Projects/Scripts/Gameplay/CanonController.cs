using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonController : MonoBehaviour
{
    [SerializeField] private InputActionAsset _InputMap;
    [SerializeField] private Transform _CanonPivot;

    [SerializeField] private float _RotationSpeed;

    private Vector2 _RotationDirection;

    private void Start()
    {
        InputActionMap map = _InputMap.FindActionMap("Player");
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
        Vector2 dir = context.ReadValue<Vector2>();
        _RotationDirection = dir;
    }

    private void Update()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        _CanonPivot.localEulerAngles += new Vector3(_RotationDirection.y, _RotationDirection.x, 0);

        float rotX = Mathf.Clamp(_CanonPivot.localEulerAngles.x, 15, 45);
        float rotY = Mathf.Clamp(_CanonPivot.localEulerAngles.y, 15, 45);
        float rotZ = 0;

        _CanonPivot.localEulerAngles = new Vector3(rotX, rotY, rotZ);

    }
}
