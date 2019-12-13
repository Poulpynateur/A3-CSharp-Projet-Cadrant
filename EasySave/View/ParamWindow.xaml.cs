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
        /// <summary>
        /// IData object
        /// </summary>
        private IData data;

        /// <summary>
        /// Multilang object
        /// </summary>
        private Multilang multilang;

        /// <summary>
        /// ParamEventHandler object
        /// </summary>
        private ParamEventHandler paramEvent;

        /// <summary>
        /// List of the blacklisted ERP
        /// </summary>
        private List<string> erpBlacklist;

        /// <summary>
        /// List of the extensions of the files to encrypt
        /// </summary>
        private List<string> encryptExtension;

        /// <summary>
        /// List of the extensions of the files to be prioritized
        /// </summary>
        private List<string> priorityExtension;

        /// <summary>
        /// Initialize the parameters window (ERP blacklist and format of the files to encrypt)
        /// </summary>
        /// <param name="model"></param>
        public ParamWindow(IData data, Multilang multilang, ParamEventHandler paramEvent)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            this.multilang = multilang;
            this.paramEvent = paramEvent;
            this.data = data;

            erpBlacklist = this.data.GetErpBlacklist();
            encryptExtension = this.data.GetEncryptExtensions();
            priorityExtension = this.data.GetPriorityExtensions();
            MaxSizeByte.Text = this.data.GetMaxFileSize().ToString();

            foreach (var item in data.GetLang().LangChoice)
            {
                LangChoice.Items.Add(new ComboBoxItem
                {
                    Content = item,
                    IsSelected = (item == data.GetLang().LangActual)? true : false
                });
            }

            ShowDialog();
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
                    {"Priority extensions", priorityExtension },
                    {"MaxFileSize" , new List<string> {
                        MaxSizeByte.Text
                    }},
                    {"Language", new List<string> {
                        LangChoice.Text
                    }}
                });
            this.Close();
        }

        /// <summary>
        /// On click, open the window to manage the extensions of the files to encrypt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EncryptFileModify_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            new ParamContexteWindow(encryptExtension, (result)=>
            {
                encryptExtension = result;
            });
            this.IsEnabled = true;
        }

        /// <summary>
        /// On click, open the window to manage the blacklisted ERP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ErpBlacklistModify_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            new ParamContexteWindow(erpBlacklist, (result) =>
            {
                erpBlacklist = result;
            });
            this.IsEnabled = true;
        }

        /// <summary>
        /// On click, close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Once the window, refresh the control texts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            multilang.RefreshControlText(this, data);
        }

        /// <summary>
        /// On click, open the window to manage the extensions of the files to be prioritized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriorityExtensionsModify_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            new ParamContexteWindow(priorityExtension, (result) =>
            {
                priorityExtension = result;
            });
            this.IsEnabled = true;
        }
    }
}
