using System;
using UnityEngine;

[Serializable]
public struct ControllerStruct
{

    public KeyCode _forward;
    public KeyCode _backward;
    public KeyCode _left;
    public KeyCode _right;
    public KeyCode _fire;

    public ControllerStruct(KeyCode _forward, KeyCode _backward, KeyCode _left, KeyCode _right, KeyCode _fire)
    {
        this._forward = _forward;
        this._backward = _backward;
        this._left = _left;
        this._right = _right;
        this._fire = _fire;
}
}
