using System.Collections;
using UnityEngine;
using UnityEngine.UI;


//委托传递的是方法/函数
public delegate void CallNumber(); //使用时，必须要声明委托对象；返回值类型，要与将要注册到委托对象中的函数，返回值类型保持一致！


public delegate int GetOuntHandler(); /*也就是：委托方法和被委托方法的类型必须保持一致*/


public delegate bool SomeFood(string food);
/*以上是委托函数的声明方式*/


/// <summary>
/// Chinar委托测试类
/// </summary>
public class ChinarDelegate : MonoBehaviour
{
    //方法是引用类型的对象
    //委托将一个函数 转换成了一个函数对象
    //可以将 这个函数 以 对象 的形式进行传递
    public CallNumber callNumber;  //定义委托对象   这里定义的是一个委托对象
    public SomeFood   someFood;    //定义一个有参数有返回值的委托
    public Text       WaiterSpeak; //服务员说话内容文本
    public Text       BigScreen;   //服务员说话内容文本

    /// <summary>
    /// 叫号方法 —— 绑定按钮
    /// </summary>
    public void OnClickCallNumber()
    {
        callNumber();
        Content(Color.red, "叫号啦！！！", "请100号顾客取餐！");
    }


    /// <summary>
    /// 汉堡包 —— 绑定按钮
    /// </summary>
    public void OnClickHamburger()
    {
        if (!GameObject.Find("Hamburger(Clone)")) Instantiate(Resources.Load("Hamburger"));
        someFood("汉堡");
        Content(UserTwo.temporaryText.color, "谁的汉堡？", "请B号顾客取餐！");
    }


    /// <summary>
    /// 可乐 —— 绑定按钮
    /// </summary>
    public void OnClickCola()
    {
        someFood("可乐");
        Content(UserTwo.temporaryText.color, "谁点的可乐？", "请C号顾客取餐！");
    }

    /// <summary>
    /// 封装内容简化代码
    /// </summary>
    /// <param name="color"></param>
    /// <param name="speak"></param>
    /// <param name="bigScreen"></param>
    private void Content(Color color, string speak, string bigScreen)
    {
        WaiterSpeak.text  = speak;
        WaiterSpeak.color = color;
        BigScreen.text    = bigScreen;
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
        WaiterSpeak.text = "";
        BigScreen.text   = "";
    }


    public static void Move(GameObject gameObject)
    {
        iTween.MoveTo(gameObject, iTween.Hash("time",                                     .7f, "x",     6.69f,                         "y",        8.6f, "easetype", iTween.EaseType.easeOutCubic));
        iTween.MoveTo(gameObject, iTween.Hash("time",                                     .7f, "x",     -13.38f,                       "y",        2.8f, "easetype", iTween.EaseType.easeOutCubic, "delay", 2.4f));
        iTween.ScaleTo(gameObject.transform.Find("Speak").gameObject, iTween.Hash("time", .7f, "scale", new Vector3(0.3f, 0.3f, 0.3f), "easetype", iTween.EaseType.easeOutCubic));
        iTween.ScaleTo(gameObject.transform.Find("Speak").gameObject, iTween.Hash("time", .7f, "scale", new Vector3(1,    1,    1),    "easetype", iTween.EaseType.easeOutCubic, "delay", 2.4f));
        iTween.ScaleTo(gameObject,                                    iTween.Hash("time", .7f, "scale", new Vector3(3,    3,    3),    "easetype", iTween.EaseType.easeOutCubic));
        iTween.ScaleTo(gameObject,                                    iTween.Hash("time", .7f, "scale", new Vector3(1,    1,    1),    "easetype", iTween.EaseType.easeOutCubic, "delay", 2.4f));
        iTween.RotateTo(gameObject, iTween.Hash("time",                                   .7f, "z",     -360.01f,                      "easetype", iTween.EaseType.easeOutCubic));
    }
}