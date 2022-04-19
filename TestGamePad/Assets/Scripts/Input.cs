using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Input : MonoBehaviour
{
    private bool _connectGamePad = false;
    private bool _leftInputDowned = false;
    private bool _rightInputDowned = false;
    private bool _upInputDowned = false;
    private bool _downInputDowned = false;
    private bool _rightTriggerDowned = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Gamepad.current == null)
        {
            Debug.Log("未接続");
            _connectGamePad = false;
        }
        else
        {
            Debug.Log("接続");
            _connectGamePad = true;
        }

        //if(Mathf.Abs(Horizontal(_connectGamePad)) == 1.0f)
        //{
        //    if(Horizontal(_connectGamePad) == 1.0f)
        //    {
        //        Debug.Log("右移動");
        //    }
        //    else
        //    {
        //        Debug.Log("左移動");
        //    }
        //}

        //if(Mathf.Abs(Vertical(_connectGamePad)) == 1.0f)
        //{
        //    if(Vertical(_connectGamePad) == 1.0f)
        //    {
        //        Debug.Log("上移動");
        //    }
        //    else
        //    {
        //        Debug.Log("下移動");
        //    }
        //}

        if(RightTriggerDown(_connectGamePad) == true)
        {
            Debug.Log("RT押された");
        }

        if (SouthButtonDown(_connectGamePad) == true)
        {
            Debug.Log("ジャンプ");
        }

        if (WestButtonDown(_connectGamePad) == true)
        {
            Debug.Log("決定");
        }

        if (LeftShoulderDown(_connectGamePad) == true)
        {
            Debug.Log("LB押された");
        }

        if (RightShoulderDown(_connectGamePad) == true)
        {
            Debug.Log("RB押された");
        }

        if (StartButtonDown(_connectGamePad) == true)
        {
            Debug.Log("スタート押された");
        }

        if(NorthButtonDown(_connectGamePad) == true)
        {
            Debug.Log("マップボタン押された");
        }

        if(LeftInputDown(_connectGamePad) == true)
        {
            Debug.Log("LeftDown");
        }

        if(RightInputDown(_connectGamePad) == true)
        {
            Debug.Log("RightDown");
        }

        if(UpInputDown(_connectGamePad) == true)
        {
            Debug.Log("UpDown");
        }

        if(DownInputDown(_connectGamePad) == true)
        {
            Debug.Log("DownDown");
        }

        if(RightTriggerUp(_connectGamePad) == true)
        {
            Debug.Log("RightTriggerUp");
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

    private bool LeftInputDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            if(Gamepad.current.dpad.left.wasPressedThisFrame)
            {
                return true;
            }

            if(Gamepad.current.leftStick.ReadValue().x == 0.0f)
            {
                _leftInputDowned = false;
                _rightInputDowned = false;
                _upInputDowned = false;
                _downInputDowned = false;
            }

            if (_leftInputDowned == false && Gamepad.current.leftStick.ReadValue().x > 0.0f && (Mathf.Abs(Gamepad.current.leftStick.ReadValue().x) > Mathf.Abs(Gamepad.current.leftStick.ReadValue().y)))
            {
                _leftInputDowned = true;
                _rightInputDowned = true;
                _upInputDowned = true;
                _downInputDowned = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return Keyboard.current[Key.A].wasPressedThisFrame;
        }
    }

    private bool RightInputDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            if (Gamepad.current.dpad.right.wasPressedThisFrame)
            {
                return true;
            }

            if (Gamepad.current.leftStick.ReadValue().x == 0.0f)
            {
                _leftInputDowned = false;
                _rightInputDowned = false;
                _upInputDowned = false;
                _downInputDowned = false;
            }

            if (_rightInputDowned == false && Gamepad.current.leftStick.ReadValue().x < 0.0f && (Mathf.Abs(Gamepad.current.leftStick.ReadValue().x) > Mathf.Abs(Gamepad.current.leftStick.ReadValue().y)))
            {
                _leftInputDowned = true;
                _rightInputDowned = true;
                _upInputDowned = true;
                _downInputDowned = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return Keyboard.current[Key.D].wasPressedThisFrame;
        }
    }

    private float Vertical(bool connectedGamePad)
    {
        if(connectedGamePad == true)
        {
            Vector2 leftStickVec = Gamepad.current.leftStick.ReadValue();
            if (leftStickVec.y <= -0.9f)
            {
                return Math.Sign(leftStickVec.y);
            }
            else if (leftStickVec.y >= 0.9f)
            {
                return Math.Sign(leftStickVec.y);
            }
            else
            {
                return 0.0f;
            }
        }
        else
        {
            if(Keyboard.current[Key.S].IsActuated())
            {
                return -1.0f;
            }
            else if(Keyboard.current[Key.W].IsPressed())
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }
    }

    private bool UpInputDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            if (Gamepad.current.dpad.up.wasPressedThisFrame)
            {
                return true;
            }

            if (Gamepad.current.leftStick.ReadValue().y == 0.0f)
            {
                _leftInputDowned = false;
                _rightInputDowned = false;
                _upInputDowned = false;
                _downInputDowned = false;
            }

            if (_rightInputDowned == false && Gamepad.current.leftStick.ReadValue().y > 0.0f && (Mathf.Abs(Gamepad.current.leftStick.ReadValue().y) > Mathf.Abs(Gamepad.current.leftStick.ReadValue().x)))
            {
                _leftInputDowned = true;
                _rightInputDowned = true;
                _upInputDowned = true;
                _downInputDowned = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return Keyboard.current[Key.W].wasPressedThisFrame;
        }
    }

    private bool DownInputDown(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            if (Gamepad.current.dpad.down.wasPressedThisFrame)
            {
                return true;
            }

            if (Gamepad.current.leftStick.ReadValue().y == 0.0f)
            {
                _leftInputDowned = false;
                _rightInputDowned = false;
                _upInputDowned = false;
                _downInputDowned = false;
            }

            if (_rightInputDowned == false && Gamepad.current.leftStick.ReadValue().y < 0.0f && (Mathf.Abs(Gamepad.current.leftStick.ReadValue().y) > Mathf.Abs(Gamepad.current.leftStick.ReadValue().x)))
            {
                _leftInputDowned = true;
                _rightInputDowned = true;
                _upInputDowned = true;
                _downInputDowned = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return Keyboard.current[Key.S].wasPressedThisFrame;
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
            if(Gamepad.current.rightTrigger.ReadValue() >= 1.0f)
            {
                _rightTriggerDowned = true;
                return true;
            }
            else
            {
                //_rightTriggerDowned = false;
                return false;
            }
            //return (Gamepad.current.rightTrigger.ReadValue() >= 1.0f);
        }
        else
        {
            return (Mouse.current.leftButton.IsPressed());
        }
    }

    private bool RightTriggerUp(bool connectedGamePad)
    {
        if (connectedGamePad == true)
        {
            if(_rightTriggerDowned == true && Gamepad.current.rightTrigger.ReadValue() < 0.05f)
            {
                _rightTriggerDowned = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return Mouse.current.leftButton.wasReleasedThisFrame;
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


