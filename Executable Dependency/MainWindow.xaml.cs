using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Executable_Dependency
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Listener(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            String ProcessName = null;
            ProcessModuleCollection myProcessModuleCollection = null;
            ProcessInformation obj = null;

            ProcessName = ProcessTextBox.Text;

            ProcessTextBox.Text = "";
            listbox.Items.Clear();


            obj = new ProcessInformation(ProcessName);


            switch (btn.Uid)
            {

                case "get info":
                    try
                    {
                        myProcessModuleCollection = obj.GetProcessInfo();
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                        return;
                    }

                    foreach (ProcessModule p in myProcessModuleCollection)
                    {
                        listbox.Items.Add(p.ModuleName);
                    }
                        break;

                case "reset":

                    ProcessTextBox.Text = "";
                    listbox.Items.Clear();

                    break;
            }
         

        }
    }
}
