using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvvm
{
    class ViewModelBase : BindableBase
    {
        private static ObservableCollection<MenuItem> menu = new ObservableCollection<MenuItem>();

        public ViewModelBase()
        {}

        public bool IsInDesignMode
        {
            get { return Windows.ApplicationModel.DesignMode.DesignModeEnabled; }
        }

        public ObservableCollection<MenuItem> Menu {
            get { return menu; }
        }
    }
}
