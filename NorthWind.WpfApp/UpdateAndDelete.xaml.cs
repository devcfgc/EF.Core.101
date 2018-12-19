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
using NorthWind.DAL;
using NorthWind.Entities;

namespace NorthWind.WpfApp
{
    /// <summary>
    /// Interaction logic for UpdateAndDelete.xaml
    /// </summary>
    public partial class UpdateAndDelete : Window
    {
        private NorthWindContext _context;
        private Category _category;
        public UpdateAndDelete(Category category, NorthWindContext context)
        {
            InitializeComponent();
            _context = context;
            _category = category;

            TxtCategoryID.Text = category.CategoryId.ToString();
            TxtCategoryName.Text = category.CategoryName;
        }

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            _category.CategoryName = TxtCategoryName.Text;
            _context.Categories.Update(_category);
            var recordsAffected = _context.SaveChanges();
            if (recordsAffected > 0)
            {
                MessageBox.Show("Info: Data was updated");
            }
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            _context.Categories.Remove(_category);
            var recordsAffected = _context.SaveChanges();
            if (recordsAffected > 0)
            {
                MessageBox.Show("Info: Data was deleted");
            }
        }
    }
}
