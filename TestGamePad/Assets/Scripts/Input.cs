using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private bool _connectGamePad = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Gamepad.current == null)
        {
            Debug.Log("未接続");
            _connectGamePad = false;
            return;
        }
        else
        {
            Debug.Log("接続");
            _connectGamePad = true;
        }
        
      
        if(_connectGamePad == true)
        {
            if(Gamepad.current.leftStick.ReadValue().x >= 0.9f)
            {
                Debug.Log("右");
            }

            if (Gamepad.current.leftStick.ReadValue().x <= -0.9f)
            {
                Debug.Log("左");
            }

            if (Gamepad.current.leftStick.ReadValue().y >= 0.9f)
            {
                Debug.Log("上");
            }

            if (Gamepad.current.leftStick.ReadValue().y <= -0.9f)
            {
                Debug.Log("下");
            }

            if(Gamepad.current.rightTrigger.ReadValue() >= 1.0)
            {
                Debug.Log("RT押された");
            }

            if (Gamepad.current.startButton.wasPressedThisFrame == true)
            {
                Debug.Log("スタート押された");
            }

            if (Gamepad.current.leftShoulder.wasPressedThisFrame == true)
            {
                Debug.Log("LB押された");
            }

            if (Gamepad.current.rightShoulder.wasPressedThisFrame == true)
            {
                Debug.Log("RB押された");
            }

            if (Gamepad.current.buttonNorth.wasPressedThisFrame == true)
            {
                Debug.Log("Y押された");
            }
        }
        else
        {

        }
    }

    private void OnGUI()
    {
        if (Gamepad.current == null) return;
        GUILayout.Label($"RightStick: {Gamepad.current.rightStick.ReadValue()}");
    }
}
