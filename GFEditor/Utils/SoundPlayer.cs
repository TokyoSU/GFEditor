using NAudio.Wave;
using System.IO;

namespace GFEditor.Utils
{
    public class SoundPlayer
    {
        public string Name;
        public AudioFileReader File;
        public WaveOutEvent Player;

        public void Init()
        {
            Player = new WaveOutEvent();
            Player.Init(File);
            Player.PlaybackStopped += Player_PlaybackStopped;
        }

        private void Player_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Player?.Stop();
        }

        public void Play()
        {
            File?.Seek(0, SeekOrigin.Begin);
            Player?.Play();
        }

        public void Release()
        {
            File?.Dispose();
            Player?.Dispose();
        }
    }
}
