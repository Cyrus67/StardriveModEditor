using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace StardriveModEditor.CustomWindowControls
{
    public static class WindowDragBehavior
    {
        public static Window GetLeftMouseButtonDrag(DependencyObject obj)
        {
            return (Window)obj.GetValue(LeftMouseButtonDrag);
        }

        public static void SetLeftMouseButtonDrag(DependencyObject obj, Window window)
        {
            obj.SetValue(LeftMouseButtonDrag, window);
        }

        public static readonly DependencyProperty LeftMouseButtonDrag = DependencyProperty.RegisterAttached("LeftMouseButtonDrag",          
            typeof(Window), typeof(WindowDragBehavior),
            new UIPropertyMetadata(null, OnLeftMouseButtonDragChanged));

        private static void OnLeftMouseButtonDragChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as UIElement;

            if (element != null)
            {         
                element.MouseLeftButtonDown += buttonDown;
                
            }
        }        

        private static void buttonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var element = sender as UIElement;

            var targetWindow = element.GetValue(LeftMouseButtonDrag) as Window;

            if (targetWindow != null)
            {
                //Added this to un-maximize on drag.
                if (targetWindow.WindowState == WindowState.Maximized)
                {
                    //targetWindow.Left = element.mouse
                    //All this to snap the window to the mouse cursor when it's moved.
                    //This gets the mouse position in proper coordinates.
                    Matrix transform = PresentationSource.FromVisual(targetWindow).CompositionTarget.TransformFromDevice;
                    System.Windows.Point mousePosition = transform.Transform(GetMousePosition());
                    Console.WriteLine("Mouse Location: " + mousePosition.ToString());

                    //Get the percentage of the window to move the cursor to.
                    double screenWidth = targetWindow.ActualWidth;//SystemParameters.PrimaryScreenWidth;
                    double screenHeight = targetWindow.ActualHeight;//SystemParameters.PrimaryScreenHeight;
                    double relativeXPercent = screenWidth / mousePosition.X;
                    double relativeYPercent = screenHeight / mousePosition.Y;
                    Console.WriteLine("Relative Mouse X Percentage = " + relativeXPercent.ToString());
                    Console.WriteLine("Relative Mouse Y Percentage = " + relativeYPercent.ToString());

                    //Set window to normal mode
                    targetWindow.WindowState = WindowState.Normal;

                    //Move the window to the cursor.
                    targetWindow.Left = mousePosition.X - (targetWindow.Width / relativeXPercent);
                    targetWindow.Top = mousePosition.Y - (targetWindow.Height / relativeYPercent);
                }
                targetWindow.DragMove();
            }
        }

        private static System.Windows.Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }
    }
}
