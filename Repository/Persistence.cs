using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Diagram.Repository
{
    public class Persistence
    {
        public static uint GetNewId(string path)
        {
            List<string> entries = new List<string>(File.ReadAllLines(path).Skip(1));
            uint maxId = 0, temp = 0;
            foreach (string s in entries)
                if (maxId < (temp = uint.Parse(s.Split(',')[0])))
                    maxId = temp;
            return maxId + 1;
        }
        public static bool WriteEntry(string path, string[] data)
        {
            string entry = "";
            foreach (string s in data)
                entry += s + ",";
            entry = entry.TrimEnd(',');
            var entryList = new List<string>();
            entryList.Add(entry);
            File.AppendAllLines(path, entryList);
            return true;
        }
        public static bool EditEntry(string path, string[] data)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            List<string> entries = new List<string>(lines.Skip(1));
            foreach (string entry in entries.ToList())
                if (data[0].Equals(entry.Split(',')[0]))
                {
                    string temp = "";
                    foreach (string s in data)
                        temp += s + ",";
                    temp = temp.TrimEnd(',');
                    entries[entries.IndexOf(entry)] = temp;
                }
            File.Delete(path);
            entries.Insert(0, lines[0]);
            File.WriteAllLines(path, entries);
            return true;
        }
        public static List<string[]> ReadEntryByPrimaryKey(string path, string id)
        {
            return ReadEntryByKey(path, id, 0);
        }
        public static List<string[]> ReadEntryByKey(string path, string id, int position)
        {
            List<string> entries = new List<string>(File.ReadAllLines(path).Skip(1));
            List<string[]> ret = new List<string[]>();
            foreach(string entry in entries)
            {
                string[] parts = entry.Split(',');
                if (id.Equals(parts[position]))
                    ret.Add(parts);
            }
            return ret;
        }
        public static bool RemoveEntry(string path, string id)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            List<string> entries = new List<string>(lines.Skip(1));
            foreach (string entry in entries)
                if (id.Equals(entry.Split(',')[0]))
                {
                    entries.Remove(entry);
                    break;
                }
            File.Delete(path);
            entries.Insert(0, lines[0]);
            File.WriteAllLines(path, entries);
            return true;
        }
        public static List<string> ReadAllPrimaryIds(string path)
        {
            List<string> entries = new List<string>(File.ReadAllLines(path).Skip(1));
            List<string> ret = new List<string>();
            foreach (string entry in entries)
            {
                string[] parts = entry.Split(',');
                ret.Add(parts[0]);
            }
            return ret;
        }
    }
}
