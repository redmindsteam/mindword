using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace MindWord.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for WVoiceWindow.xaml
    /// </summary>
    public partial class WVoiceWindow : Window
    {

        DispatcherTimer tiempo = new DispatcherTimer();

        String Faudio = "Archivos de Audio(mp3,wma,wav)|*.mp3;*.MP3;*.wma;*.wav";

        private Boolean MediaPausa = false;
        private Boolean multiselect = false;
        private String tipo_Media = "";
        private bool fullscreen = false;
        private bool repetir = false;
        private Boolean Intro = false;

        private String tipo = "";
        private bool mute = false;

        DispatcherTimer timer;
        bool isDragging;
        ListBoxItem PistaActual;
        ListBoxItem PistaAnterior;
        Brush ColorPistaActual;

        public WVoiceWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            isDragging = false;
            ColorPistaActual = Brushes.Gold;
            btPlay.Visibility = Visibility.Collapsed;

            BorderMediaControls.IsEnabled = true;

            tiempo.Tick += tiempo_Tick;
            tiempo.Interval = new TimeSpan(0, 0, 1);

            Play();

        }

        int contador = 0;
        private void tiempo_Tick(object sender, EventArgs e)
        {
            contador += 1;
            if (contador == 3)
            {
                BorderMediaControls.Visibility = Visibility.Collapsed;
                tiempo.Stop();
            }
        }

        private void CargarIntro()
        {
            mediacontrol.Source = new Uri(@"C:\Users\kamil\Desktop\Со мной.mp3", UriKind.Relative);
            mediacontrol.Play();
        }

        private void cargar(string[] selecteds)
        {
            foreach (string file in selecteds)
            {
                if (System.IO.Path.GetExtension(file) == ".mp3" ||
                     System.IO.Path.GetExtension(file) == ".MP3" ||
                     System.IO.Path.GetExtension(file) == ".mpg" ||
                     System.IO.Path.GetExtension(file) == ".MPG" ||
                     System.IO.Path.GetExtension(file) == ".wma" ||
                     System.IO.Path.GetExtension(file) == ".wav" ||
                     System.IO.Path.GetExtension(file) == ".wmv" ||
                     System.IO.Path.GetExtension(file) == ".avi" ||
                     System.IO.Path.GetExtension(file) == ".DAT")
                {
                    ListBoxItem listaitem = new ListBoxItem();
                    listaitem.Content = System.IO.Path.GetFileNameWithoutExtension(file);
                    listaitem.Tag = file;
                    lbLista.Items.Add(listaitem);
                    BorderMediaControls.IsEnabled = true;

                }
                else
                    MessageBox.Show("Tipo de Archivo No Soportado", "Informacion");
            }
            if (PistaActual == null)
            {
                lbLista.SelectedIndex = 0;
                PlayoPausa();
            }

        }

        private void TipoMedia()
        {
            if (tipo_Media == ".mp3" || tipo_Media == ".MP3" || tipo_Media == ".wma" || tipo_Media == ".wav")
            {
                var margin = bordelista.Margin;
                margin.Left = 0;
                margin.Top = 22;
                margin.Right = 0;
                bordelista.Margin = margin;
                bordelista.Width = 1077;
                bordelista.Height = 421;
                tiempo.Stop();
                contador = 0;
                BorderMediaControls.Visibility = Visibility.Visible;

            }
            else
            {
                bordelista.Margin = new Thickness(950, 22, 0, 0);
                bordelista.Width = 127;
                bordelista.Height = 486;
            }

        }

        private void PlayoPausa()
        {

            if (lbLista.HasItems)
            {
                if (btPlay.Visibility == Visibility.Visible)
                {
                    Play();
                }

                else if (btPausa.Visibility == Visibility.Visible)
                {
                    Pausa();
                }
            }

        }

        private void Play()
        {
            lbLista.Items.Add(@"C:\Users\kamil\Desktop\Со мной.mp3");
            if (lbLista.HasItems)
            {
                if (!MediaPausa)
                {
                    if (PistaActual != null)
                    {
                        PistaAnterior = PistaActual;
                        PistaAnterior.Foreground = lbLista.Foreground;
                    }
                    mediacontrol.Source = new Uri(@"C:\Users\kamil\Desktop\Со мной.mp3");
                    slideravance.Value = 0;
                }
            }
            TipoMedia();
            mediacontrol.Play();
            MediaPausa = false;
            btPlay.Visibility = Visibility.Collapsed;
            btPausa.Visibility = Visibility.Visible;

        }
        private void Pausa()
        {
            btPausa.Visibility = Visibility.Collapsed;
            btPlay.Visibility = Visibility.Visible;
            mediacontrol.Pause();
            MediaPausa = true;
        }

        private void Siguiente()
        {
            if (lbLista.HasItems)
            {

                if (repetir)
                {
                    lbLista.SelectedIndex = lbLista.SelectedIndex;
                    MediaPausa = false;
                    Play();
                }
                else
                {
                    if (lbLista.Items.IndexOf(PistaActual) < lbLista.Items.Count - 1)
                    {
                        lbLista.SelectedIndex = lbLista.Items.IndexOf(PistaActual) + 1;
                        MediaPausa = false;
                        Play();
                        return;
                    }
                    else if (lbLista.Items.IndexOf(PistaActual) == lbLista.Items.Count - 1)
                    {
                        lbLista.SelectedIndex = 0;
                        MediaPausa = false;
                        Play();
                        return;
                    }
                }
            }
            else
                Stop();

        }
        private void Stop()
        {
            btPlay.Visibility = Visibility.Visible;
            btPausa.Visibility = Visibility.Collapsed;
            mediacontrol.Stop();
            MediaPausa = false;
            mediacontrol.Source = null;
        }


        private void fullpantalla()
        {
            if (lbLista.HasItems)
            {
                if (tipo_Media != ".mp3" && tipo_Media != ".MP3" && tipo_Media != ".wma" && tipo_Media != ".wav")
                {

                    if (!fullscreen)
                    {
                        RootGrid.Children.Remove(bordercontroles);
                        RootGrid.Children.Remove(BorderMediaControls);
                        gridmedia.Children.Remove(mediacontrol);
                        RootGrid.Children.Remove(gridmedia);
                        this.Content = mediacontrol;

                        this.WindowStyle = WindowStyle.None;
                        this.WindowState = WindowState.Maximized;

                    }

                    else
                    {
                        this.Content = RootGrid;
                        gridmedia.Children.Add(mediacontrol);
                        RootGrid.Children.Add(gridmedia);
                        RootGrid.Children.Add(bordercontroles);
                        RootGrid.Children.Add(BorderMediaControls);



                        this.WindowStyle = WindowStyle.None;
                        this.WindowState = WindowState.Normal;

                    }

                    fullscreen = !fullscreen;


                }
                else
                {
                    MessageBox.Show("Modo De Reproducción De Audio", "Media Player", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
                MessageBox.Show("Lista Vacía", "Media Player", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void mediacontrol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fullpantalla();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                slideravance.Value = mediacontrol.Position.TotalSeconds;
                lbtime.Content = mediacontrol.Position.Minutes + ":" + mediacontrol.Position.Seconds;

            }
        }

        private void mediacontrol_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediacontrol.NaturalDuration.TimeSpan;
            slideravance.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void slideravance_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mediacontrol.Position = TimeSpan.FromSeconds(slideravance.Value);

        }

        private void mediacontrol_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Intro)
            {
                mediacontrol.Source = null;
                Intro = !Intro;

            }

            else
                Siguiente();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RootWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarIntro();
            Intro = !Intro;

        }

        private void btStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stop();
        }


        private void btPausa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Pausa();
        }

        private void btPlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Play();
        }

        private void lbLista_Drop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            cargar(s);
        }

        private void mediacontrol_MouseMove(object sender, MouseEventArgs e)
        {
            tiempo.Start();
            contador = 0;
            BorderMediaControls.Visibility = Visibility.Visible;
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }

}
