using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core.Images
{
    public class Image
    {
        public int Height  = 0;

        public string Url = "";

        public int Width = 0;

        public bool Loaded = false;

        #region Private Functions

        #region Private Functions - Constructors

        public Image() { }

        public Image(Image jObject) { Load(jObject); }


        #endregion Private Functions - Constructors

        #region Private Functions - Loaders

        private bool Load(Image jObject)
        {
            var bReturn = false;

            try
            {
                if (jObject != null)
                {
                    Height = jObject.Height;
                    Url = jObject.Url;
                    Width = jObject.Width;

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
