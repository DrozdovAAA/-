using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public interface ISaveManager
    {
        void WriteLine(string line);
        void WriteObject(IWritableObject obj);
    }

    public interface IWritableObject
    {
        void Write(ISaveManager man);
    }
    public class SaveManager : ISaveManager
    {
        FileInfo file;

        public SaveManager(string filename)
        {
            file = new FileInfo(filename);
        }

        public void WriteLine(string line)
        {
            var output = file.AppendText();
            output.WriteLine(line);
            output.Close();
        }

        public void WriteObject(IWritableObject obj)
        {
            obj.Write(this);
        }
    }
}