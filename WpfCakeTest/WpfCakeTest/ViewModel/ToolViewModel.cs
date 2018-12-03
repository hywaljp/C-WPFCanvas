using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using WpfCakeTest.Model;

namespace WpfCakeTest.ViewModel
{
    class ToolViewModel:ViewModelBase<Tool>
    {

        public ToolViewModel()
        {
        }
        public ToolViewModel(Tool model) : base(model)
        {
            Initialize();
            //ViewModelBase(Tool model);
            model.DrawingAttributes.FitToCurve = true;
        }
        public ToolViewModel(Tool model, Uri icon) : this(model)
        {
            //ToolViewModel a = new ToolViewModel(model);
            LargeIcon = icon;
        }
        private void Initialize()
        {
            Group = new ToolGroupViewModel(Model.Group);
            InitDrawing(DrawingAttributes);
        }
        //public bool HasColor
        //{
        //    get => Model.HasColor;
        //    set { Model.HasColor = value; OnPropertyChanged(nameof(HasColor)); }
        //}
        public string Name
        {
            get => Model.Name;
            set { Model.Name = value; RaisePropertyChanged(nameof(Name)); }
        }

        public object LargeIcon
        {
            get => Model.LargeIcon;
            set { Model.LargeIcon = value; RaisePropertyChanged(nameof(LargeIcon)); }
        }
        //public object SmallIcon
        //{
        //    get => Model.SmallIcon;
        //    set { Model.SmallIcon = value; OnPropertyChanged(nameof(SmallIcon)); }
        //}
        public InkCanvasEditingMode Mode
        {
            get => Model.Mode;
            set { Model.Mode = value; RaisePropertyChanged(nameof(Mode)); }
        }
        private ToolGroupViewModel group;
        public ToolGroupViewModel Group
        {
            get => group;
            set
            {
                if (group != null)
                {
                    group.PropertyChanged -= Group_PropertyChanged;
                }
                group = value;
                Model.Group = group.Model;
                group.PropertyChanged += Group_PropertyChanged;
                RaisePropertyChanged(nameof(Group));
                RaisePropertyChanged(nameof(GroupName));
            }
        }

        private void Group_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToolGroupViewModel.Name))
            {
                RaisePropertyChanged(nameof(GroupName));
            }
        }

        public string GroupName => Group.Name;
        public bool IsDisplayed
        {
            get => Model.IsDisplayed;
            set { Model.IsDisplayed = value; RaisePropertyChanged(nameof(IsDisplayed)); }
        }
        public Cursor Cursor
        {
            get => Model.Cursor;
            set { Model.Cursor = value; RaisePropertyChanged(nameof(Cursor)); RaisePropertyChanged(nameof(UseCursor)); }
        }
        public bool UseCursor => Cursor != null; // ah yes is
        public bool HasSize => Mode != InkCanvasEditingMode.None && Mode != InkCanvasEditingMode.Select;//？？？？
        public StylusShape EraserShape => new RectangleStylusShape(DrawingAttributes.Width, DrawingAttributes.Height);
        public DrawingAttributes DrawingAttributes
        {
            get
            {
                Model.DrawingAttributes.Color = Group.Color;
                return Model.DrawingAttributes;
            }
            set
            {
                InitDrawing(value);
            }
        }

        private void InitDrawing(DrawingAttributes value)
        {
            Model.DrawingAttributes.AttributeChanged -= ColorChangeHandler;
            Model.DrawingAttributes = value;
            // Group.Color = Model.DrawingAttributes.Color;
            Model.DrawingAttributes.AttributeChanged += ColorChangeHandler;
            RaisePropertyChanged(nameof(DrawingAttributes));
        }

        private void ColorChangeHandler(object sender, PropertyDataChangedEventArgs e)
        {
            if (e.NewValue is Color c)
            {
                group.Color = c;
            }
        }

        public double UniformSize
        {
            get => DrawingAttributes.Height;
            set
            {
                DrawingAttributes.Height = value;
                if (!DrawingAttributes.IsHighlighter)
                {
                    DrawingAttributes.Width = value;
                }
                RaisePropertyChanged(nameof(UniformSize));
                RaisePropertyChanged(nameof(EraserShape));
                // Some kind of hack to make the cursor update. dunno why microsoft didnt do gr8 xd
                UpdateCursorIfEraser(this);
            }
        }

        public static void UpdateCursorIfEraser(ToolViewModel t)
        {
            if (t.Mode == InkCanvasEditingMode.EraseByPoint || t.Mode == InkCanvasEditingMode.EraseByStroke)
            {
                InkCanvasEditingMode previous = t.Mode;
                t.Mode = InkCanvasEditingMode.None;
                t.Mode = previous;
            }
        }
    
    }
}
