using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static PlayerControls inputActions;
    public static event Action<InputActionMap> actionMapChange;

    void Awake()
    {
        inputActions = new PlayerControls();
    }

    void Start()
    {
        ToggleActionMap(inputActions.UI);
    }

    public static void ToggleActionMap(InputActionMap actionMap)
    {
        if (actionMap.enabled)
            return;

        inputActions.Disable();
        actionMapChange?.Invoke(actionMap);
        actionMap.Enable();
    }
}
