using EasySave.Model;
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

        /// <summary>
        /// Initialize the parameters window (ERP blacklist and format of the files to encrypt)
        /// </summary>
        /// <param name="model"></param>
        public ParamWindow(IData data, ParamEventHandler paramEvent)
        {
            this.paramEvent = paramEvent;
            this.data = data;
            InitializeComponent();

            ErpList.Text = string.Join(";", this.data.GetErpBlacklist().ToArray());
            EncryptFormat.Text = string.Join(";", this.data.GetEncryptFormat().ToArray());
        }

        /// <summary>
        /// Event when clicking the save button of the parameters window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string[] separator = { ";" };

            string[] erp = ErpList.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] encrypt = EncryptFormat.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> parameters = new Dictionary<string, List<string>>
            {
                { "ERP blacklist",  encrypt.ToList()},
                { "Encrypt extensions", encrypt.ToList()}
            };

            paramEvent(parameters);

            this.Close();
        }
    }
}
