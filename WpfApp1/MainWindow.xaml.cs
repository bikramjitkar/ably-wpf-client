using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IO.Ably;
using IO.Ably.Realtime;
using LibVLCSharp.Shared;
using LibVLCSharp.WPF;

namespace WpfApp1
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string PLAYBACK_ID = "nRuBBFiHD01Sk00S9ILSmHVp00pB4yOvW7tnogzAuEVzAI";
        public MainWindow()
        {
            InitializeComponent();



            //establish connection to ably
            var ably = new AblyRealtime("m3sDLg.-yXR5g:QWVHGMivZv-y-w0A3wXEMhNT7gXRE6QNz9sZUON8DOI");
            ably.Connection.On(ConnectionEvent.Connected, args =>
            {
                Dispatcher.Invoke(() => txtMessages.Text = "Connected to Ably!");
            });


            //Subscribe to a channel/messages
            var channel = ably.Channels.Get("quickstart");
            channel.Subscribe(message =>
            {
                Dispatcher.Invoke(() => txtMessages.Text += ("Received a greeting message in realtime: {0}", message.Data));
            });

            ////for testing mux video streaming
           // videoPlayer.Loaded += VideoPlayer_Loaded;

        }

      

        LibVLC _libVLC;
        MediaPlayer _mediaPlayer;


        //private void VideoPlayer_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Core.Initialize();

        //    _libVLC = new LibVLC();
        //    _mediaPlayer = new MediaPlayer(_libVLC);
        //    videoPlayer.MediaPlayer = _mediaPlayer;

        //    _mediaPlayer.Play(new Media(_libVLC, new Uri($"https://stream.mux.com/{PLAYBACK_ID}.m3u8")));


        //}
    }
}
