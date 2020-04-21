using Newtonsoft.Json.Linq;
using SPC.Core.Artists;
using SPC.Core.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core.Album
{
    public class Album
    {

        #region Public Properties

        public string AlbumGroup = "";

        public string AlbumType = "";


        public List<Core.Artists.Artist> lst_Artists = new List<Core.Artists.Artist>();


        public List<string> lst_AvailableMarkets = new List<string>();


        public Core.Externals.Url objExternalUrls = new Core.Externals.Url();


        public string Href = "";


        public string Id = "";


        public List<Core.Images.Image> lst_Images = new List<Images.Image>();


        public string Name = "";


        public string Release_Date = "";


        public string Release_Date_Precision = "";


        public string Type = "";


        public string Uri = "";


        public bool Loaded = false;


        #endregion Public Properties

        #region Private Functions

        #region Private Functions - Constructors

        public Album() { }

        public Album(Album jObject) { Load(jObject); }

        public static Album Load(JToken Album)
        {
            Core.Album.Album objReturn = new Core.Album.Album();

            objReturn.AlbumType = Album.SelectToken("album_type").ToString();

            Core.Artists.Artist[] arrArtists = Album.SelectToken("artists").ToObject<Artist[]>();
            objReturn.lst_Artists = arrArtists.ToList();

            //string[] lstAvailableMarkets = Album.SelectToken("available_markets").ToArray<string>();
            //objReturn.lst_AvailableMarkets = .ToList;

            objReturn.objExternalUrls = Album.SelectToken("external_urls").ToObject<Core.Externals.Url>();
            objReturn.Href = Album.SelectToken("href").ToString();
            objReturn.Id = Album.SelectToken("id").ToString();

            Core.Images.Image[] arrImages = Album.SelectToken("images").ToObject<Image[]>();
            objReturn.lst_Images = arrImages.ToList();

            objReturn.Name = Album.SelectToken("name").ToString();
            objReturn.Release_Date = Album.SelectToken("release_date").ToString();
            objReturn.Release_Date_Precision = Album.SelectToken("release_date_precision").ToString();
            objReturn.Type = Album.SelectToken("type").ToString();
            objReturn.Uri = Album.SelectToken("uri").ToString();

            return objReturn;
        }

        #endregion Private Functions - Constructors

        #region Private Functions - Loaders

        private bool Load(Album jObject)
        {
            var bReturn = false;

            try
            {
                if (jObject != null)
                {
                    AlbumType = jObject.AlbumType;
                    lst_Artists = jObject.lst_Artists;
                    lst_AvailableMarkets = jObject.lst_AvailableMarkets;
                    objExternalUrls = jObject.objExternalUrls;
                    Href = jObject.Href;
                    Id = jObject.Id;
                    lst_Images = jObject.lst_Images;
                    Name = jObject.Name;
                    Release_Date = jObject.Release_Date;
                    Release_Date_Precision = jObject.Release_Date_Precision;
                    Type = jObject.Type;
                    Uri = jObject.Uri;

                    Loaded = true;
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {

            }

            return bReturn;
        }

        #endregion Private Functions - Loaders

        #endregion Private Functions
    }
}
