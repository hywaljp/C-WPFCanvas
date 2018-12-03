using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCakeTest.ViewModel
{
    public class ViewModelBase<T>: NotificationObject where T:new()
    {
        public T Model { get; set; }
        public ViewModelBase(T model)
        {
            Model = model;
        }
        public ViewModelBase()
        {
            Model = new T();
        }
        public override string ToString() => Model.ToString();
    }
}
