﻿using UnityEngine;


/// <summary>
/// 我用中文写的变量，为了方便新手理解，请自行改为自己所需变量
/// </summary>
public class ChinarCamera : MonoBehaviour
{
    public  Transform 被跟踪对象;                 // 被跟踪的对象：pivot——以什么为轴
    public  Vector3   与0点偏移量 = Vector3.zero; // 与目标的偏移量
    public  Transform target;                // 像一个被选中的对象(用于检查cam和target之间的对象)
    public  float     默认距离     = 10.0f;      // 距目标距离(使用变焦)
    public  float     最小距离     = 2f;         //最小距离
    public  float     最大距离     = 15f;        //最大距离
    public  float     速度倍率     = 1f;         //速度倍率
    public  float     X轴速度     = 250.0f;     //x速度
    public  float     Y轴速度     = 120.0f;     //y速度
    public  bool      允许Y轴旋转   = true;       //允许Y轴倾斜
    public  float     Y轴最大角度   = -90f;       //相机向下最大角度
    public  float     Y轴向下最小角度 = 90f;        //相机向上最大角度
    private float     x        = 0.0f;       //x变量
    private float     y        = 0.0f;       //y变量
    private float     目标X      = 0f;         //目标x
    private float     目标Y      = 0f;         //目标y
    private float     目标距离     = 0f;         //目标距离
    private float     X速度      = 1f;         //x速度
    private float     Y速度      = 1f;         //y速度
    private float     相对速度倍率   = 1f;         //速度倍率
    private bool      是第一次开始;


    void Start()
    {
        var angles = transform.eulerAngles;                      //当前的欧拉角
        目标X        = x = angles.x;                               //给x，与目标x赋值
        目标Y        = y = ClampAngle(angles.y, Y轴最大角度, Y轴向下最小角度); //限定相机的向上，与下之间的值，返回给：y与目标y
        目标距离       = 默认距离;                                       //初始距离数据为10；
        是第一次开始     = false;
    }


    void LateUpdate()
    {
        if (被跟踪对象) //如果存在设定的目标
        {
            float scroll            = Input.GetAxis("Mouse ScrollWheel"); //获取滚轮轴
            if (scroll > 0.0f) 目标距离 -= 速度倍率;                              //如果大于0，说明滚动了：那么与目标距离，就减少固定距离1。就是向前滚动，就减少值，致使越来越近
            else if (scroll < 0.0f)
                目标距离 += 速度倍率;                          //距离变远                                              //否则
            目标距离     =  Mathf.Clamp(目标距离, 最小距离, 最大距离); //目标的距离限定在2-15之间
            if (Input.GetMouseButton(1))               //鼠标右键
            {
                目标X += Input.GetAxis("Mouse X") * X轴速度 * 0.02f; //目标的x随着鼠标x移动*5
                if (允许Y轴旋转)                                     //y轴允许倾斜
                {
                    目标Y -= Input.GetAxis("Mouse Y") * Y轴速度 * 0.02f; //目标的y随着鼠标y移动*2.4
                    目标Y =  ClampAngle(目标Y, Y轴最大角度, Y轴向下最小角度);       //限制y的移动范围在-90到90之间
                }


                x             = Mathf.SmoothDampAngle(x, 目标X, ref X速度, 0.3f);
                if (允许Y轴旋转) y = Mathf.SmoothDampAngle(y, 目标Y, ref Y速度, 0.3f);
                else y        = 目标Y;
            }
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            默认距离                = Mathf.SmoothDamp(默认距离, 目标距离, ref 相对速度倍率, 0.5f);
            Vector3 position    = rotation * new Vector3(0.0f, 0.0f, -默认距离) + 被跟踪对象.position + 与0点偏移量;
            transform.rotation  = rotation;
            transform.position  = position;
        }
    }


    /// <summary>
    /// 限定一个值，在最小和最大数之间，并返回
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle  -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}