using System;
using System.Linq;
using NorthWind.Entities;
using Xamarin.Forms;

namespace NorthWind.XamarinFormsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            using (var context = App.GetContext())
            {
                Categories.ItemsSource = context.Categories.ToList();
            }
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            using (var context = App.GetContext())
            {
                var category = new Category
                {
                    CategoryName = CategoryName.Text
                };
                context.Categories.Add(category);
                context.SaveChanges();
                Categories.ItemsSource = context.Categories.ToList();
            }
        }
    }
}
