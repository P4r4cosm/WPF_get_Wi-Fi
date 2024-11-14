using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPF_task1.Models;
using System.Collections.Specialized;
using ManagedNativeWifi;
using System.Windows.Input;
using WPF_task1.Commands;
using System.Windows;
using System.ComponentModel;
namespace WPF_task1.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Network> Networks { get; set; }
        private Network _bestNetwork;
        public Network BestNetwork
        {
            get => _bestNetwork;
            private set
            {
                _bestNetwork = value;
                OnPropertyChanged(nameof(BestNetwork));
            }
        }
        public ICommand ScanCommand { get; }
        public ICommand SaveCommand { get; }

        public MainViewModel()
        {
            Networks = new ObservableCollection<Network>();
            ScanCommand = new RelayCommand(ScanNetworks);
            SaveCommand = new RelayCommand(SaveNetworks);
        }
        private async Task ScanNetworks()
        {

            if (NativeWifi.EnumerateInterfaces().Count() > 0)
            {
                Networks.Clear();
                
                foreach (var network in NativeWifi.EnumerateAvailableNetworks().ToList())
                {
                    Networks.Add(new Network(network.Ssid.ToString(), network.SignalQuality));
                }
                BestNetwork = Networks.OrderByDescending(n => n.SignalLevel).FirstOrDefault();
                OnPropertyChanged(nameof(BestNetwork));
            }
            else
            {
                MessageBox.Show("Нет доступных WI-FI интерфейсов");
            }

        }


        private async Task SaveNetworks()
        {
            if (Networks.Count > 0)
            {
                using (WifiDbContext db = new WifiDbContext())
                {
                    await db.AddRangeAsync(Networks);
                    await db.SaveChangesAsync();
                    MessageBox.Show("Сохранено");
                }

            }
            else
            {
                MessageBox.Show("Список сетей пуст, сохранять нечего: ");
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
