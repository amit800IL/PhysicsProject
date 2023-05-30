using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private BoxFacility inputActions;
    public BoxFacility InputActions { get => inputActions; private set => inputActions = value; }
    public static InputManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        Instance = this;
        InputActions = new();
        InputActions.Enable();
    }

    public Vector2 GetMoveValue(InputValue value) => value.Get<Vector2>();

    public Vector2 GetLookValue(InputValue value) => value.Get<Vector2>();
   
}
