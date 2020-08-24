using FairyGUI;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace UIFramework
{
    public enum e_UILayer
    {
        Bottom,
        Middle,
        Top
    }

    public class UIManager : Singleton<UIManager>, IUIManager
    {
        private Dictionary<string, UIPageBase> _UIPages;

        public override void Init()
        {
            BindAll();
            _UIPages = new Dictionary<string, UIPageBase>();
            GRoot.inst.SetContentScaleFactor(1920, 1080);
            foreach (int UILayer in Enum.GetValues(typeof(e_UILayer)))
            {
                string layerName = Enum.GetName(typeof(e_UILayer), UILayer);
                GComponent UIComponent = new GComponent();
                UIComponent.gameObjectName = layerName;
                GRoot.inst.AddChild(UIComponent);

                UIPageBase page = new UIPageBase(layerName, UIComponent);
                _UIPages.Add(layerName, page);
            }
        }


        public void BindAll()
        {
            //FurnitureEditor.FurnitureEditorBinder.BindAll();
        }

        public Dictionary<string, UIPageBase> UIPages
        {
            get
            {
                return _UIPages;
            }
        }


        public bool HasUIPage(string UIPageName)
        {
            return _UIPages.ContainsKey(UIPageName);
        }

        public bool GetUIPage(string UIPageName, out UIPageBase page)
        {
            _UIPages.TryGetValue(UIPageName, out page);
            return page == null ? false : true;
        }

        public bool GetUIPage<T>(out UIPageBase page) where T : UIPageBase, new()
        {
            _UIPages.TryGetValue(typeof(T).ToString(), out page);
            return page == null ? false : true;
        }

        public UIPageBase GetUIPage(string UIPageName)
        {
            UIPageBase page = new UIPageBase();
            _UIPages.TryGetValue(UIPageName, out page);
            return page;
        }

        public T GetUIPage<T>() where T : UIPageBase, new()
        {
            UIPageBase page = new UIPageBase();
            _UIPages.TryGetValue(typeof(T).ToString(), out page);
            return (T)page;
        }

        public GComponent GetUIPageComponent(string UIPageName)
        {
            UIPageBase page = new UIPageBase();
            if (GetUIPage(UIPageName, out page))
            {
                return page.Component;
            }
            return null;
        }


        public T2 GetUIPageComponent<T, T2>()
            where T : UIPageBase, new()
            where T2 : GComponent
        {
            UIPageBase page = new UIPageBase();
            if (GetUIPage(typeof(T).ToString(), out page))
            {
                return (T2)page.Component;
            }
            return null;
        }

        public int GetCurUIPagesCount()
        {
            return _UIPages.Count;
        }

        public UIPageBase CreateUIPage(string UIPageName, string UIPackageName, string UIComponentName, e_UILayer UILayer = e_UILayer.Middle)
        {
            UIPageBase page;
            if (!GetUIPage(UIPageName, out page))
            {
                AddUIPackage(string.Format("FGUI/{0}", UIPackageName));
                GComponent UIComponent;
                try
                {
                    UIComponent = (GComponent)UIPackage.CreateObject(UIPackageName, UIComponentName);
                }
                catch (Exception)
                {
                    throw new Exception("转换失败,你是否未进行类型绑定");
                }

                _UIPages[UILayer.ToString()].Component.AddChild(UIComponent);

                page = (UIPageBase)Assembly.GetExecutingAssembly().CreateInstance(UIPageName);
                _UIPages.Add(UIPageName, page);
                page.UIPageBaseInit(UIPageName, UIComponent);
                page.OpenUIPage();
                return page;
            }
            else
            {
                if (CloseUIPage(UIPageName))
                {
                    return CreateUIPage(UIPageName,UIPageName,UIComponentName,UILayer);
                }
                else
                {
                    return page;
                }
            }
        }

        public UIPageBase CreateUIPage(string UIPageName, string UIPackageName, string UIComponentName, StUserData userData, e_UILayer UILayer = e_UILayer.Middle)
        {
            UIPageBase page;
            if (!GetUIPage(UIPageName, out page))
            {
                AddUIPackage(string.Format("FGUI/{0}", UIPackageName));
                GComponent UIComponent;
                try
                {
                    UIComponent = (GComponent)UIPackage.CreateObject(UIPackageName, UIComponentName);
                }
                catch (Exception)
                {
                    throw new Exception("转换失败,你是否未进行类型绑定");
                }

                _UIPages[UILayer.ToString()].Component.AddChild(UIComponent);

                page = (UIPageBase)Assembly.GetExecutingAssembly().CreateInstance(UIPageName);
                _UIPages.Add(UIPageName, page);
                page.UIPageBaseInit(UIPageName, UIComponent, userData);
                page.OpenUIPage();
                return page;
            }
            else
            {
                if (CloseUIPage(UIPageName))
                {
                    return CreateUIPage(UIPageName, UIPackageName, UIComponentName, userData, UILayer);
                }
                else
                {
                    return page;
                }
            }
        }

        public UIPageBase CreateUIPage<T, T2>(e_UILayer UILayer = e_UILayer.Middle)
            where T : UIPageBase, new()
            where T2 : GComponent
        {
            UIPageBase page;
            string[] TypeName = typeof(T2).ToString().Split('.');
            string UIPackageName = TypeName[0];
            string UIComponentName = TypeName[1];
            string UIPageName = typeof(T).ToString();
            if (!GetUIPage(UIPageName, out page))
            {
                AddUIPackage(string.Format("FGUI/{0}", UIPackageName));
                GComponent UIComponent;
                try
                {
                    UIComponent = (T2)UIPackage.CreateObject(UIPackageName, UIComponentName);
                }
                catch (Exception)
                {
                    throw new Exception("转换失败,你是否未进行类型绑定");
                }

                _UIPages[UILayer.ToString()].Component.AddChild(UIComponent);

                page = new T();
                _UIPages.Add(UIPageName, page);
                page.UIPageBaseInit(UIPageName, UIComponent);
                page.OpenUIPage();
                return page;
            }
            else
            {
                if (CloseUIPage(UIPageName))
                {
                    return CreateUIPage<T, T2>(UILayer);
                }
                else
                {
                    return page;
                }
            }
        }

        public UIPageBase CreateUIPage<T, T2>(StUserData userData, e_UILayer UILayer = e_UILayer.Middle)
            where T : UIPageBase, new()
            where T2 : GComponent
        {
            UIPageBase page;
            string[] TypeName = typeof(T2).ToString().Split('.');
            string UIPackageName = TypeName[0];
            string UIComponentName = TypeName[1];
            string UIPageName = typeof(T).ToString();
            if (!GetUIPage(UIPageName, out page))
            {
                AddUIPackage(string.Format("FGUI/{0}", UIPackageName));
                GComponent UIComponent;
                try
                {
                    UIComponent = (T2)UIPackage.CreateObject(UIPackageName, UIComponentName);
                }
                catch (Exception)
                {
                    throw new Exception("转换失败,你是否未进行类型绑定");
                }

                _UIPages[UILayer.ToString()].Component.AddChild(UIComponent);

                page = new T();
                _UIPages.Add(UIPageName, page);
                page.UIPageBaseInit(UIPageName, UIComponent, userData);
                page.OpenUIPage();
                return page;
            }
            else
            {
                if (CloseUIPage(UIPageName))
                {
                    return CreateUIPage<T, T2>(userData,UILayer);
                }
                else
                {
                    return page;
                }
            }
        }

        public bool CloseUIPage(string UIPageName)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                page.CloseUIPage();
                _UIPages.Remove(UIPageName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ShowUIPage(string UIPageName)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                page.ShowUIPage();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HideUIPage(string UIPageName)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                page.HideUIPage();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RefreshUIPage(string UIPageName)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                page.RefreshUIPage();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetUIPageTop(string UIPageName)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                _UIPages[page.Component.parent.gameObjectName].Component.SetChildIndex(page.Component, _UIPages[page.Component.parent.gameObjectName].Component.numChildren - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetUIPageLayer(string UIPageName, e_UILayer UILayer, int index = 0)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                _UIPages[UILayer.ToString()].Component.AddChildAt(page.Component, index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetUIPageToLayerTop(string UIPageName, e_UILayer UILayer)
        {
            UIPageBase page;
            if (GetUIPage(UIPageName, out page))
            {
                _UIPages[UILayer.ToString()].Component.AddChildAt(page.Component, _UIPages[UILayer.ToString()].Component.numChildren - 1);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void HideAllUIPages(bool notExpect)
        {
            throw new NotImplementedException();
        }

        public void ShowAllUIPages()
        {
            throw new NotImplementedException();
        }

        public void CloseAllUIPage(bool notExpect)
        {
            throw new NotImplementedException();
        }

        //这是抽离出来的针对FGUI的AddPackages
        private void AddUIPackage(string packageName)
        {
            UIPackage.AddPackage(packageName);
        }
    }
}
