using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject badanTank;

    [SerializeField]
    private GameObject atasTank;

    [SerializeField]
    private InputStruct inputStruct;

    [SerializeField]
    private float _rotateSpeed;

    [SerializeField]
    private float _moveRotateSpeed;

    [SerializeField]
    private float _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SetShootInput();
    }

    void Update()
    {
        CheckMove();   
    }

    private void CheckMove()
    {
        if (Input.GetKey(inputStruct._forward))
        {
            MoveBase(1);
        }
        if (Input.GetKey(inputStruct._backward))
        {
            MoveBase(-1);
        }
        if (Input.GetKey(inputStruct._left))
        {
            RotateAtas(-1);
        }
        if (Input.GetKey(inputStruct._right))
        {
            RotateAtas(1);
        }
    }

    private void RotateAtas(int minus)
    {
        atasTank.transform.Rotate(Vector3.up * _rotateSpeed * minus * Time.deltaTime);
    }

    private void MoveBase(int minus)
    {
        var forward = atasTank.transform.forward;

        forward.y = 0f;
        forward.Normalize();

        transform.Translate(forward * minus * _moveSpeed  * Time.deltaTime);
        FixRotate();
    }

    private void FixRotate()
    {
        var from = badanTank.transform;
        var to = atasTank.transform;
        badanTank.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.deltaTime * _moveRotateSpeed);
    }

    private void SetShootInput()
    {
        TankShoot shoot = gameObject.GetComponent<TankShoot>();
        shoot.SetShootInput(inputStruct._fire);
    }
}
