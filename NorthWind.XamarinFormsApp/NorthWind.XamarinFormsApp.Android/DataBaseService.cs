using NorthWind.XamarinFormsApp.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DataBaseService))]
namespace NorthWind.XamarinFormsApp.Droid
{

    public class DataBaseService : IDataBaseService
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    databaseFileName
                   );
        }
    }
}