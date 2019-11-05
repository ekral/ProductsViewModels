using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProductsViewModels.ViewModel
{
    public class NewProductViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Command SaveCommand { get; set; }
        public Command DismissCommand { get; set; }

        public NewProductViewModel()
        {
            DismissCommand = new Command(Dismiss);
            SaveCommand = new Command(Save);
        }

        private async void Dismiss()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void Save()
        {
            Product product = new Product(Name, Price);

            MessagingCenter.Send<object, Product>(this, "AddNewProduct", product);

            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
