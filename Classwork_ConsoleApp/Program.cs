namespace Classwork_ConsoleApp
{
    interface IMusic
    {
        public string GetGenre();
    }

    class ClassicalMusic : IMusic
    {
        public string GetGenre()
        {
            return "Classical";
        }
    }

    class RockMusic : IMusic
    {
        public string GetGenre()
        {
            return "Rock";
        }
    }

    class FolkMusic : IMusic
    {
        public string GetGenre()
        {
            return "Fplk";
        }
    }

    class MusicPlayer
    {
        private readonly IMusic _music;

        public MusicPlayer(IMusic music)
        {
            _music = music;
        }
        public void PlayMusic()
        {
            Console.WriteLine($"[Music Player] Playing {_music.GetGenre()} music...");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Extensions.DependencyInjection.IServiceCollection services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();

            IMusic music = new RockMusic();
            MusicPlayer player = new MusicPlayer(music);
            player.PlayMusic();
        }
    }
}
