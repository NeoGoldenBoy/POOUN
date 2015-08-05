using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MusicStore
{
    /// <summary>
    /// Lógica de interacción para ControlArtistas.xaml
    /// </summary>
    public partial class ControlArtistas : UserControl
    {
        public ControlArtistas()
        {
            InitializeComponent();
        }

        public string Artista 
        {
            get { return Convert.ToString(lblArtista.Content); }
            set { lblArtista.Content = value; }
        }

        public string Imagen 
        {
            get { return ((BitmapImage)ImagenArtista.Source).UriSource.AbsolutePath; }
            set 
            { 
                Image finalImage = new Image();
                finalImage.Width = 128;

                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("/MusicStore/Artistas/" + value, System.UriKind.Relative);
                logo.EndInit();

                ImagenArtista.Source = logo; 
            }
        }
    }
}
