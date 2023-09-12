using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 유튜브프로젝트
{
    public partial class ItempanelControl : UserControl
    {
        public ArrayList categoriNames;
        public YoutubeData youtubeData;
        public delegate void ItempanelControlHandler(ItempanelControl itempanel);
        public ItempanelControlHandler removeHandler;
        public ItempanelControlHandler replaceHandler;
        public string ComboCategoriText;

        public ItempanelControl(YoutubeData youtubeData, ArrayList categoriNames)
        {
            InitializeComponent();
            this.categoriNames = categoriNames; 
            this.youtubeData = youtubeData;
            lblTitle.Text = youtubeData.getTitle();
            lblChanelName.Text = youtubeData.getChannel();

            lblProgress.Size = new Size(200, 10);
            lblProgress.BackColor = Color.Gray;
            lblProgress.AutoSize = false;

            Panel panelProgress = new Panel();
            panelProgress.Size = new Size((youtubeData.getEndTime() *200 / youtubeData.getTotalTime()),10);
            panelProgress.BackColor = Color.Black;
            lblProgress.Controls.Add(panelProgress);
            lblProgressPercent.Text = (youtubeData.getEndTime() *100 /  youtubeData.getTotalTime()) + "%";

            foreach (var categoriName in categoriNames)
            {
                comboCategori.Items.Add(categoriName);
            }

            using (MemoryStream ms = new MemoryStream(youtubeData.getImage()))
            {
                Image image = Image.FromStream(ms);
                Thumbnail.Image = image;
            }
            Thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            lblBorder.BackColor = Color.Black;
            lblBorder.Dock = DockStyle.Bottom;
            lblBorder.Width = 772;
            lblBorder.Height = 2;
            lblBorder.AutoSize = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeHandler(this);
        }

        private void Thumbnail_Click(object sender, EventArgs e)
        {
            Player playerForm = new Player();
            playerForm.videoId = youtubeData.getVideoId();
            playerForm.startTime = youtubeData.getEndTime();
            playerForm.Show();
        }

        private void btnChangeCategori_Click(object sender, EventArgs e)
        {
            ComboCategoriText = comboCategori.Text;
            replaceHandler(this);
        }
    }
}
