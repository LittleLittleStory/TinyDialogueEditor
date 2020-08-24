using FairyGUI;
using System;

namespace UIFramework
{
    [Flags]
    public enum e_Flag
    {

    }

    public struct StUserData
    {
        Type userType;
        object userData;

        public StUserData(Type userType, object userData)
        {
            this.userType = userType;
            this.userData = userData;
        }

        public Type UserType { get => userType; set => userType = value; }
        public object UserData { get => userData; set => userData = value; }
    }

    public interface IUIPage
    {
        /// <summary>
        /// 界面名称
        /// </summary>
        string PageName { get; }

        /// <summary>
        /// 用户自定义数据
        /// </summary>
        StUserData UserData { get; set; }

        /// <summary>
        /// UIComponent
        /// </summary>
        GComponent Component { get; }

        /// <summary>
        /// flag
        /// </summary>
        e_Flag Flag { get; }

        /// <summary>
        /// UIPage数据初始化
        /// </summary>
        void UIPageBaseInit(string pageName, GComponent component);

        void UIPageBaseInit(string pageName, GComponent component, StUserData userData);

        /// <summary>
        /// 初始化UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void InitUIPage();

        /// <summary>
        /// 打开UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void OpenUIPage();

        /// <summary>
        /// 关闭UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void CloseUIPage();

        /// <summary>
        /// 展示UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void ShowUIPage();

        /// <summary>
        /// 隐藏UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void HideUIPage();

        /// <summary>
        /// 刷新UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void RefreshUIPage();

        /// <summary>
        /// 清理UIPage
        /// </summary>
        /// <param name="UIPageName"></param>
        /// <returns></returns>
        void ClearUIPage();
    }
}
