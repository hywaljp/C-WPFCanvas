using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfCakeTest.Model
{
    public class Tool
    {

        public DrawingAttributes DrawingAttributes { get; set; } = new DrawingAttributes();//
        public string Name { get; set; } = "Tool";
        public object LargeIcon { get; set; } = null;
        public bool HasColor { get; set; } = true;
        public Cursor Cursor { get; set; } = Cursors.Pen;
        public bool IsDisplayed { get; set; } = true;
        public InkCanvasEditingMode Mode { get; set; } = InkCanvasEditingMode.Ink;
        public ToolGroup Group { get; set; } = new ToolGroup();//
        public Tool()
        {
            DrawingAttributes.FitToCurve = true;//
            DrawingAttributes.Color = Group.Color;
        }

    }
    public abstract class StrokeTool : Tool
    {
        public abstract Type StrokeType { get; }
        public abstract void DynamicRendererDraw(DrawingContext drawingContext, StylusPointCollection stylusPoints, Geometry geometry, Brush fillBrush);
    }
}
