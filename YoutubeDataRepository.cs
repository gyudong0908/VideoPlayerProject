using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 유튜브프로젝트
{
    internal class YoutubeDataRepository     
    {
        private string connectionString = "Server=localhost;Database=master;Trusted_Connection=True;";
        private static YoutubeDataRepository instance = null;
        private YoutubeDataRepository(){}
        public static YoutubeDataRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new YoutubeDataRepository();
                }
                return instance;
            }
        }

        // 데이터 추가
        public void insertData(YoutubeData youtubeData)
        {

            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"INSERT into youtube (VideoId,EndTime,TotalTime,Image, Title, Channel, CategoriName) VALUES('{youtubeData.getVideoId()}','{youtubeData.getEndTime()}','{youtubeData.getTotalTime()}',@imageData, @title, '{youtubeData.getChannel()}', '{youtubeData.getCategoriName()}')";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    // 파라미터 추가
                    SqlParameter parameter = new SqlParameter("@title", System.Data.SqlDbType.NVarChar);
                    parameter.Value = youtubeData.getTitle();
                    cmd.Parameters.Add(parameter);
                    cmd.Parameters.AddWithValue("@ImageData", youtubeData.getImage()); // imageData는 byte[] 형식의 이미지 데이터
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
                connection.Close();
            }
        }
        // 데이터 불러오기
        public List<YoutubeData> readData(string categoriName)
        {
            List<YoutubeData> youtubeDatas = new List<YoutubeData>();
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"select * from youtube where CategoriName = '{categoriName}'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            YoutubeData youtubeData = new YoutubeData((string)reader["videoId"], (int)reader["EndTime"], (int)reader["TotalTime"], (byte[])reader["Image"], (string)reader["Title"], (string)reader["Channel"], (string)reader["CategoriName"]);
                            youtubeDatas.Add(youtubeData);
                        }
                    }
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
                connection.Close();
                return youtubeDatas;
            }

        }
        // 데이터 삭제
        public void deleteData(string videoId) 
        {
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"delete from youtube where videoId = '{videoId}'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }

                connection.Close();
            }

        }
        // 특정 카테고리 데이터 삭제
        public void deleteAll(string categoriName)
        {
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"delete from youtube where CategoriName = '{categoriName}'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
                connection.Close();
            }
        }
        // 카테고리 변경
        public void updateCategori(YoutubeData youtubeData, string categoriName)
        {
            // DB 연결
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string sql = $"update youtube set CategoriName = '{categoriName}' where videoId = '{youtubeData.getVideoId()}'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) // DB 연결 오류 발생
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }
                connection.Close();
            }

        }

        // 시청 시간 변경
        public void updateEndTime(string videoId, string endTime)
        {
            //// DB connection setting
            string[] part = endTime.Split('.');
            endTime = part[0];
            // connect DB
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // DB server enter
                    string sql = $"update youtube set EndTime = '{endTime}' where videoId = '{videoId}'";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) // DB connection failed
                {
                    MessageBox.Show("Error connecting to database: " + ex.Message);
                }

                // DB server connection exit
                connection.Close();
            }

        }
    }
}
