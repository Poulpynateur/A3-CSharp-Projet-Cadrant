using EasySave.Model;
using EasySave.View.Composants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace EasySave.View
{
    /// <summary>
    /// Logique d'interaction pour Param.xaml
    /// </summary>
    public partial class ParamWindow : Window
    {
        private IData data;
        private ParamEventHandler paramEvent;

        private List<string> erpBlacklist;
        private List<string> encryptExtension;
        /// <summary>
        /// Initialize the parameters window (ERP blacklist and format of the files to encrypt)
        /// </summary>
        /// <param name="model"></param>
        public ParamWindow(IData data, ParamEventHandler paramEvent)
        {
            this.paramEvent = paramEvent;
            this.data = data;
            InitializeComponent();

            erpBlacklist = this.data.GetErpBlacklist();
            encryptExtension = this.data.GetEncryptFormat();

            foreach (var item in data.GetLang().LangChoice)
            {
                LangChoice.Items.Add(new ComboBoxItem
                {
                    Content = item,
                    IsSelected = (item == data.GetLang().LangActual)? true : false
                });
            }
        }

        /// <summary>
        /// Event when clicking the save button of the parameters window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            paramEvent(new Dictionary<string, List<string>>
                {
                    {"ERP blacklist", erpBlacklist },
                    {"Encrypt extensions", encryptExtension },
                    {"Language", new List<string> {
                        LangChoice.Text
                    }}
                });
            this.Close();
        }

        private void EncryptFileModify_Click(object sender, RoutedEventArgs e)
        {
            ParamContexteWindow param = new ParamContexteWindow(encryptExtension, (result)=>
            {
                encryptExtension = result;
            });
            param.ShowDialog();
        }

        private void ErpBlacklistModify_Click(object sender, RoutedEventArgs e)
        {
            ParamContexteWindow param = new ParamContexteWindow(erpBlacklist, (result) =>
            {
                BtnSave.IsEnabled = true;
                erpBlacklist = result;
            });
            param.ShowDialog();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
