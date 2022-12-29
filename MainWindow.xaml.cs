using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace FileRouter
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            var result = openFolderDialog.ShowDialog();
            var folder_path = openFolderDialog.SelectedPath.ToString();

            var item = new TreeViewItem();
            item.Header = folder_path;

            if (result == System.Windows.Forms.DialogResult.OK && isScannedFolder(folder_path))
            {
                ScannedFolders.Items.Add(item);
            }
        }

        // This function should check if the folder selected is already being scanned.
        // Alert the user if the folder selected is already being scanned.
        public bool isScannedFolder(string folder_path)
        {
            return true;
        }
    }
}