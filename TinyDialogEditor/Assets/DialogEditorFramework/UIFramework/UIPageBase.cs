using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFramework
{
    public class UIPageBase : IUIPage
    {
        private string _pageName;
        private StUserData _userData;
        private GComponent _component;
        private e_Flag _flag;

        public UIPageBase()
        {

        }

        public UIPageBase(string pageName, GComponent component)
        {
            _pageName = pageName;
            _component = component;
        }

        public UIPageBase(string pageName, GComponent component, StUserData userData)
        {
            _pageName = pageName;
            _component = component;
            _userData = userData;
        }

        public string PageName
        {
            get
            {
                return _pageName;
            }
        }

        public StUserData UserData
        {
            get
            {
                return _userData;
            }
            set
            {
                _userData = value;
            }
        }


        public GComponent Component
        {
            get
            {
                return _component;
            }
        }

        public e_Flag Flag
        {
            get
            {
                return _flag;
            }
        }

        public void UIPageBaseInit(string pageName, GComponent component)
        {
            _pageName = pageName;
            _component = component;
            InitUIPage();
        }

        public void UIPageBaseInit(string pageName, GComponent component, StUserData userData )
        {
            _pageName = pageName;
            _component = component;
            _userData = userData;
            InitUIPage();
        }

        public virtual void InitUIPage() { }

        public virtual void OpenUIPage() { }

        public virtual void CloseUIPage()
        {
            _component.Dispose();
            if (SingletonManager.GetSingleton<UIManager>().UIPages.ContainsKey(_pageName))
            {
                SingletonManager.GetSingleton<UIManager>().UIPages.Remove(_pageName);
            }
            ClearUIPage();
        }

        public virtual void ShowUIPage()
        {
            _component.visible = true;
        }

        public virtual void HideUIPage()
        {
            _component.visible = false;
        }

        public virtual void RefreshUIPage() { }

        public virtual void ClearUIPage() { }
    }
}
