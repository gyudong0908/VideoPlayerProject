using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Data.SqlClient;
using CefSharp.DevTools.Memory;
using System.Threading;

namespace 유튜브프로젝트
{
    public partial class Player : Form
    {
        public ChromiumWebBrowser webBrowser;
        public string videoId;
        public int startTime;
        private bool isColosing = false;
        YoutubeDataRepository youtubeDataRepository = YoutubeDataRepository.Instance;

        public Player()
        {
            InitializeComponent();
            // ChromiumWebBrowser 컨트롤 생성 및 설정
            webBrowser = new ChromiumWebBrowser();
            webBrowser.Dock = DockStyle.Fill;
            Controls.Add(webBrowser);
        }

        private async void Player_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isColosing)
            {
                e.Cancel = true;
                // YouTube 플레이어의 현재 재생 시간 정보 가져오기
                string timeScript = @"var player = document.getElementById('movie_player');
                                  player.getCurrentTime();";
                var response = await webBrowser.EvaluateScriptAsync(timeScript);
                if (response.Success && response.Result != null)
                {
                    // currentTime 변수에 재생 시간이 저장됩니다.                
                    update(response.Result.ToString());
                }
                e.Cancel = false;
                isColosing = true;
                this.Close();
            }
        }

        private void Player_Load(object sender, EventArgs e)
        {
            string url = $"https://www.youtube.com/embed/{videoId}?start={startTime}&autoplay=1";
            webBrowser.Load(url);
        }
        public void update(string endTime)
        {
            youtubeDataRepository.updateEndTime(videoId, endTime);
        }
    }
}
