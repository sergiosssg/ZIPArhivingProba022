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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZIPArhivingProba022
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnDoExtract.IsEnabled = false;
            _fileOfZIPEDentry = new List<string>();
        }


        private string _ZIPfileName;
        private List<string> _fileOfZIPEDentry;

        public string ZIPfileName
        {
            get { return _ZIPfileName; }
            set { _ZIPfileName = value; }
        }



        private void btnFileChoose_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            openFileDlg.FileName = "Archives"; // Default file name
            openFileDlg.DefaultExt = ".zip"; // Default file extension
            openFileDlg.Filter = "Zip archives (.zip)|*.zip"; // Filter files by extension

            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                // Open document
                _ZIPfileName = openFileDlg.FileName;
                btnDoExtract.IsEnabled = true;
                getFilesFromZipArhive();

            }
        }

        private int getFilesFromZipArhive()
        {
            int iAmountOfZipedFiles = 0;

            using (System.IO.Compression.ZipArchive zipArchive = System.IO.Compression.ZipFile.OpenRead(_ZIPfileName))
            {

                foreach (System.IO.Compression.ZipArchiveEntry zipEntry in zipArchive.Entries)
                {

                    _fileOfZIPEDentry.Add(zipEntry.Name);


                     zipEntry.Open();


                    /*if (entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                    }*/

                }
                lstMain.ItemsSource = _fileOfZIPEDentry;
            }


            return iAmountOfZipedFiles;
        }
        


        private byte[] getBytesFromZipedFileInArhive(string sFileName)
        {
            using (System.IO.Compression.ZipArchive zipArchive = System.IO.Compression.ZipFile.OpenRead(_ZIPfileName))
            {
                System.IO.Compression.ZipArchiveEntry zipEntry = zipArchive.GetEntry(sFileName);

                if(zipEntry.Length > 0)
                {

                }
            }



            return null;
        }


    }
}

namespace ZIPArhivingDearhiving
{

}

