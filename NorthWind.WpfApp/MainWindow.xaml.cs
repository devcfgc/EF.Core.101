using System.Linq;
using NorthWind.DAL;
using System.Windows;
using NorthWind.Entities;

namespace NorthWind.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NorthWindContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new NorthWindContext();
            LoadCategories();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            var newCategory = new Category()
            {
                CategoryName = TxtCategoryName.Text
            };
            _context.Categories.Add(newCategory);
            var recordsAffected = _context.SaveChanges();

            if (recordsAffected == 0)
            {
                MessageBox.Show("Error: Data was not saved");
            }
            LoadCategories();
        }

        void LoadCategories()
        {
            DGCategories.ItemsSource = _context.Categories.ToList();
        }
    }
}
