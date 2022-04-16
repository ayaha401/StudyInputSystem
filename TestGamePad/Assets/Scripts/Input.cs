using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

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
        }
        else
        {
            Debug.Log("�ڑ�");
            _connectGamePad = true;
        }

        if(Mathf.Abs(Horizontal(_connectGamePad)) == 1.0f)
        {
            if(Horizontal(_connectGamePad) == 1.0f)
            {
                Debug.Log("�E�ړ�");
            }
            else
            {
                Debug.Log("���ړ�");
            }
        }

        if(RightTriggerDown(_connectGamePad) == true)
        {
            Debug.Log("RT�����ꂽ");
        }

        if (SouthButtonDown(_connectGamePad) == true)
        {
            Debug.Log("�W�����v");
        }

        if (WestButtonDown(_connectGamePad) == true)
        {
            Debug.Log("����");
        }

        if (LeftShoulderDown(_connectGamePad) == true)
        {
            Debug.Log("LB�����ꂽ");
        }

        if (RightShoulderDown(_connectGamePad) == true)
        {
            Debug.Log("RB�����ꂽ");
        }

        if (StartButtonDown(_connectGamePad) == true)
        {
            Debug.Log("�X�^�[�g�����ꂽ");
        }

        if(NorthButtonDown(_connectGamePad) == true)
        {
            Debug.Log("�}�b�v�{�^�������ꂽ");
        }
    }

    private float Horizontal(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            Vector2 leftStickVec = Gamepad.current.leftStick.ReadValue();
            if(leftStickVec.x <= -0.9f)
            {
                return Math.Sign(leftStickVec.x);
            }
            else if(leftStickVec.x >= 0.9f)
            {
                return Math.Sign(leftStickVec.x);
            }
            else
            {
                return 0.0f;
            }
        }
        else
        {
            if(Keyboard.current[Key.A].IsPressed())
            {
                return -1.0f;
            }
            else if(Keyboard.current[Key.D].IsPressed())
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }
    }

    private bool StartButtonDown(bool connectedGamePad)
    {
        if(connectedGamePad == true)
        {
            return Gamepad.current.startButton.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.Escape].wasPressedThisFrame;
        }
    }

    private bool NorthButtonDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.buttonNorth.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.M].wasPressedThisFrame;
        }
    }

    private bool SouthButtonDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.buttonSouth.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.Space].wasPressedThisFrame;
        }
    }

    private bool WestButtonDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.buttonEast.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.Space].wasPressedThisFrame;
        }
    }

    private bool RightShoulderDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.rightShoulder.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.E].wasPressedThisFrame;
        }
    }

    private bool LeftShoulderDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.leftShoulder.wasPressedThisFrame;
        }
        else
        {
            return Keyboard.current[Key.Q].wasPressedThisFrame;
        }
    }

    private bool RightTriggerDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return (Gamepad.current.rightTrigger.ReadValue() >= 1.0f);
        }
        else
        {
            return (Mouse.current.leftButton.IsPressed());
        }
    }

    private Vector2 RightStickMove(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            return Gamepad.current.rightStick.ReadValue();
        }
        else
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToViewportPoint(Mouse.current.position.ReadValue());
            mousePos = mousePos * 2.0f;
            mousePos = new Vector3(mousePos.x - 1.0f, mousePos.y - 1.0f).normalized;
            return mousePos;
        }
    }

    private void OnGUI()
    {
        GUILayout.Label($"RightStick: {RightStickMove(_connectGamePad)}");
    }
}


