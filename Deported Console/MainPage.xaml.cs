using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Deported_Console
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public delegate void RemoveDetail(TaskDetail task);
        private List<TaskDetail> taskDetails;

        private string IP;
        private string port;

        public MainPage()
        {
            ApplicationView.PreferredLaunchViewSize = new Size(800, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            port = "50000";
            taskDetails = new List<TaskDetail>();
            this.InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            IP = IpServer.Text;
            TaskInfoWrapper.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Collapsed;

            this.ListenToSocket();
        }

        private void DataProcess(string[] data)
        {
            int ratio = Convert.ToInt32(data[0]);
            string name = data[1];
            string file = data[2];

            TaskDetail taskDetail = taskDetails.Find(x => x.TaskName == name);
            if (taskDetail == null)
            {
                RemoveDetail removeDetail = new RemoveDetail((task) => {
                    taskDetails.Remove(task);
                    TaskInfoWrapper.Children.Remove(task);
                });
                TaskDetail Detail = new TaskDetail(name, file, ratio, removeDetail);

                taskDetails.Add(Detail);
                TaskInfoWrapper.Children.Add(Detail);
            }
            else
                taskDetail.Refresh(file, ratio);
        }

        private async void ListenToSocket()
        {
            try
            {
                using (var streamSocket = new Windows.Networking.Sockets.StreamSocket())
                {
                    var hostName = new Windows.Networking.HostName(IP);
                    await streamSocket.ConnectAsync(hostName, port);


                    string response;
                    using (Stream inputStream = streamSocket.InputStream.AsStreamForRead())
                    {
                        using (StreamReader streamReader = new StreamReader(inputStream))
                        {
                            while(true)
                            {
                                response = await streamReader.ReadLineAsync();

                                string[] separators = { ";" };
                                DataProcess(response.Split(separators, StringSplitOptions.RemoveEmptyEntries));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                await dialog.ShowAsync();

                TaskInfoWrapper.Visibility = Visibility.Collapsed;
                Login.Visibility = Visibility.Visible;
            }
        }
    }

}
