using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;



namespace Common.Base
{
    public abstract class ViewModelBase : ObservableObject
    {
        public ViewModelBase() { }
        public ViewModelBase(IView view)
        {
            View = view;
        }
        public IView View { get; private set; }

        public virtual void Cleanup()
        {

        }
    }
    public abstract class ViewModelBase<T> : ObservableObject where T : IView
    {
        public ViewModelBase(T view)
        {
            View = view;
        }
        public T View { get; private set; }
        public virtual void Cleanup()
        {

        }
    }

}
