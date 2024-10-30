using Demo.Clip01.Data;

namespace Demo.Clip01.CheapDb
{
    public class Command : ICommand
    {
        public string Text { get; }

        public Command(string text) => Text = text;
    }
}