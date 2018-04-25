using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieParserLibrary
{
    public static class Helper
    {
        public static String translateLine(String line)
        {
            string output = line.Replace(",,", "ä");


            return output;
        }

        public static string getType(String line)
        {
            string type = "";
            if (line.Contains("#KONTO"))
            {
                type = "KONTO";
            }
            else if (line.Contains("#SRU"))
            {
                type = "SRU";
            }
            return type;
        }

        public static Konto automaticAccountCreation(String line)
        {
            List<string> kontoInfo = parseAccount(line);
            Konto parsedAccount = accountCreator(kontoInfo[2], kontoInfo[1]);
            return parsedAccount;
        }

        public static SRU automaticSRUCreation(String line)
        {
            string[] sruInfo = parseSRU(line);
            SRU newSRU = sruCreator(sruInfo[1], sruInfo[2]);
            return newSRU;
        }

        public static string[] parseSRU(String line)
        {
            //List<string> sruInfo = new List<string>();
            string[] srurad = line.Split(null);
            return srurad;
        }

        public static Skattepost parseSkatt(String line)
        {
            bool success = true;
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            if (line[0] != ';')
            {
                string[] data = line.Split(';');
                DateTime dateValue;
                int currentValue;
                string title;

                if (DateTime.TryParse(data[0], out dateValue))
                {

                }
                else { Console.WriteLine("invalid date : " + data[0]); success = false; }

                title = data[1];

                if (int.TryParse(data[2], out currentValue))
                {

                }
                else { Console.WriteLine("invalid value : " + data[1]); success = false; }
                if (success)
                {

                    Skattepost newPost = new Skattepost(dateValue, title, currentValue);
                    return newPost;
                }
                else return null;
            }

            return null;
        }

        public static int assignSRU(int accountNumber, List<SRU> sruListan)
        {
            try
            {
                var match = sruListan.FirstOrDefault(p => p.AccountNr == accountNumber);
                if (match != null)
                {
                    return match.SRUNumber;
                }
                else return 0;
            }
            catch (ArgumentNullException arg)
            {
                return 0;
            }

        }

        public static List<String> parseAccount(String line)
        {
            List<string> accountInfo = new List<string>();
            string[] kontorad = line.Split('"');
            //Console.WriteLine("Rad 0 = " + kontorad[0]);
            string[] splitAccArray = splitAccountNr(kontorad[0]); // innehåller 2 rader : Konto, kontonummer
            accountInfo.Add(splitAccArray[0]);
            accountInfo.Add(splitAccArray[1]);
            //Console.WriteLine("Rad 1 = " + kontorad[1]); // beskriver kontotsNamn, lägg in i Kontoobject
            accountInfo.Add(kontorad[1]);
            //Console.WriteLine("Rad 2 = " + kontorad[2]);
            return accountInfo;
        }

        public static string[] splitAccountNr(String line)
        {
            string[] accountArray = line.Split(null);
            //Console.WriteLine("Rad 0 konto " + accountArray[0]);
            //Console.WriteLine("Rad 1 konto " + accountArray[1]);
            return accountArray;
        }

        public static SRU sruCreator(String accountNumber, String sruNumber)
        {
            SRU newSRU = new SRU();
            newSRU.AccountNr = int.Parse(accountNumber);
            newSRU.SRUNumber = int.Parse(sruNumber);
            return newSRU;
        }

        public static Konto accountCreator(String kontoNamn, String kontoNummer)
        {
            Konto newKonto = new Konto();
            newKonto.Kontonamn = kontoNamn;
            newKonto.Kontonummer = int.Parse(kontoNummer);
            return newKonto;
        }
    }
}
