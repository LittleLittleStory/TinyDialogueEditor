using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFramework
{
    public interface IUIUpdate
    {
        void ChangeUpdateState();
        void Update();
    }
}
