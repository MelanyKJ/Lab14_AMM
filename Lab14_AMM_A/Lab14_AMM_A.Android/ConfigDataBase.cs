using Android.App;
using Lab14_AMM_A.Interfaces;
using System.IO;


namespace Lab14_AMM_A.Droid
{
    public class ConfigDataBase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), databaseFileName);
        }
    }
}