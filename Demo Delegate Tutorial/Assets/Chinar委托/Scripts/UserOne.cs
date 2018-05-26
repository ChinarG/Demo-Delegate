using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 顾客A
/// </summary>
public class UserOne : MonoBehaviour
{
    public  ChinarDelegate Cd;            //声明委托对象所在的类对象//实例化一个类对象 在内存中重新开辟一块内存空间 创建了一个新的类对象
    public static Text temporaryText; //临时文本,设置公有静态是为了 方便调用颜色属性，去改变服务员文本颜色



    void Start()
    {
        Cd            = GameObject.Find("MountScript").GetComponent<ChinarDelegate>(); //赋值
        Cd.callNumber += LookScreen;
        temporaryText = transform.Find("Speak/Text").GetComponent<Text>();

        //2添加委托函数
        //委托函数的添加方式：可以用 = 号 
        //如果想添加多个委托 需要用 +=号
        //删除委托用： -=
    }


    /// <summary>
    /// 抬头看大屏幕
    /// </summary>
    public void LookScreen()
    {
        temporaryText.text = "顾客A看向大屏幕";
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