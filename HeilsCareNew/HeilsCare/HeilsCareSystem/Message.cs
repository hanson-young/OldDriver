using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HeilsCareSystem
{
    public class Message
    {
        public Message(int m_Id)
        {
            this.m_Id = m_Id;
        }
        private int m_Id; //消息的id

        public int GetMessageType()
        {
            return this.m_Id;
        }

        //消息包含的int型数据
        private List<int> m_listint = new List<int>();  
        public void Addint(int a)
        {
            m_listint.Add(a);
        }
        public int GetInt()
        {
            if (m_listint.Count == 0)
                return -1;
            int a = m_listint[0];
            m_listint.RemoveAt(0);
            return a;
        }

        //消息包含的double型数据
        List<double> m_listDouble = new List<double>();
        public void AddDouble(double a)
        {
            m_listDouble.Add(a);
        }
        public double GetDouble()
        {
            if (m_listDouble.Count == 0)
                return -1;
            double a = m_listDouble[0];
            m_listDouble.RemoveAt(0);
            return a;
        }


        //消息包含的String型数据
        List<string> m_listString = new List<string>();
        public void AddString(string a)
        {
            m_listString.Add(a);
        }
        public string GetString()
        {
            if (m_listString.Count == 0)
                return "";
            string a = m_listString[0];
            m_listString.RemoveAt(0);
            return a;
        }

    }
}
