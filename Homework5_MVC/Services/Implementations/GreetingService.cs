namespace Homework5_MVC.Services.Implementations
{
    public class GreetingService : IGreetingService
    {
        private readonly List<string> greetings = ["Good night!", "Good morning!", "Good day!", "Good evening!"];

        private readonly TimeSpan nightBorder = TimeSpan.Parse("6:00");
        private readonly TimeSpan morningBorder = TimeSpan.Parse("12:00");
        private readonly TimeSpan dayBorder = TimeSpan.Parse("18:00");

        public string GetGreetingMessage()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            TimeSpan timeNow = DateTime.Now.TimeOfDay;
            if (timeNow < nightBorder) return greetings[0];
            else if (timeNow < morningBorder) return greetings[1];
            else if (timeNow < dayBorder) return greetings[2];
            else return greetings[3];
        }
    }
}
