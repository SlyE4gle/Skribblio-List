using System;
using System.Windows;

namespace Skribblio_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DeDupe_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string file = this.wordList_box.Text.Trim(new char[] { ' ', '"' });

                int duplicates = DeDupeFile.RemoveDuplicatesFromAndWriteOutToFile(file);

                PopSuccessMessageBox(duplicates);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private static void PopSuccessMessageBox(int duplicates)
        {
            if (duplicates == 0)
            {
                MessageBox.Show("0 duplicates found.", "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(String.Format("{0} duplicates removed.", duplicates),
                "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
