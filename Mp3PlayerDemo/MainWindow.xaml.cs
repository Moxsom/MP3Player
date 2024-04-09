using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TagLib;
using Microsoft.VisualBasic;
using System.IO;

namespace Mp3PlayerDemo
{
    public partial class MainWindow : Window
    {
        TagLib.File currentFile;

        //Look into private DispatcherTimer _timer; this could be for the play bar*

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                currentFile = TagLib.File.Create(openFileDialog.FileName);
                myMediaPlayer.Source = new Uri(openFileDialog.FileName);
                myMediaPlayer.Play();

                //Send the DATA to nowPlayingControl

                string title = currentFile.Tag.Title ?? "Unknown Title";
                string album = currentFile.Tag.Album ?? "Unknown Album";
                int year = (int)currentFile.Tag.Year;

                nowPlayingControl.UpdateSongInfo(title, album, year);
            }
        }

        private void Media_Play(object sender, RoutedEventArgs e)
        {
            if (myMediaPlayer.Source != null)
                myMediaPlayer.Play();
        }


        private void Media_Pause(object sender, RoutedEventArgs e)
        {
            myMediaPlayer.Pause();
        }


        private void Media_Stop(object sender, RoutedEventArgs e)
        {
            myMediaPlayer.Stop();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void EditTitle_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                string newTitle = Interaction.InputBox("Enter new song title:", "Edit Title", currentFile.Tag.Title);

                myMediaPlayer.Stop();
                currentFile.Tag.Title = newTitle;
                SaveAndReloadCurrentFile();
            }
        }

        private void EditAlbum_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                string newAlbum = Interaction.InputBox("Enter new album name:", "Edit Album", currentFile.Tag.Album);

                myMediaPlayer.Stop();
                currentFile.Tag.Album = newAlbum;
                SaveAndReloadCurrentFile();
            }
        }

        private void EditYear_Click(object sender, RoutedEventArgs e)
        {
            if (currentFile != null)
            {
                string newYear = Interaction.InputBox("Enter new year:", "Edit Year", currentFile.Tag.Year.ToString());
                if (int.TryParse(newYear, out int year))
                {
                    myMediaPlayer.Stop();
                    currentFile.Tag.Year = (uint)year;
                    SaveAndReloadCurrentFile();
                }
                else
                {
                    MessageBox.Show("Invalid year.");
                }
            }
        }

        private void SaveAndReloadCurrentFile()
        {
            myMediaPlayer.Stop();
            myMediaPlayer.Source = null;

            string path = currentFile.Name;

            // Save changes to a temporary TagLib.File object to avoid conflicts - Should avoid opening the file twice, or opening files concurrently
            var tagsToSave = new
            {
                Title = currentFile.Tag.Title,
                Album = currentFile.Tag.Album,
                Year = currentFile.Tag.Year
            };

            currentFile.Dispose(); 

            try
            {
                
                System.Threading.Thread.Sleep(500); 

                using (var fileToSave = TagLib.File.Create(path))
                {
                    fileToSave.Tag.Title = tagsToSave.Title;
                    fileToSave.Tag.Album = tagsToSave.Album;
                    fileToSave.Tag.Year = tagsToSave.Year;
                    fileToSave.Save();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error saving file: {ex.Message}");
                return;
            }

            
            currentFile = TagLib.File.Create(path);
            nowPlayingControl.UpdateSongInfo(currentFile.Tag.Title, currentFile.Tag.Album, (int)currentFile.Tag.Year);
            myMediaPlayer.Source = new Uri(path);
            myMediaPlayer.Play();
        }
    }
}
