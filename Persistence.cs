using System;

namespace contact_manager
{
    public class Persistence
    {
        private string textFile;
        public Persistence(string textFile)
        {
            this.textFile = textFile;
        }

        public string Load()
        {
            string text = "";
            string[] lines = System.IO.File.ReadAllLines(textFile);
            foreach (string line in lines)
            {
                text += line;
                text += Environment.NewLine;
            }
            return text;

        }
        public void Save(string text)
        {
            System.IO.File.WriteAllText(textFile, text);
        }
    }
}