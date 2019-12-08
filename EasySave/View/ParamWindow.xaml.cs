using EasySave.Model;
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
using System.Windows.Shapes;

namespace EasySave.View
{
    /// <summary>
    /// Logique d'interaction pour Param.xaml
    /// </summary>
    public partial class ParamWindow : Window
    {
        private IModel model;

        public ParamWindow(IModel model)
        {
            this.model = model;
            InitializeComponent();
          
            ErpList.Text = String.Join(";", model.GetErpBlacklist().ToArray());
            EncryptFormat.Text = String.Join(";", model.GetEncryptFormat().ToArray());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string[] separator = { ";" };

            string[] erp = ErpList.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] encrypt = EncryptFormat.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            model.SetEncryptFormat(encrypt.ToList());
            model.SetErpBlacklist(erp.ToList());

            this.Close();
        }
    }
}
