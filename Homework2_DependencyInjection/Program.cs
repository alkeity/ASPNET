using Microsoft.Extensions.DependencyInjection;

namespace Homework2_DependencyInjection
{
    interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    interface IMusic
    {
        string GetGenre();
    }

    class Music : IMusic
    {
        protected string _genre = string.Empty;

        public string GetGenre()
        {
            return _genre;
        }
    }

    class FolkMusic : Music
    {
        public FolkMusic()
        {
            _genre = "Folk";
        }
    }

    class RockMusic : Music
    {
        public RockMusic()
        {
            _genre = "Rock";
        }
    }

    class MusicPlayer
    {
        IMusic _music;
        ILogger _logger;

        public MusicPlayer(IMusic music, ILogger logger)
        {
            _music = music;
            _logger = logger;
        }

        public void PlayMusic()
        {
            _logger.Log($"Now playing: {_music.GetGenre()} music.");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddSingleton<IMusic, FolkMusic>();
            services.AddSingleton<MusicPlayer>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            MusicPlayer player = serviceProvider.GetRequiredService<MusicPlayer>();
            player.PlayMusic();
        }
    }
}
