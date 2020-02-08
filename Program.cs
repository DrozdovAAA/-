using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.IO;


namespace ConsoleApp3
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Owner> owner = new List<Owner>();
            List<Agency> agency = new List<Agency>();
            List<Object1> object1 = new List<Object1>();
            List<Lodger> lodger = new List<Lodger>();
            Object1.InputObject1(ref object1);

            LoadManager loader1 = new LoadManager("object1.txt");
            loader1.BeginRead();
            while (loader1.IsLoading)
                object1.Add(loader1.Read(new Object1.Loader()) as Object1);
            loader1.EndRead();

             LoadManager loader2 = new LoadManager("Owner.txt");
             loader2.BeginRead();
             while (loader2.IsLoading)
                 owner.Add(loader2.Read(new Owner.Loader()) as Owner);
             loader2.EndRead();

            FileStream file1 = new FileStream("object1.txt", FileMode.Create);
            FileStream file2 = new FileStream("Owner.txt", FileMode.Create);
            FileStream file3 = new FileStream("Agency.txt", FileMode.Create);
            FileStream file4 = new FileStream("Lodger.txt", FileMode.Create);
            file1.Close();
            file2.Close();
            file3.Close();
            file1.Close();
            SaveManager first = new SaveManager("object1.txt");
            foreach (var x in object1) {
                first.WriteObject(x);
            }

            SaveManager ownerInFle = new SaveManager("Owner.txt");
            foreach (var x in owner)
            {
                ownerInFle.WriteObject(x);
            }

            SaveManager agencyInFle = new SaveManager("Agency.txt");
            foreach (var x in owner)
            {
                agencyInFle.WriteObject(x);
            }

            SaveManager ownelodgerInFle = new SaveManager("Lodger.txt");
            foreach (var x in owner)
            {
                ownelodgerInFle.WriteObject(x);
            }

            
                
            

            Owner.InputOwner(ref owner);
            Agency.InputAgency(ref agency);
            Lodger.InputLodger(ref lodger);
            Console.ReadKey();
            
            
        }
    }
}
