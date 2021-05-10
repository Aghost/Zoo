using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFGridUtils
{
    public class CreateGridObjects
    {
        public static void CreateGrid(Grid grid, int height, int width, int rows, int cols)
        {
            grid.MaxHeight = height;
            grid.MaxWidth = width;

            grid.ShowGridLines = true;
            grid.VerticalAlignment = VerticalAlignment.Center;
            grid.HorizontalAlignment = HorizontalAlignment.Center;

            for(int i = 0; i < rows; i++)
                AddRow(grid, height / rows);
            for (int i = 0; i < cols; i++)
                AddColumn(grid, width / cols);
        }

        private static void AddRow(Grid grid, int len) {
            RowDefinition gridRow = new RowDefinition();
            gridRow.Height = new GridLength(len);
            grid.RowDefinitions.Add(gridRow);
        }
        private static void AddColumn(Grid grid, int len)
        {
            ColumnDefinition gridCol = new ColumnDefinition();
            gridCol.Width = new GridLength(len);
            grid.ColumnDefinitions.Add(gridCol);
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
