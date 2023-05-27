using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raspored
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string nemaMista = "";
            //testne datoteke su r1 i r2
            string fileName=txtIme.Text+".txt";
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Datoteka ne postoji ");
                return;
            }
            string[] lines=File.ReadAllLines(fileName);
            int dv = int.Parse(lines[0]);
            int n=lines.Length-dv-1;
            Predmet[] svi=new Predmet[n];
            Dvorana[] d = new Dvorana[dv];
            for (int i = 1; i < dv+1; i++)
            {
                string[] x = lines[i].Split();
                Dvorana t = new Dvorana(x[0], int.Parse(x[1]), int.Parse(x[2]));
                d[i-1] = t;
            }
            for (int i = 0; i < n; i++)
            {
                string[] x = lines[i+dv+1].Split();
                Predmet p = new Predmet(x[0], int.Parse(x[1]), int.Parse(x[2]), x[3], int.Parse(x[4]));
                svi[i] = p;
            }
            rtbRaspored.Text = "RASPORED:\n";
            var dvorane = d.OrderBy(x => x.vrsta).ThenBy(k => k.kapacitet);
            var sortirano=svi.OrderByDescending(x => x.potrebno).ThenBy(k=>k.kraj).ThenByDescending(k=>k.brojSt);
            foreach (Predmet p in sortirano)
            {
                bool smjesteno = false;
                foreach (Dvorana dd in dvorane)
                {
                    if (p.potrebno==dd.vrsta&&p.brojSt<=dd.kapacitet&&p.poc>=dd.trenutnoVrijeme)
                    {
                        dd.trenutnoVrijeme = p.kraj;
                        dd.raspored+=p.naziv+": "+ p.poc+"-"+p.kraj+"\n";
                        smjesteno = true;
                        break;
                    }
                }
                if (!smjesteno)
                {
                    foreach (Dvorana dd in dvorane)
                    {
                        if (p.potrebno < dd.vrsta && p.brojSt <= dd.kapacitet && p.poc >= dd.trenutnoVrijeme)
                        {
                            dd.trenutnoVrijeme = p.kraj;
                            dd.raspored += p.naziv + ": " + p.poc + "-" + p.kraj + "\n";
                            smjesteno = true;
                            break;
                        }
                    }
                }
                if (!smjesteno)
                {
                    nemaMista += p.naziv+"\n";
                }
            }
            foreach (Dvorana dd in dvorane)
            {
                rtbRaspored.Text += dd.naziv + "\n" + dd.raspored;
            }
            if (nemaMista!="")
            {
                MessageBox.Show("Nisu se mogli smjestiti:\n"+nemaMista);
            }

        }
    }
    public class Predmet
    {
        public string naziv;
        public int poc;
        public int kraj;
        public int potrebno;
        public int brojSt;
        public Predmet(string n,int p,int k,string s,int b)
        {
            this.naziv = n;
            this.poc = p;
            this.kraj = k;
            if (s=="ništa")
            {
                this.potrebno = 1;
            }
            else if (s=="računala")
            {
                this.potrebno = 2;
            }
            else
            {
                this.potrebno = 3;
            }
            this.brojSt = b;
        }
    }
    public class Dvorana
    {
        public string naziv;
        public int vrsta;//1=obična učionica,2=računala,3=brza računala
        public int kapacitet;
        public int trenutnoVrijeme;
        public string raspored;
        public Dvorana(string naziv, int vrsta, int kapacitet)
        {
            this.naziv = naziv;
            this.vrsta = vrsta;
            this.kapacitet = kapacitet;
            this.trenutnoVrijeme = 8;
            this.raspored = "";
        }
    }
}
