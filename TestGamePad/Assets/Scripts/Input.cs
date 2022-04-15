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
            Debug.Log("���ڑ�");
            _connectGamePad = false;
            return;
        }
        else
        {
            Debug.Log("�ڑ�");
            _connectGamePad = true;
        }
        
      
        if(_connectGamePad == true)
        {
            if(Gamepad.current.leftStick.ReadValue().x >= 0.9f)
            {
                Debug.Log("�E");
            }

            if (Gamepad.current.leftStick.ReadValue().x <= -0.9f)
            {
                Debug.Log("��");
            }

            if (Gamepad.current.leftStick.ReadValue().y >= 0.9f)
            {
                Debug.Log("��");
            }

            if (Gamepad.current.leftStick.ReadValue().y <= -0.9f)
            {
                Debug.Log("��");
            }

            if(Gamepad.current.rightTrigger.ReadValue() >= 1.0)
            {
                Debug.Log("RT�����ꂽ");
            }

            if (Gamepad.current.startButton.wasPressedThisFrame == true)
            {
                Debug.Log("�X�^�[�g�����ꂽ");
            }

            if (Gamepad.current.leftShoulder.wasPressedThisFrame == true)
            {
                Debug.Log("LB�����ꂽ");
            }

            if (Gamepad.current.rightShoulder.wasPressedThisFrame == true)
            {
                Debug.Log("RB�����ꂽ");
            }

            if (Gamepad.current.buttonNorth.wasPressedThisFrame == true)
            {
                Debug.Log("Y�����ꂽ");
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
