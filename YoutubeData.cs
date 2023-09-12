using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace 유튜브프로젝트
{
    public class YoutubeData
    {
        private string videoId;
        private int endTime;
        private int totalTime;
        private byte[] image;
        private string title;
        private string channel;
        private string categoriName;
        public YoutubeData(string videoId, int endTime, int totalTime, byte[] image, string title, string channel, string categoriName) 
        {
            this.videoId = videoId;
            this.endTime = endTime;
            this.totalTime = totalTime;
            this.image = image;
            this.title = title;
            this.channel = channel;
            this.categoriName = categoriName;
        }
        public string getVideoId(){ return videoId; }
        public int getEndTime() { return endTime; }
        public int getTotalTime() { return totalTime;}
        public byte[] getImage() { return image; }
        public string getTitle() { return title; }
        public string getChannel() { return channel; }
        public string getCategoriName() { return categoriName; }
    }
}
