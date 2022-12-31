using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;
using System.Windows.Shell;

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
            this.SizeChanged += OnWindowSizeChanged;
        }
        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            double newWindowHeight = e.NewSize.Height;
            Thickness margin = ProgramButtons.Margin;
            margin.Top = newWindowHeight-166;
            ProgramButtons.Margin = margin;
        }

        private void AddFolder(System.Windows.Controls.TreeView TreeView)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            
            var result = openFolderDialog.ShowDialog();

            if (result != System.Windows.Forms.DialogResult.OK) 
            {
                System.Windows.MessageBox.Show("No Folder Selected");
            }
            else
            {
                var item = new TreeViewItem();
                item.Header = openFolderDialog.SelectedPath.ToString();
                if (!IsInTreeView(TreeView, item))
                {
                    TreeView.Items.Add(item);
                }
            }
        }

        private void AddScanningFolder(object sender, RoutedEventArgs e)
        {
            AddFolder(scanning);
        }

        // Add a Text Box Under Each Folder Added to let the user secify which file extensions should enter the folder above.
        private void AddRoutingFolder(object sender, RoutedEventArgs e)
        {
            AddFolder(routing);
        }

        public bool IsInTreeView(System.Windows.Controls.TreeView TreeView, TreeViewItem new_item)
        {
            foreach (TreeViewItem item in TreeView.Items)
            {
                if ((string)item.Header == (string)new_item.Header)
                { 
                    MessageBoxResult result = System.Windows.MessageBox.Show("Whoops, you are already "+TreeView.Name+" the folder at:  "+new_item.Header);
                    return true;
                }
            }
            return false;
        }
    }
}