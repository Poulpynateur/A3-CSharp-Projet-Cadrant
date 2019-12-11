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

namespace EasySave.View.Composants
{
    /// <summary>
    /// Logique d'interaction pour ParamContexteWindow.xaml
    /// </summary>
    public partial class ParamContexteWindow : Window
    {
        public delegate void ResultParam(List<string> param);

        private ResultParam result;
        private List<string> paramList;

        public ParamContexteWindow(List<string> parameters, ResultParam result)
        {
            this.result = result;
            paramList = parameters;
            InitializeComponent();

            RefreshParam();
        }
        private void RefreshParam()
        {
            ParamList.Children.Clear();
            foreach (var param in paramList)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = param
                };
                ParamList.Children.Add(checkBox);
            }
            result(paramList);
        }

        public List<string> GetParamList()
        {
            var list = ParamList.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);

            foreach (var param in list)
            {
                paramList.Add(param.Content.ToString());
            }
            return paramList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            paramList.Add(ParamInput.Text);
            ParamInput.Text = "";
            RefreshParam();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var list = ParamList.Children.OfType<CheckBox>().Where(x => x.IsChecked == true);

            foreach (var delete in list)
            {
                string test = delete.Content.ToString();
                paramList.RemoveAll(param => param.Equals(delete.Content.ToString()));
            }

            RefreshParam();
        }
    }
}
