using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpotifyAPI.Web.Models;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Auth;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;
using SpotifyAPI.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Xrm.Sdk.Messages;

namespace SPC.Web.WFInterface.Pages
{
    public partial class Playlists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Song_Search_Click(object sender, EventArgs e)
        {
            string strSongName = tb_Song_Name.Text.ToString();

            string strSongArtist = tb_Song_Artist.Text.ToString();

            string strUrl = string.Format("https://api.spotify.com/v1/search?q={0} {1}&type=track&market=US&;limit=3&offset=0", strSongName, strSongArtist); 

            string strJson = GetTrackInfo(strUrl);

            var lstTracks = Core.Tracks.Track.List(strJson);

            rpt_Tracks.DataSource = lstTracks;
            rpt_Tracks.DataBind();

            lstTracks = null;

        }
       
        protected void rpt_Tracks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                try
                {
                    Core.Tracks.Track objTrack = e.Item.DataItem as Core.Tracks.Track;

                    Literal lit_Name = e.Item.FindControl("lit_Name") as Literal;

                    lit_Name.Text = objTrack.Name.ToString();

                    Literal lit_Artists = e.Item.FindControl("lit_Artist") as Literal;

                    StringBuilder strArtists = new StringBuilder();

                    foreach (var vArtist in objTrack.lst_Artists)
                    {
                        strArtists.Append(vArtist.Name + ", ");
                    }

                    lit_Artists.Text = strArtists.ToString();

                    Literal lit_Album = e.Item.FindControl("lit_Album") as Literal;

                    lit_Album.Text = objTrack.Album.Name;

                    Literal lit_Image = e.Item.FindControl("lit_Image") as Literal;

                    string strUrl = objTrack.Album.lst_Images[0].Url.Replace( "\"", "");

                    lit_Image.Text = "<img src='" + strUrl + "' width='100' height='100' />";

                    lit_Image = null;
                    lit_Album = null;
                    lit_Artists = null;
                    lit_Name = null;
                    objTrack = null;
                }
                catch (Exception ex)
                {

                }
            }
        }

        public string GetAccessToken()
        {
            string strReturn = "";

            try
            {
                Models.SpotifyToken token = new Models.SpotifyToken();
                string url5 = "https://accounts.spotify.com/api/token";
                var clientid = "ce6d40cb2c4747d8b3b98936096025a3";
                var clientsecret = "d23b916d82904952a373d51201405459";

                //request to get the access token
                var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

                webRequest.Method = "POST";
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Accept = "application/json";
                webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);

                var request = ("grant_type=client_credentials");
                byte[] req_bytes = Encoding.ASCII.GetBytes(request);
                webRequest.ContentLength = req_bytes.Length;

                Stream strm = webRequest.GetRequestStream();
                strm.Write(req_bytes, 0, req_bytes.Length);
                strm.Close();

                HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                String json = "";
                using (Stream respStr = resp.GetResponseStream())
                {
                    using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                    {
                        //should get back a string i can then turn to json and parse for accesstoken
                        json = rdr.ReadToEnd();
                        rdr.Close();
                    }
                }
                token = JsonConvert.DeserializeObject<Models.SpotifyToken>(json);
                strReturn = token.access_token;
            }
            catch (Exception ex)
            {

            }

            return strReturn;
        }

        /// <summary>
        /// take the token, and use it to request a song ID
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string GetTrackInfo(string url)
        {
            string strWebResponse = string.Empty;

            string strMyToken = GetAccessToken();

            try
            {
                HttpClient hc = new HttpClient();

                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = HttpMethod.Get
                };

                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Authorization", "Bearer " + strMyToken);

                var task = hc.SendAsync(request)
                    .ContinueWith((taskwithmsg) =>
                    {
                        HttpResponseMessage hrmResponse = taskwithmsg.Result;
                        var tskJsonTask = hrmResponse.Content.ReadAsStringAsync();
                        strWebResponse = tskJsonTask.Result;
                    });
                task.Wait();
            } 
            catch (Exception ex)
            {

            }
            return strWebResponse;
        }
    }
}