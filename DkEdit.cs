using System;
using System.Windows;
using System.Windows.Forms;
using Deka;

namespace Deka
{
    class Program
    {
         [STAThread]
         static void Main()
         {
             Application.EnableVisualStyles();
             Application.Run(new MainForm());
         }
    }
}