using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 旋转自身
/// </summary>
public class ChinarRotationSelf : MonoBehaviour
{
    public float rotateSpeed = 360f; //旋转速度

    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime); //自转

    }
}