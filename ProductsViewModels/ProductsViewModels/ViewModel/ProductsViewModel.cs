using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProductsViewModels.ViewModel
{
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<Product> Products { get; set; }

        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(nameof(IsRefreshing)); } }

        public Command AddCommand { get; set; }
        public Command RefreshCommand { get; set; }

        public ProductsViewModel()
        {
            Products = new ObservableCollection<Product>()
            {
                new Product("Rohlik",2.0),
                new Product("Maslo",45),
                new Product("Sunka",25)
            };

            AddCommand = new Command(NavigateToAddProductPage);
            RefreshCommand = new Command(Refresh);

            MessagingCenter.Subscribe<object, Product>(this, "AddNewProduct", AddNewProduct);
        }


        private async void NavigateToAddProductPage()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new View.NewProductPage()));
        }

        private void AddNewProduct(object sender, Product argument)
        {
            // TODO save data asynchronously
            Products.Add(argument);
        }

        private async void Refresh()
        {
            // TODO get data asynchronously
            IsRefreshing = false;
        }
    }
}
