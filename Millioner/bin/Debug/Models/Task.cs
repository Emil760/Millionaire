using System;
using System.IO;
using System.Windows.Media;
using System.Xml;

namespace Millioner.Models
{
    class Task
    {
        private static int complexity_count;

        private int id;
        private string question;
        private string answer1;
        private string answer2;
        private string answer3;
        private string answer4;

        public int Id { get => id; }
        public string Question { get => question; set => question = value; }
        public string Answer1 { get => answer1; set => answer1 = value; }
        public string Answer2 { get => answer2; set => answer2 = value; }
        public string Answer3 { get => answer3; set => answer3 = value; }
        public string Answer4 { get => answer4; set => answer4 = value; }

        static Task()
        {
            complexity_count = 15;
            XmlDocument document = new XmlDocument();
            if (!File.Exists("tasks.xml"))
            {
                XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "utf-8", null);
                document.AppendChild(declaration);
                var root = document.CreateElement("root");
                document.AppendChild(root);
                for (int i = 0; i < complexity_count; i++)
                {
                    var element = document.CreateElement("Complexity");
                    var attr = document.CreateAttribute("complexity");
                    attr.InnerText = (i + 1).ToString();
                    element.Attributes.Append(attr);
                    root.AppendChild(element);
                }
                document.Save("tasks.xml");
            }
        }

        public Task()
        {
            this.id = -1;
            this.question = "Non";
            this.answer1 = "Non";
            this.answer2 = "Non";
            this.answer3 = "Non";
            this.answer4 = "Non";
        }

        public Task(string question, string answer1, string answer2, string answer3, string answer4)
        {
            this.question = question;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
        }

        public static void Save(int complexity, Task task)
        {
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");

            foreach (XmlNode item in document.DocumentElement)
            {
                if (int.Parse(item.Attributes[0].InnerText) == complexity)
                {
                    var question = document.CreateElement("Question");
                    if (item.LastChild != null) task.id = int.Parse(item.LastChild.Attributes["id"].InnerText) + 1;

                    var attr = document.CreateAttribute("id");
                    attr.InnerText = task.id.ToString();
                    question.Attributes.Append(attr);

                    attr = document.CreateAttribute("question");
                    attr.InnerText = task.question;
                    question.Attributes.Append(attr);

                    attr = document.CreateAttribute("answer1");
                    attr.InnerText = task.answer1;
                    question.Attributes.Append(attr);

                    attr = document.CreateAttribute("answer2");
                    attr.InnerText = task.answer2;
                    question.Attributes.Append(attr);

                    attr = document.CreateAttribute("answer3");
                    attr.InnerText = task.answer3;
                    question.Attributes.Append(attr);

                    attr = document.CreateAttribute("answer4");
                    attr.InnerText = task.answer4;
                    question.Attributes.Append(attr);

                    item.AppendChild(question);
                    document.Save("tasks.xml");
                    return;
                }
            }
        }

        public static void Update(int complexity, int id, Task task)
        {
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");

            foreach (XmlNode complex in document.DocumentElement)
            {
                if (int.Parse(complex.Attributes["complexity"].InnerText) == complexity)
                {
                    foreach (XmlNode item in complex.ChildNodes)
                    {
                        if (int.Parse(item.Attributes["id"].InnerText) == id)
                        {
                            item.Attributes["question"].InnerText = task.question;
                            item.Attributes["answer1"].InnerText = task.answer1;
                            item.Attributes["answer2"].InnerText = task.answer2;
                            item.Attributes["answer3"].InnerText = task.answer3;
                            item.Attributes["answer4"].InnerText = task.answer4;
                            document.Save("tasks.xml");
                            return;
                        }
                    }
                }
            }
        }

        public static void RemoveById(int complexity, int id)
        {
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");
            foreach (XmlNode complex in document.DocumentElement)
            {
                if (int.Parse(complex.Attributes[0].InnerText) == complexity)
                {
                    foreach (XmlNode element in complex.ChildNodes)
                    {
                        if (int.Parse(element.Attributes["id"].InnerText) == id)
                        {
                            complex.RemoveChild(element);
                            document.Save("tasks.xml");
                            return;
                        }
                    }
                }
            }
        }

        public static int FindById(int complexity, string question)
        {
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");
            foreach (XmlNode complex in document.DocumentElement)
            {
                if (int.Parse(complex["complexity"].Value) == complexity)
                {
                    foreach (XmlNode element in complex.ChildNodes)
                    {
                        if (element.Attributes["question"].Value == question)
                            return int.Parse(element.Attributes["id"].Value);
                    }
                }
            }
            return -1;
        }

        public static Task[] GetAllQuestions(int complexity)
        {
            Task[] questions = null;
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");
            foreach (XmlNode complex in document.DocumentElement)
            {
                if (int.Parse(complex.Attributes["complexity"].InnerText) == complexity)
                {
                    questions = new Task[complex.ChildNodes.Count];
                    for (int i = 0; i < complex.ChildNodes.Count; i++)
                    {
                        //questions[i].complexity = complexity;
                        questions[i] = new Task();
                        questions[i].id = int.Parse(complex.ChildNodes[i].Attributes["id"].InnerText);
                        questions[i].question = complex.ChildNodes[i].Attributes["question"].InnerText;
                        questions[i].answer1 = complex.ChildNodes[i].Attributes["answer1"].InnerText;
                        questions[i].answer2 = complex.ChildNodes[i].Attributes["answer2"].InnerText;
                        questions[i].answer3 = complex.ChildNodes[i].Attributes["answer3"].InnerText;
                        questions[i].answer4 = complex.ChildNodes[i].Attributes["answer4"].InnerText;
                    }
                }
            }
            return questions;
        }

        //public void FindByQuestion(int complexity, string question)
        //{
        //    XmlDocument document = new XmlDocument();
        //    document.Load("tasks.xml");
        //    foreach (XmlNode complex in document.DocumentElement)
        //    {
        //        if (int.Parse(complex.Attributes["complexity"].Value) == complexity)
        //        {
        //            foreach (XmlNode item in complex.ChildNodes)
        //            {
        //                if (item.Attributes["question"].Value == question)
        //                {
        //                    this.id = int.Parse(item.Attributes["id"].Value);
        //                    this.question = item.Attributes["question"].Value;
        //                    this.answer1 = item.Attributes["answer1"].Value;
        //                    this.answer2 = item.Attributes["answer2"].Value;
        //                    this.answer3 = item.Attributes["answer3"].Value;
        //                    this.answer4 = item.Attributes["answer4"].Value;
        //                    current_id = this.id;
        //                }
        //            }
        //        }
        //    }
        //}

        public static int[] GetAllComplexities()
        {
            int[] complexities;
            XmlDocument document = new XmlDocument();
            document.Load("tasks.xml");
            complexities = new int[document.DocumentElement.ChildNodes.Count];
            for (int i = 0; i < document.DocumentElement.ChildNodes.Count; i++)
                complexities[i] = int.Parse(document.DocumentElement.ChildNodes[i].Attributes[0].InnerText);
            return complexities;
        }
    }

}
