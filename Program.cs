using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба_4
{
    class Word
    {
        private string text;
        public Word(string text)
        {
            this.text = text;
            Console.WriteLine("Создан объект Word");
        }
        public string Text => text;
        public override bool Equals(object obj)
        {
            Console.WriteLine("Вызван Equals в Word");
            if (obj is Word other)
            {
                return text == other.text;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Console.WriteLine("Вызван GetHashCode в Word");
            return text.GetHashCode();
        }
        public override string ToString()
        {
            Console.WriteLine("Вызван ToString в Word");
            return text;
        }
    }
    class Sentence
    {
        private List<Word> words;
        public Sentence()
        {
            words = new List<Word>();
            Console.WriteLine("Создан объект Sentence");
        }
        public void AddWord(Word word)
        {
            Console.WriteLine($"Добавлено слово '{word.Text}' в предложение");
            words.Add(word);
        }
        public override bool Equals(object obj)
        {
            Console.WriteLine("Вызван Equals в Sentence");
            if (obj is Sentence other)
            {
                if (words.Count != other.words.Count) return false;
                for (int i = 0; i < words.Count; i++)
                {
                    if (!words[i].Equals(other.words[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Console.WriteLine("Вызван GetHashCode в Sentence");
            int hash = 17;
            foreach (var w in words)
            {
                hash = hash * 31 + w.GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            Console.WriteLine("Вызван ToString в Sentence");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Count; i++)
            {
                sb.Append(words[i].ToString());
                if (i < words.Count - 1)
                    sb.Append(" ");
            }
            sb.Append(".");
            return sb.ToString();
        }
    }
    class Text
    {
        private List<Sentence> sentences;
        private string title;
        public Text(string title)
        {
            this.title = title;
            sentences = new List<Sentence>();
            Console.WriteLine("Создан объект Text");
        }
        public void AddSentence(Sentence sentence)
        {
            Console.WriteLine("Добавлено предложение в текст");
            sentences.Add(sentence);
        }
        public void PrintTitle()
        {
            Console.WriteLine("Заголовок текста:");
            Console.WriteLine(title);
        }
        public void PrintText()
        {
            Console.WriteLine("Содержимое текста:");
            foreach (var sentence in sentences)
            {
                Console.WriteLine(sentence.ToString());
            }
        }
        public void AppendText(Text other)
        {
            Console.WriteLine("Дополнение текста");
            foreach (var sentence in other.sentences)
            {
                sentences.Add(sentence);
            }
        }
        public override bool Equals(object obj)
        {
            Console.WriteLine("Вызван Equals в Text");
            if (obj is Text other)
            {
                if (title != other.title || sentences.Count != other.sentences.Count) return false;
                for (int i = 0; i < sentences.Count; i++)
                {
                    if (!sentences[i].Equals(other.sentences[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            Console.WriteLine("Вызван GetHashCode в Text");
            int hash = title.GetHashCode();
            foreach (var sentence in sentences)
            {
                hash = hash * 31 + sentence.GetHashCode();
            }
            return hash;
        }
        public override string ToString()
        {
            Console.WriteLine("Вызван ToString в Text");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(title.ToUpper());
            foreach (var sentence in sentences)
            {
                sb.AppendLine(sentence.ToString());
            }
            return sb.ToString();
        }
    }
    class Program
    {
        static void Main()
        {
            Text text = new Text("Мій заголовок");
            Sentence sentence1 = new Sentence();
            sentence1.AddWord(new Word("Це"));
            sentence1.AddWord(new Word("перше"));
            sentence1.AddWord(new Word("речення"));
            Sentence sentence2 = new Sentence();
            sentence2.AddWord(new Word("Ось"));
            sentence2.AddWord(new Word("друге"));
            sentence2.AddWord(new Word("речення"));
            text.AddSentence(sentence1);
            text.AddSentence(sentence2);
            text.PrintTitle();
            text.PrintText();
            Console.WriteLine("\nПовний текст за допомогою ToString():");
            Console.WriteLine(text.ToString());
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}