using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

namespace Travel_agency_project
{
    /// <summary>
    /// Interaction logic for Travel_agency_idk_mainwindow.xaml
    /// </summary>
    public partial class Travel_agency_idk_mainwindow : Window
    {
        string tokenSaver;

        ServerConnection sc = new ServerConnection();

        public Travel_agency_idk_mainwindow(string token)
        {
            InitializeComponent();
            tokenSaver = token;
        }

        private async void btnGetProfile_Click(object sender, RoutedEventArgs e)
        {
            string adat = await sc.GetProfileDataAsync(tokenSaver);


            if (adat.StartsWith("Hiba"))
            {
                MessageBox.Show(adat);
                return;
            }

            try
            {
                var profil = JsonConvert.DeserializeObject<JsonResponse>(adat);
                if (profil != null)
                {
                    MessageBox.Show(profil.username + " , " + profil.password);
                    nameTB.Text = profil.username;
                    passwordTB.Text = profil.password;
                }
                else
                {
                    MessageBox.Show("sikertelen");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("hiba:" + err.Message);
            }


        }
    }
}
