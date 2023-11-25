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
    /// Логика взаимодействия для WindowService.xaml
    /// </summary>
    public partial class WindowService : Window
    {
        public WindowService()
        {
            InitializeComponent();
            dgService.ItemsSource = App.DB.Service.ToList();
        }

        private void btnEditService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Service service = dgService.SelectedItem as Service;
                Windows.WindowAddEditService wa = new WindowAddEditService(service);
                wa.ShowDialog();
                dgService.ItemsSource = null;
                dgService.ItemsSource = App.DB.Service.ToList();
            }
            catch
            {

            }
            
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            Windows.WindowAddEditService wa = new WindowAddEditService(new Service());
            wa.ShowDialog();
            dgService.ItemsSource = null;
            dgService.ItemsSource = App.DB.Service.ToList();
        }

        private void btnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            Service service = dgService.SelectedItem as Service;
            App.DB.Service.Remove(service);
            App.DB.SaveChanges();
            dgService.ItemsSource = null;
            dgService.ItemsSource = App.DB.Service.ToList();
        }

        private void tbServiceSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string serviceSearch = tbServiceSearch.Text;
                List<Service> services = App.DB.Service.Where(service => service.Title.Contains(serviceSearch) ||
                service.Description.Contains(serviceSearch) ||
                service.MainImagePath.Contains(serviceSearch) ||
                service.Cost.ToString().Contains(serviceSearch) ||
                service.DurationInSeconds.ToString().Contains(serviceSearch) ||
                service.Discount.ToString().Contains(serviceSearch)).ToList();

                dgService.ItemsSource = null;
                dgService.ItemsSource = services;
            }
            catch { }

        }

        private void cmbServiceSorteed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int ind = cmbServiceSorteed.SelectedIndex;
                List<Service> services = App.DB.Service.ToList();
                if (ind == 0)
                    services = App.DB.Service.OrderBy(service => service.Cost).ToList();
                if (ind == 1)
                    services = App.DB.Service.OrderByDescending(product => product.Cost).ToList();
                dgService.ItemsSource = null;
                dgService.ItemsSource = services;
            }
            catch { }
        }
    }
}
