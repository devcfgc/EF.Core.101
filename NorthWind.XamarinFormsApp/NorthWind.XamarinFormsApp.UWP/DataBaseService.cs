using System.IO;
using Xamarin.Forms;
using NorthWind.XamarinFormsApp.UWP;

[assembly: Dependency(typeof(DataBaseService))]
namespace NorthWind.XamarinFormsApp.UWP
{
    public class DataBaseService : IDataBaseService
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(
                Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                databaseFileName);
        }
    }
}