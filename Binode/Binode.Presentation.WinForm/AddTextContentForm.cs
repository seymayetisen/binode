using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binode.Data.Model;

namespace Binode.Presentation.WinForm
{
    public partial class AddTextContentForm : Form
    {
        
        public AddTextContentForm()
        {
            InitializeComponent();
        }

        //Add Text Content = Metin içerik ekle
        private void AddTextContent_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BinodeMainForm f1 = Application.OpenForms["BinodeMainForm"] as BinodeMainForm;
            
            var Kategori = f1._rightClicknode.Tag as Kategori;
            var yeniIcerik = new Icerik
            {
                Isim = txtTitle.Text,
                EklenmeTarihi = DateTime.Now,
                Kategori=Kategori,
                Tip=IcerikTipi.Metin,
                Content = txtContent.Text
                
            };
            
            Kategori.Icerik.Add(yeniIcerik);
           
            this.Hide();
        }
    }
}
