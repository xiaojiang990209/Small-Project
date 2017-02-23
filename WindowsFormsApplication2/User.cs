using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class User
    {
        string _userName;
        string _password;
        string _text;
        int _minTimeDelay;
        int _maxTimeDelay;
        int _startTime;
        int _endTime;
        int _maxNumMessages;
        static User user;
        static Random ran;
        List<string> _schoolName;
        List<string> _principalName;
        List<string> _websiteAddress;

        //Private constructor
        private User()
        {
            userName = "";
            password = "";
            text = "";
            minTimeDelay = 0;
            maxTimeDelay = 3;
            startTime = 0;
            endTime = 24;
            maxNumMessages = 1000;
            ran = new Random();
            _schoolName = new List<string>();
            _principalName = new List<string>();
            _websiteAddress = new List<string>();
        }

        //Singleton
        public static User getInstance()
        {
            if (user == null)
            {
                user = new WindowsFormsApplication2.User();
            }
            return user;
        }

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        public int minTimeDelay
        {
            get { return _minTimeDelay; }
            set { _minTimeDelay = value; }
        }

        public int maxTimeDelay
        {
            get { return _maxTimeDelay; }
            set { _maxTimeDelay = value; }
        }

        public int startTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }

        public int endTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }

        public int maxNumMessages
        {
            get { return _maxNumMessages; }
            set { _maxNumMessages = value; }
        }

        public List<string> schoolName
        {
            get { return _schoolName; }
        }

        public List<string> principalName
        {
            get { return _principalName; }
        }

        public List<string> websiteAddress
        {
            get { return _websiteAddress; }
        }

        public string spintax()
        {
            string bracketTemp="";
            string finalSpintax="";
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '{')
                {
                    int j = i + 1;
                    while (text[j] != '}')
                    {
                        bracketTemp += text[j];
                        j++;
                    }
                    i = j;
                    string[] spintaxes = bracketTemp.Split('|');
                    int randomNum = ran.Next(0,spintaxes.Length);
                    Console.WriteLine(randomNum);
                    finalSpintax += spintaxes[randomNum];
                    bracketTemp = "";
                }
                else
                {
                    finalSpintax += c;
                }
            }
            return finalSpintax;
        }

        public void readFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            
            sr.ReadLine();
            string line = "";
            string[] columns;
            while ((line = sr.ReadLine()) != null)
            {
                //int commaCount = 0;
                //for(int j = 0; j < line.Length; j++)
                //{
                //    if (line[j] == ',')
                //    {
                //        commaCount++;
                //    }
                //}
                //if (count == 600) break;
                columns = line.Split(',');
                schoolName.Add(columns[0]);
                principalName.Add(columns[1]);
                websiteAddress.Add(columns[2]);
                
            }
            sr.Close();

        }

        public override string ToString()
        {
            string s = "";
            s += ("Username = " + userName + "\r\n");
            s += ("Password = " + password + "\r\n");
            s += ("MinTimeDelay = " + minTimeDelay + "\r\n");
            s += ("MaxTimeDelay = " + maxTimeDelay + "\r\n");
            s += ("StartTime = " + startTime + "\r\n");
            s += ("EndTime = " + endTime + "\r\n");
            s += ("MaxNumMessages = " + maxNumMessages + "\r\n\r\n\r\n");
            s += ("Facebook message text = " + text + "\r\n");

            return s;
        }
    }
}
