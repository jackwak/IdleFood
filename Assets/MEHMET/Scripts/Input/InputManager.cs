using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    //Singleton
    public static InputManager Instance;

    //Events
    public static event Action<Vector2> OnStartTouch;
    public static event Action<Vector2> OnEndTouch;

    private TouchControls _touchControls;

    private void Awake()
    {
       _touchControls = new TouchControls();

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    private void OnEnable()
    {
        _touchControls.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
    }

    private void Start()
    {
        _touchControls.Touch.TouchPress.started += context => StartTouch(context);
        _touchControls.Touch.TouchPress.canceled += context => EndTouch(context);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(_touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
