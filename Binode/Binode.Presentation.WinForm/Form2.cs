using Binode.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binode.Presentation.WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = Application.OpenForms["Form1"] as Form1;
            string title = txtBaslik.Text;
            Icerik ekle = new Icerik();
            ekle.Tip = IcerikTipi.Metin;
            ekle.Content = rtbMetin.Text;

            TreeNode t = f1.treeKategori.SelectedNode;
            var kategoriler = DemoData.DemoKategoriGetir();
            // f1.KategoriyiTreeviewAEkle(kategoriler, null);
            foreach (var kategori in kategoriler)
            {
                if (t.Text == kategori.Isim)
                {
                    kategori.Icerik = new List<Icerik>
                    {
                        new Icerik { Isim= title, EklenmeTarihi = DateTime.Now, Kategori = kategori},
                        
                    };
                    f1.ListViewDoldur(t);
                    break;
                }
                for (int i = 0; i < kategori.AltKategori.Count; i++)
                {
                    if (t.Text==kategori.AltKategori[i].Isim)
                    {
                        kategori.AltKategori[i].Icerik = new List<Icerik>
                        {
                            new Icerik { Isim= title, EklenmeTarihi = DateTime.Now, Kategori = kategori.AltKategori[i]},

                        
                        };
                        f1.ListViewDoldur(t);
                        break;

                    }
                    if (kategori.AltKategori[i].AltKategori ==null)
                    {
                        return;
                    }
                    for (int j = 0; j < kategori.AltKategori[i].AltKategori.Count; j++)
                    {
                        if (t.Text==kategori.AltKategori[i].AltKategori[j].Isim)
                        {
                            kategori.AltKategori[i].AltKategori[j].Icerik = new List<Icerik>
                            {
                                new Icerik { Isim= title, EklenmeTarihi = DateTime.Now, Kategori = kategori.AltKategori[i].AltKategori[j]},

                        
                            };
                            f1.ListViewDoldur(t);
                            break;

                        }
                    }

                }
                
                
            }
           
            this.Hide();
            f1.Show();
        }
    }
}
