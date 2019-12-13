using EasySave.Helpers;
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

namespace EasySave.View.Composants
{
    /// <summary>
    /// Logique d'interaction pour Log.xaml
    /// </summary>
    public partial class Log : UserControl
    {
        /// <summary>
        /// Change statut and text of the log
        /// </summary>
        /// <param name="statut">Statut of the log</param>
        /// <param name="text">Text of the log depending of the statut</param>
        public Log(Statut statut, string text)
        {
            InitializeComponent();
            switch (statut)
            {
                case Statut.INFO:
                    LogTextIconInfo.Visibility = Visibility.Visible;
                    LogText.Foreground = Brushes.Black;
                    break;
                case Statut.SUCCESS:
                    LogTextIconSuccess.Visibility = Visibility.Visible;
                    LogText.Foreground = Brushes.Green;
                    break;
                case Statut.ERROR:
                case Statut.WARNING:
                    LogTextIconCaution.Visibility = Visibility.Visible;
                    LogText.Foreground = Brushes.Red;
                    break;
                default:
                    break;
            }
            LogText.Text = text;
        }
    }
}
