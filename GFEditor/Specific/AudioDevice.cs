using NAudio.Wave;

namespace GFEditor.Specific
{
    public static class AudioDevice
    {
        private static readonly WaveOutEvent SoundPlayer = new();
        private static AudioFileReader? CurrentAudioFile = null;

        public static void Initialize()
        {
            SoundPlayer.PlaybackStopped += SoundPlayer_PlaybackStopped;
        }

        public static void Play(string fileName)
        {
            var path = ConfigUtils.GetObjectPath("Sound\\", fileName + ".wav");
            if (path.FileExist())
            {
                SoundPlayer.Stop(); // Stop any currently playing sound.
                CurrentAudioFile = new AudioFileReader(path);
                SoundPlayer.Init(CurrentAudioFile);
                SoundPlayer.Play();
            }
            else
            {
                GuiNotify.Show(ImGuiToastType.Error, "AudioDevice", $"Failed to play sound, file not found: {path}");
            }
        }

        private static void SoundPlayer_PlaybackStopped(object? sender, StoppedEventArgs e)
        {
            CurrentAudioFile?.Dispose();
            CurrentAudioFile = null;
        }

        public static void Stop()
        {
            SoundPlayer.Stop();
            CurrentAudioFile?.Dispose();
            CurrentAudioFile = null;
        }

        public static void Dispose()
        {
            SoundPlayer.Dispose();
            CurrentAudioFile?.Dispose();
            CurrentAudioFile = null;
        }
    }
}
