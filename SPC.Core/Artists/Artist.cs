using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core.Artists
{
    public class Artist
    {

        #region Public Properties

        public List<Externals.Url> lst_Externalurls = new List<Externals.Url>();

        public string Href = "";

        public string Id = "";

        public string Name = "";

        public string Type = "";

        public string URI = "";

        public bool Loaded = false;

        #endregion Public Properties

        #region Private Functions

        #region Private Functions - Constructors

        /// <summary>
        ///  only this constructor runs
        /// </summary>
        public Artist() { }

        public Artist(Artist jObject) { Load(jObject); }

        public Artist(string strJson)
        {

        }

        #endregion Private Functions - Constructors

        #region Private Functions - Loaders

        private bool Load(Artist jObject)
        {
            var bReturn = false;

            try
            {
                if (jObject != null)
                {
                    lst_Externalurls = jObject.lst_Externalurls;
                    Href = jObject.Href;
                    Id = jObject.Id;
                    Name = jObject.Name;
                    Type = jObject.Type;
                    URI = jObject.URI;

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
