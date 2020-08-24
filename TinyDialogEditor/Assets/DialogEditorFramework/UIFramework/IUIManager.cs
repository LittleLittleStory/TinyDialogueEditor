using FairyGUI;
using System.Collections.Generic;

namespace UIFramework
{
    public interface IUIManager
    {
        /// <summary>
        /// UIPage管理容器
        /// </summary>
        Dictionary<string, UIPageBase> UIPages { get; }

        /// <summary>
        /// UIComponent绑定
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void BindAll();

        /// <summary>
        /// 通过UIPageName判断对应UIPage是否存在
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        bool HasUIPage(string UIPageName);

        /// <summary>
        /// 通过Name得到对应UIPage
        /// </summary>
        bool GetUIPage(string UIPageName, out UIPageBase page);
        bool GetUIPage<T>(out UIPageBase page) where T : UIPageBase, new();

        UIPageBase GetUIPage(string UIPageName);
        T GetUIPage<T>() where T : UIPageBase, new();

        /// <summary>
        /// 通过Name得到对应UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        GComponent GetUIPageComponent(string UIPageName);
        T2 GetUIPageComponent<T, T2>() where T : UIPageBase, new() where T2 : GComponent;

        /// <summary>
        /// 创建UIPage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="UILayer"></param>
        /// <returns></returns>
        UIPageBase CreateUIPage(string UIPageName, string UIPackageName, string UIComponentName, e_UILayer UILayer = e_UILayer.Middle);
        UIPageBase CreateUIPage(string UIPageName, string UIPackageName, string UIComponentName, StUserData userData, e_UILayer UILayer = e_UILayer.Middle);

        /// <summary>
        /// 创建UIPage
        /// </summary>
        /// <typeparam name="T">Page类型</typeparam>
        /// <typeparam name="T2">你要打开的窗口名</typeparam>
        /// <param name="UIPackageName">包名</param>
        /// <param name="UILayer">层级</param>
        /// <returns></returns>
        UIPageBase CreateUIPage<T, T2>(e_UILayer UILayer = e_UILayer.Middle)
            where T : UIPageBase, new()
            where T2 : GComponent;

        UIPageBase CreateUIPage<T, T2>(StUserData UserData, e_UILayer UILayer = e_UILayer.Middle)
            where T : UIPageBase, new()
            where T2 : GComponent;

        /// <summary>
        /// 关闭指定UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        bool CloseUIPage(string UIPageName);

        /// <summary>
        /// 展示指定UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        bool ShowUIPage(string UIPageName);

        /// <summary>
        /// 隐藏指定UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        bool HideUIPage(string UIPageName);

        /// <summary>
        /// 刷新指定UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        bool RefreshUIPage(string UIPageName);

        /// <summary>
        /// 隐藏所有UIPage
        /// </summary>
        /// <param name="notExpect"></param>
        void HideAllUIPages(bool notExpect);

        /// <summary>
        /// 展示所有UIPage
        /// </summary>
        void ShowAllUIPages();

        /// <summary>
        /// 关闭所有UIPage
        /// </summary>
        /// <param name="notExpect"></param>
        void CloseAllUIPage(bool notExpect);

        /// <summary>
        /// 得到当前所有UIPage的数量
        /// </summary>
        /// <param name="notExpect"></param>
        int GetCurUIPagesCount();

        /// <summary>
        /// 通过Name指定UIPage至当前Layer最顶层
        /// </summary>
        /// <param name="notExpect"></param>
        bool SetUIPageTop(string UIPageName);

        /// <summary>
        /// 通过Name指定UIPage的Layer
        /// </summary>
        /// <param name="notExpect"></param>
        bool SetUIPageLayer(string UIPageName, e_UILayer UILayer, int index);

        /// <summary>
        /// 通过Name指定UIPage的Layer
        /// </summary>
        /// <param name="notExpect"></param>
        bool SetUIPageToLayerTop(string UIPageName, e_UILayer UILayer);
    }
}
