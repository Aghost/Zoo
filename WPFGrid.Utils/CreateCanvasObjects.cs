using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFGridUtils
{
    public class CreateCanvasObjects
    {
        public static void CreateCanvas2DGrid(Canvas canvas, int height, int width, int rows, int cols) {
            int squareHeight = height / rows;
            int squareWidth = width / cols;

            SolidColorBrush solidColorPrimary = new SolidColorBrush(Colors.Red);
            SolidColorBrush solidColorSecondary = new SolidColorBrush(Colors.Blue);
            SolidColorBrush solidColorTertiary = new SolidColorBrush(Colors.Yellow);

            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = squareWidth;
                    rectangle.Height = squareHeight;
                    
                    // voor fun
                    rectangle.Fill = i % 2 == 0 ? j % 2 == 0 ? solidColorPrimary : solidColorTertiary : j % 2 != 0 ? solidColorSecondary : solidColorTertiary;

                    Canvas.SetTop(rectangle, squareHeight * i);
                    Canvas.SetLeft(rectangle, squareWidth * j);

                    canvas.Children.Add(rectangle);
                }
            }
        }

        public static void CreateCanvas(Canvas canvas) {
            int object_width = 80;
            int object_height = 30;

            Label[] labels = new Label[] {
                CreateLabel("name", "Name: ", object_width, object_height),
                CreateLabel("pw", "Password: ", object_width, object_height),
            };

            TextBox[] textBoxes = new TextBox[] {
                CreateTextBox("name", object_width, object_height),
                CreateTextBox("pw", object_width, object_height),
            };

            int x = 0;
            int y = 0;

            for (int i = 0; i < labels.Length; i++) {
                // Add label to canvas
                Canvas.SetTop(labels[i], y);
                canvas.Children.Add(labels[i]);

                // Add textbox 100 pixels right of label, to canvas
                Canvas.SetTop(textBoxes[i], y);
                Canvas.SetLeft(textBoxes[i], x + 100);
                canvas.Children.Add(textBoxes[i]);

                // Increment 35 px on y axis
                y += 40;
            }
        }


        private static Label CreateLabel(string name, string content, int width, int height)
        {
            Label label = new Label()
            {
                Name = $"Lbl_{name}",
                Content = content,
                Width = width,
                Height = height,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return label;
        }

        // Creates a textbox and adds it to expTextBoxes Array
        private static TextBox CreateTextBox(string name, int width, int height)
        {
            TextBox textbox = new TextBox()
            {
                Name = $"Tb_{name}",
                Width = width,
                Height = height,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };

            return textbox;
        }
    }
}
