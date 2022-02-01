using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matrix_calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[,]? matrix1;
        private int[,]? matrix2;
        private int col1, col2;
        private int row1, row2;
        private void Load()
        {

            string[] linesMatrix1 = Matrix1.Text.Split("\n");
            string[] linesMatrix2 = Matrix2.Text.Split("\n");
            row1 = linesMatrix1.Length;
            col1 = linesMatrix1[0].Split(' ').Length;
            row2 = linesMatrix2.Length;
            col2 = linesMatrix2[0].Split(' ').Length;
            if(col1 != 0 && row1 != 0 && col2 != 0 && row2 != 0)
            {
                matrix1 = new int[row1, col1];
                matrix2 = new int[row2, col2];
                for (int i = 0; i < row1; i++)
                {
                    string[] data = linesMatrix1[i].Split(' ');
                    for (int j = 0; j < col1; j++)
                    {
                        if (Int32.TryParse(data[j], out int num))
                            matrix1[i, j] = num;
                        else
                        {
                            MessageBox.Show("Failed while parsing matrix from textbox");
                            break;
                        }
                       
                    }
                        
                }
                for(int i = 0; i < row2; i++)
                {
                    string[] data = linesMatrix2[i].Split(' ');
                    for(int j = 0; j < col2; j++)
                    {
                        if(Int32.TryParse(data[j], out int num))
                            matrix2[i,j] = num;
                        else
                        {
                            MessageBox.Show("Failed while parsing matrix from textbox");
                            break;
                        }    
                    }
                }    
            }
            else
            {
                MessageBox.Show("Matrix cannot have size 0");
            }
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            Load();
            string output = "";
            for (int i = 0; i < row1; i++)
            {
                if (matrix1 != null && matrix2 != null)
                {
                    for (int j = 0; j < col1; j++)
                    {

                        output += String.Format("{0} ", matrix1[i, j] + matrix2[i, j]);

                    }
                    output += "\n";
                }
                else
                {
                    MessageBox.Show("Wrong Values");
                    break;
                }

            }
            Score.Text = output;
        }

        private void Sub(object sender, RoutedEventArgs e)
        {
            Load();
            string output = "";
            for (int i = 0; i < row1; i++)
            {
                if (matrix1 != null && matrix2 != null)
                {
                    for (int j = 0; j < col1; j++)
                    {

                        output += String.Format("{0} ", matrix1[i, j] - matrix2[i, j]);

                    }
                    output += "\n";
                }
                else
                {
                    MessageBox.Show("Wrong Values");
                    break;
                }

            }
            Score.Text = output;
        }
        private void Mul(object sender, RoutedEventArgs e)
        {
            Load();
            int[,] data = new int[row1, col1];
            string output = "";
            if (matrix1 != null && matrix2 != null)
            {
                
                for(int i = 0; i< row1; ++i)
                    for(int j = 0;j< col2; ++j)
                        for(int k = 0; k < col1; ++k)
                            data[i, j] += matrix1[i, k] * matrix2[k,j];

                for(int i = 0; i < row1; ++i)
                {
                    for (int j = 0; j < col2; ++j)
                        output += String.Format("{0} ", data[i, j]);
                    output += "\n";
                }
                Score.Text = output;
            }
        }
    }
}
