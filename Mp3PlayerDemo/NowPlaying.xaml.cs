using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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

namespace Mp3PlayerDemo
{
    public partial class NowPlaying : UserControl
    {
        public NowPlaying()
        {
            InitializeComponent();
        }

        public void UpdateSongInfo(string title, string album, int year)
        {
            
            songTitleTextBlock.Text = title;            
            songAlbumTextBlock.Text = album;
            songYearTextBlock.Text = year.ToString();
        }
    }
}
