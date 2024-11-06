using AbstractFactory.Data;

namespace AbstractFactory.CheapDb
{
    public class CheapCommand : ICommand
    {
        public string Text { get; }
     
        public CheapCommand(string text)
        {
            this.Text = text;
        }
    }
}
