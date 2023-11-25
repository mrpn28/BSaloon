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

namespace BSaloon.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAddEditService.xaml
    /// </summary>
    public partial class WindowAddEditService : Window
    {
        public WindowAddEditService(Service currentService)
        {
            InitializeComponent();
            try
            {
                this.currentService = currentService;
                tbName.Text = currentService.Title.ToString();
                tbCost.Text = currentService.Cost.ToString();
                tbDurationln.Text = currentService.DurationInSeconds.ToString();
                tbDescription.Text = currentService.Description.ToString();
                tbDiscount.Text = currentService.Discount.ToString();
                tbMainImagePath.Text = currentService.MainImagePath.ToString();
            }
            catch
            {

            }
        }

        Service currentService;
        private void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            currentService.Title = tbName.Text;
            currentService.Cost = decimal.Parse(tbCost.Text);
            currentService.DurationInSeconds = int.Parse(tbDurationln.Text);
            currentService.Description = tbDescription.Text;
            currentService.Discount = float.Parse(tbDiscount.Text);
            currentService.MainImagePath = tbMainImagePath.Text;
            if (currentService.ID == 0)
                App.DB.Service.Add(currentService);
            App.DB.SaveChanges();
            Close();
        }

        private void btnCancelService_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
