using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Windows.Forms;
using Google.Apis.Services;
using CefSharp.WinForms;
using CefSharp;
using MySql.Data.MySqlClient;
using System.Configuration;
using CefSharp.DevTools.Database;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Collections;
using System.Xml;
using System.Windows.Forms.VisualStyles;
using CefSharp.DevTools.CSS;

namespace 유튜브프로젝트
{
    public partial class mainForm : Form
    {
        
        private string apiKey = "API_KEY";
        string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        private int itemPanelY = 0;
        public string CategoriName;
        public ArrayList catetegoriNames = new ArrayList();
        public bool isLoding = false;
        public CategoriForm CategoriForm;
        private int sumEndTime = 0;
        private int sumTotalTime = 0;
        private YoutubeDataRepository youtubeDataRepository = YoutubeDataRepository.Instance;

        public mainForm()
        {

            InitializeComponent();
        }
        public mainForm getReturnForm1()
        {
            return this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // CefSharp 초기화
            CefSettings settings = new CefSettings();
            // 웹을 열었을때, 오디오 또는 비디오가 자동으로 재생되는 것을 설정
            settings.CefCommandLineArgs.Add("autoplay-policy", "no-user-gesture-required");
            Cef.Initialize(settings);
            isLoding = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isLoding = false;
            Cef.Shutdown();
        }

        public void ReadItem()
        {
            List<YoutubeData> datas =  youtubeDataRepository.readData(CategoriName);
            foreach(var data in datas)
            {
                setPictureList(data);
            }
        }

        public void Insert(YoutubeData youtubeData)
        {
            youtubeDataRepository.insertData(youtubeData);
        }

        static string GetYouTubeVideoId(string url)
        {
            // 정규식
            string pattern = @"(?:\?v=|\/embed\/|\/\d\/|\/v\/|https?:\/\/(?:www\.)?youtube\.com\/v\/|https?:\/\/(?:www\.)?youtu\.be\/)([a-zA-Z0-9_\-]{11})";
            Match match = Regex.Match(url, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return null;
        }

        public void remove(ItempanelControl itempanelControl)
        {
            DialogResult result = MessageBox.Show("정말로 삭제 하시겠습니까?", "알림", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                mainPanel.Controls.Remove(itempanelControl);
                youtubeDataRepository.deleteData(itempanelControl.youtubeData.getVideoId());
                refresh();
            }
        }

        public void setPictureList(YoutubeData youtubeData)
        {
            sumEndTime += youtubeData.getEndTime();
            sumTotalTime += youtubeData.getTotalTime();
            ItempanelControl itempanelControl = new ItempanelControl(youtubeData, catetegoriNames);
            itempanelControl.Location = new Point(0, itemPanelY);
            mainPanel.Controls.Add(itempanelControl);
            itempanelControl.removeHandler += remove;
            itempanelControl.replaceHandler += replaceCategori;
            itemPanelY += 150;
        }
        public void replaceCategori(ItempanelControl itempanelControl)
        {
            youtubeDataRepository.updateCategori(itempanelControl.youtubeData,itempanelControl.ComboCategoriText);
            refresh();
        }

        public void SerchYouTubeVideo(string videoId)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey
            });

            // 동영상 검색 실행
            var searchRequest = youtubeService.Videos.List("snippet, contentDetails");
            searchRequest.Id = videoId;
            var searchResponse = searchRequest.Execute();

            foreach (var searchResult in searchResponse.Items)
            {
                string url = searchResult.Snippet.Thumbnails.Medium.Url;
                string duration = searchResult.ContentDetails.Duration;
                string titile = searchResult.Snippet.Title;
                string channel = searchResult.Snippet.ChannelTitle;
                int durationTime = (int) XmlConvert.ToTimeSpan(duration).TotalSeconds;

                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    YoutubeData searchYoutubedata = new YoutubeData(videoId, 0, durationTime, imageData, titile, channel, CategoriName);
                    Insert(searchYoutubedata); //db에 추가
                    setPictureList(searchYoutubedata);
                }
            }
        }

        public void refresh()
        {
            sumEndTime = 0;
            sumTotalTime = 0;
            itemPanelY = 0;
            mainPanel.Controls.Clear();
            labelCategori.Text = CategoriName;
            ReadItem();
            if(sumTotalTime == 0)
            {
                labelAchieve.Text = "달성률: 0%";
            }
            else
            {
                labelAchieve.Text = "달성률: "+ (sumEndTime * 100 / sumTotalTime ).ToString() + "%";
            }            
        }

        // 버튼 클릭 이벤트
        private void btnInsert_Click(object sender, EventArgs e)
        {
            UrlInputForm inputForm = new UrlInputForm();
            DialogResult result = inputForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string inputValue = inputForm.getUrl();
                SerchYouTubeVideo(GetYouTubeVideoId(inputValue)); //youtube api로 검색
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnChangeCategori_Click(object sender, EventArgs e)
        {
            CategoriForm.Show();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            youtubeDataRepository.deleteAll(CategoriName);
            refresh();
        }

    }
}
