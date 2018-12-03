using Fluent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfCakeTest.Model
{
    class MainWindowModel
    {

        public ToolGroupCollection Groups { get; set; } = new ToolGroupCollection
        {
            new ToolGroup
            {
                Name = "Brushes",
                Color = Colors.Black
            },

            //new ToolGroup
            //{
            //    Name = "Highlighters",
            //    Color = Colors.Yellow
            //},
            new ToolGroup
            {
                Name = "Erasers",
                Color = Colors.Black,
                HasGotColor = false
            },
            new ToolGroup
            {
                Name = "Other",
                Color = Colors.Black
            }
        };//位置有疑问

        public ObservableCollection<Color> FavouriteColors { get; set; } = ColorGallery.RecentColors;
        public List<Tool> Tools { get; set; }
        public MainWindowModel()
        {
            Tools = new List<Tool>
            {
                new Tool
                {
                    Name = "Normal Brush",
                    Group = Groups["Brushes"],
                    LargeIcon = new Uri("D:\\source2\\repos2\\WpfCakeTest\\WpfCakeTest\\Image\\Brush.png"),
                    DrawingAttributes = new System.Windows.Ink.DrawingAttributes
                    {
                        Color = Colors.Black,
                        Height = 2,
                        Width = 2
                    },
                    Cursor = Cursors.Pen
                },

                 new Tool
                {
                    Name = "Small Eraser",
                    Group = Groups["Erasers"],
                    LargeIcon = new Uri("D:\\source2\\repos2\\WpfCakeTest\\WpfCakeTest\\Image\\Eraser.png"),
                    Mode = System.Windows.Controls.InkCanvasEditingMode.EraseByPoint,
                    DrawingAttributes = new System.Windows.Ink.DrawingAttributes
                    {
                        Width = 4,
                        Height = 4
                    },
                    Cursor = null
                },

                  new Tool
                {
                    Name = "Select",
                    Group = Groups["Other"],
                    LargeIcon = new Uri("D:\\source2\\repos2\\WpfCakeTest\\WpfCakeTest\\Image\\Select.png"),
                    Mode = System.Windows.Controls.InkCanvasEditingMode.Select,
                    IsDisplayed = false,
                    Cursor = null
                  }
                };

            FavouriteColors.Add(Colors.Black);
        }
        
    }
}
