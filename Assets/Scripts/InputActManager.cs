using MyFPS;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputActManager : Singleton<InputActManager>
{
    public InputActionProperty leftAction;
    public InputActionProperty rightAction;

    public float leftActValue;
    public float rightActValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftActValue = leftAction.action.ReadValue<float>();
        rightActValue = rightAction.action.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool IsLeftAct()
    {
        float L_act = leftAction.action.ReadValue<float>();

        return L_act > 0.1f;
    }
    public bool IsRightAct()
    {
        float R_act = rightAction.action.ReadValue<float>();

        return R_act > 0.1f;
    }



}
