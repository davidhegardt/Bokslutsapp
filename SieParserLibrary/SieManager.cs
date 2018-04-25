using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieParserLibrary
{
    public class SieManager
    {
        private List<Konto> kontoLista;
        private List<SRU> sruLista;
        private List<Skattepost> skattePoster;
        int skatteID;

        public SieManager()
        {
            this.kontoLista = new List<Konto>();
            this.sruLista = new List<SRU>();
        }

        public void setupSkatt(String path)
        {
            string[] lines = readFile(path);
            foreach (string n in lines)
            {
                Skattepost created = Helper.parseSkatt(n);
                if (created != null)
                {
                    skatteID++;
                    created.ID = skatteID;
                    Console.WriteLine("Creation success : " + created.ID);

                    skattePoster.Add(created);
                }
                else Console.WriteLine("Creation failed..");
            }

        }

        public void setupKonto(String path)
        {
            string[] lines = readFile(path);
            foreach (string line in lines)
            {
                String typeOfLine = Helper.getType(line);
                switch (typeOfLine)
                {
                    case "KONTO":
                        Konto oneOccunt = Helper.automaticAccountCreation(line); kontoLista.Add(oneOccunt);
                        break;
                    case "SRU":
                        SRU oneSRU = Helper.automaticSRUCreation(line); sruLista.Add(oneSRU);
                        break;
                }

            }
            bindSRU();
        }

        private void bindSRU()
        {
            foreach (Konto k in kontoLista)
            {
                /*
                Console.WriteLine("Kontonamn :" + k.Kontonamn);
                Console.WriteLine("Kontonummer : " + k.Kontonummer);
                Console.WriteLine("SRU nummer för kontonummer : " + k.SRUnumber);
                */
                int SRUnummer = Helper.assignSRU(k.Kontonummer, sruLista);
                k.SRUnumber = SRUnummer;
            }
        }


        private string[] readFile(string path)
        {
            string[] skatteKonto = System.IO.File.ReadAllLines(path, System.Text.Encoding.GetEncoding(1252));
            return skatteKonto;
        }

        public List<SRU> getSRUList()
        {
            return this.sruLista;
        }

        public List<Konto> getKontoList(String path)
        {
            if (this.kontoLista.Count == 0)
            {
                setupKonto(path);
            }
            return this.kontoLista;
        }

        public List<Skattepost> getSkatteList(String path)
        {
            if (this.skattePoster.Count == 0)
            {
                setupSkatt(path);
            }
            return this.skattePoster;
        }
    }
}
