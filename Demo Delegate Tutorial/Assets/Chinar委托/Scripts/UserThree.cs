using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 顾客C
/// </summary>
public class UserThree : MonoBehaviour
{
    public        ChinarDelegate Cd;            //委托对象
    public static Text           temporaryText; //临时文本,设置公有静态是为了 方便调用颜色属性，去改变服务员文本颜色


    void Start()
    {
        Cd            =  GameObject.Find("MountScript").GetComponent<ChinarDelegate>(); //获取对象
        Cd.callNumber += LookScreen;                                                    //当 叫号的委托对象中，有多个方法调用时，需要用 += 添加
        Cd.someFood   += WaitCola;                                                      //委托对象添加 顾客3的可乐
        temporaryText =  transform.Find("Speak/Text").GetComponent<Text>();
    }


    /// <summary>
    /// 服务员叫可乐时，委托事件才会触发
    /// </summary>
    public bool WaitCola(string food)
    {
        if (food == "可乐")
        {
            temporaryText.text = "这里，我要的可乐";
            ChinarDelegate.Move(gameObject);
            StopCoroutine(ClearText());
            StartCoroutine(ClearText());
            return true;
        }

        return false;
    }


    /// <summary>
    /// 抬头看大屏幕
    /// </summary>
    public void LookScreen()
    {
        temporaryText.text = "顾客C看向大屏幕";
        StopCoroutine(ClearText());
        StartCoroutine(ClearText());
    }


    /// <summary>
    /// 清理文本内容
    /// </summary>
    /// <returns></returns>
    IEnumerator ClearText()
    {
        yield return new WaitForSeconds(3);
        temporaryText.text = "";
    }
}