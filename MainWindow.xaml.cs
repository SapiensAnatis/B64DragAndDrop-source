using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace B64Window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeCursor(object sender, DragEventArgs e)
        {
            DisplayArea.Cursor = Cursors.Cross;
        }

        private void AnalyzeDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (FileList.Length == 1)
            {
                string output = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(FileList[0]));
                if (imgCB.IsChecked ?? true)
                {
                    OTB.Text = "Image.Create(AssetLocation.Base64, \"" + output + "\")";
                }
                else
                {
                    OTB.Text = output;
                }
            }
        }

        private void ChangeCursorBack(object sender, DragEventArgs e)
        {
            DisplayArea.Cursor = Cursors.Wait;

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clipboard.SetText(OTB.Text);
            }
            catch
            {
                // nothing
            }
        }
    }
}
