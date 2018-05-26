using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 顾客B
/// </summary>
public class UserTwo : MonoBehaviour
{
    public        ChinarDelegate Cd;
    public static Text           temporaryText; //临时文本,设置公有静态是为了 方便调用颜色属性，去改变服务员文本颜色


    void Start()
    {
        Cd            =  GameObject.Find("MountScript").GetComponent<ChinarDelegate>();
        Cd.callNumber += LookScreen; //2添加委托函数
        Cd.someFood   += WaitHamburger;
        temporaryText =  transform.Find("Speak/Text").GetComponent<Text>();
    }


    /// <summary>
    /// 服务员叫汉堡时，委托事件才会触发
    /// </summary>
    public bool WaitHamburger(string food)
    {
        if (food == "汉堡")
        {
            temporaryText.text = "这里，我要汉堡";
            ChinarDelegate.Move(gameObject);
            iTween.MoveTo(GameObject.Find("Hamburger(Clone)"), iTween.Hash("oncomplete", "DestroyHamburger", "oncompletetarget", gameObject,           "time",     .7f,                          "x",     -13.38, "y", 2.8f, "easetype", iTween.EaseType.easeOutCubic, "delay", 2.4f));
            iTween.ScaleTo(GameObject.Find("Hamburger(Clone)"), iTween.Hash("time",      .7f,                "scale",            new Vector3(0, 0, 0), "easetype", iTween.EaseType.easeOutCubic, "delay", 2.4f));

            StopCoroutine(ClearText());
            StartCoroutine(ClearText());
            return true;
        }
        return false;
    }


    private void DestroyHamburger()
    {
        Destroy(GameObject.Find("Hamburger(Clone)"));
    }


    /// <summary>
    /// 抬头看大屏幕
    /// </summary>
    public void LookScreen()
    {
        temporaryText.text = "顾客B看向大屏幕";
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