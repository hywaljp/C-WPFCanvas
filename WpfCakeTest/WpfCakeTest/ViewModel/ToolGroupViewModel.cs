using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfCakeTest.Model;

namespace WpfCakeTest.ViewModel
{
    class ToolGroupViewModel:ViewModelBase<ToolGroup>
    {
        public ToolGroupViewModel()
        {
        }

        public ToolGroupViewModel(ToolGroup model) : base(model)
        {
        }

        public string Name
        {
            get => Model.Name;
            set { Model.Name = value; RaisePropertyChanged(nameof(Name)); }
        }
        public Color Color
        {
            get => Model.Color;
            set { Model.Color = value; RaisePropertyChanged(nameof(Color)); }
        }
       /* public bool HasGotColor
        {
            get => Model.HasGotColor;
            set { Model.HasGotColor = value; RaisePropertyChanged(nameof(Color)); }
        }*/
    }
}
