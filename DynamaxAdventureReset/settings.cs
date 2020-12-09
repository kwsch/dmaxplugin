﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DynamaxAdventureReset
{
    public class Settings
    {

        public Dictionary<string, string> Items = new Dictionary<string, string>()
    {
        { "latest", "1.1.2.0" },
        { "firstStart", "true" }
    };

        public void Read(string dir)
        {
            using (StreamReader sr = new StreamReader($"{dir}\\DynamaxAdventureReset.cfg"))
            {
                Items.Clear();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.StartsWith("#"))
                    {
                        string[] linearr = line.Split(':');
                        Items.Add(linearr[0], linearr[1]);
                    }
                }
                sr.Close();
            }
        }

        public void Write(string dir)
        {
            using (StreamWriter sw = new StreamWriter($"{dir}\\DynamaxAdventureReset.cfg"))
            {
                sw.WriteLine("#Config for Dynamax Adventure Plugin");
                for (int i = 0; i < Items.Count; i++)
                {
                    sw.WriteLine($"{Items.ElementAt(i).Key}:{Items.ElementAt(i).Value}");
                }
                sw.Close();
            }
        }
    }
}
