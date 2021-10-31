using System;
using System.Xml;

namespace Millioner.Models
{
    class User
    {
        private int id;
        private string login;
        private string password;

        public User(string login, string password)
        {

        }

        public bool Save(string login, string password)
        {
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");

            foreach (XmlNode item in document.DocumentElement)
            {
                if (item.Attributes["login"].InnerText == login || item.Attributes["password"].InnerText == password)
                {
                    return false;
                }
            }
            id = int.Parse(document.DocumentElement.LastChild.Attributes["id"].InnerText) + 1;
            this.login = login;
            this.password = password;

            var user = document.CreateElement("User");

            var attr = document.CreateAttribute("id");
            attr.InnerText = id.ToString();
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("login");
            attr.InnerText = login;
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("password");
            attr.InnerText = password;
            user.Attributes.Append(attr);

            attr = document.CreateAttribute("games");
            attr.InnerText = "0";
            user.Attributes.Append(attr);

            document.DocumentElement.AppendChild(user);
            document.Save("users.xml");
            return true;
        }

        public void SaveGameInfo(int complexity, int money)
        {
            XmlDocument document = new XmlDocument();
            document.Load("users.xml");

            foreach (XmlNode item in document.DocumentElement)
            {
                if(int.Parse(item.Attributes["id"].InnerText) == id)
                {
                    item.Attributes["games"].InnerText = (int.Parse(item.Attributes["games"].InnerText) + 1).ToString();

                    var game = document.CreateElement("Game");

                    var attr = document.CreateAttribute("date");
                    attr.InnerText = DateTime.Now.ToShortDateString();
                    game.Attributes.Append(attr);

                    attr = document.CreateAttribute("complexity");
                    attr.InnerText = complexity.ToString();
                    game.Attributes.Append(attr);

                    attr = document.CreateAttribute("money");
                    attr.InnerText = money.ToString();
                    game.Attributes.Append(attr);

                    item.AppendChild(game);
                    document.Save("users.xml");
                    return;
                }
            }
        }
    }
}
