using Millioner.Utilities;
using System.Xml;

namespace Millioner.Models
{
    class User : ObserableObject
    {
        private string login;
        private string password;
        private int games;
        private short average_score;
        private int money;

        static User()
        {
            if (!System.IO.File.Exists("users.xml"))
            {
                XmlDocument document = new XmlDocument();
                document.AppendChild(document.CreateXmlDeclaration("1.0", "UTF-8", null));
                document.AppendChild(document.CreateElement("Root"));
                document.Save("users.xml");
            }
        }

        public User()
        {

        }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string Login { get => login; set => Set(ref login, value); }
        public int Games { get => games; set => Set(ref games, value); }
        public short AverageScore { get => average_score; set => Set(ref average_score, value); }
        public int Money { get => money; set => Set(ref money, value); }

        public bool Save()
        {
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");

            foreach (XmlNode item in document.DocumentElement)
            {
                if (item.Attributes["login"].InnerText == login || item.Attributes["password"].InnerText == password)
                    return false;
            }
            var user = document.CreateElement("User");

            var attr = document.CreateAttribute("login");
            attr.InnerText = login;
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("password");
            attr.InnerText = password;
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("games");
            attr.InnerText = "0";
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("averageScore");
            attr.InnerText = "0";
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("money");
            attr.InnerText = "0";
            user.Attributes.Append(attr);

            document.DocumentElement.AppendChild(user);
            document.Save("users.xml");
            return true;
        }

        public bool Search(string login, string password)
        {
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");

            foreach (XmlElement user in document.DocumentElement)
            {
                if (user.Attributes["login"].InnerText == login)
                    if (user.Attributes["password"].InnerText == password)
                        return true;
            }
            return false;
        }

        public void AddGame(int complexity, int money = 0)
        {
            float avg;
            int games;
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");
            foreach (XmlNode item in document.DocumentElement)
            {
                if (item.Attributes["login"].Value == login && item.Attributes["password"].Value == password)
                {
                    games = int.Parse(item.Attributes["games"].Value) + 1;
                    avg = float.Parse(item.Attributes["averageScore"].Value);
                    avg = (avg * (games - 1) + complexity) / games;
                    item.Attributes["games"].Value = games.ToString();
                    item.Attributes["averageScore"].Value = avg.ToString();
                    item.Attributes["money"].Value = (int.Parse(item.Attributes["money"].Value) + money).ToString();
                    break;
                }
            }
            document.Save("users.xml");
        }

        public static User[] GetAllUsers()
        {
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");
            User[] users = new User[document.DocumentElement.ChildNodes.Count];
            for (int i = 0; i < document.DocumentElement.ChildNodes.Count; i++)
            {
                User user = new User();
                user.Login = document.DocumentElement.ChildNodes[i].Attributes["login"].Value;
                user.Games = int.Parse(document.DocumentElement.ChildNodes[i].Attributes["games"].Value);
                user.AverageScore = short.Parse(document.DocumentElement.ChildNodes[i].Attributes["averageScore"].Value);
                user.Money = int.Parse(document.DocumentElement.ChildNodes[i].Attributes["money"].Value);
                users[i] = user;
            }
            return users;
        }

    }
}