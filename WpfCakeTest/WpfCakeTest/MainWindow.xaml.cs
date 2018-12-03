using Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCakeTest.ViewModel;

namespace WpfCakeTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        //DrawingAttributes drawingAttributes;
        public MainWindow()
        {

            InitializeComponent();
            DataContext = new MainWindowViewModel();// new ToolViewModel();
            //foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)//循环添加所有字体样式
            //{
            //    cobFF.Items.Add(fontFamily.Source);
            //}
            //drawingAttributes = new DrawingAttributes();
            //canvas.DefaultDrawingAttributes = drawingAttributes;//捕获画笔的信息
            //drawingAttributes.Width = 20;
            //drawingAttributes.Height = 20;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ColorGallery_SelectedColorChanged(object sender, RoutedEventArgs e)//改变画笔颜色
        {
            canvas.DefaultDrawingAttributes.Color = colorGallery.SelectedColor ?? Colors.Black;
            foreach (Stroke item in canvas.GetSelectedStrokes())
            {
                item.DrawingAttributes.Color = colorGallery.SelectedColor ?? Colors.Black;
            }
        }

        private void EraserButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void ArrowButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.None;

        }

        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.Ink;
        }


        private void ink_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta < 0)
            {
                foreach (Stroke stroke in canvas.Strokes)
                {
                    Matrix matrix = new Matrix();
                    //缩小     小于1为缩小(最好不要为负数),大于1为放大,此为缩小0.8倍
                    matrix.ScaleAt(0.8, 0.8, Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y);
                    //X轴移动  正数为右,负数为左,此为右移1.2倍   斜着移动设置两个值
                    matrix.Translate(1.2, 0);
                    stroke.Transform(matrix, false);
                }
            }
            else
            {
                foreach (Stroke stroke in canvas.Strokes)
                {
                    Matrix matrix = new Matrix();
                    //放大     此为放大1.25倍
                    matrix.ScaleAt(1.25, 1.25, Mouse.GetPosition(canvas).X, Mouse.GetPosition(canvas).Y);
                    //Y轴移动 此为左移1.2倍
                    matrix.Translate(0, 1.2);
                    stroke.Transform(matrix, false);
                }
            }
        }

        private void InRibbonGallery_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
