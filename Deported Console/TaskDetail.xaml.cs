using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Deported_Console.MainPage;

// Pour en savoir plus sur le modèle d'élément Contrôle utilisateur, consultez la page https://go.microsoft.com/fwlink/?LinkId=234236

namespace Deported_Console
{
    public sealed partial class TaskDetail : UserControl
    {
        RemoveDetail removeDetail;
        public string TaskName { get; private set; }

        public TaskDetail(string tname, string fname, int progress, RemoveDetail removeDetail)
        {
            this.removeDetail = removeDetail;
            TaskName = tname;
            this.InitializeComponent();
            this.tname.Text = tname;
            Refresh(fname, progress);
        }

        public void Refresh(string fname, int progress)
        {
            this.fname.Text = fname;
            this.progress.Value = progress;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            removeDetail(this);
        }
    }
}
