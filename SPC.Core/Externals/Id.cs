﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core.Externals
{
    public class Id
    {
        #region Public Properties

        public string Key = "";

        public string Value = "";


        public bool Loaded = false;
        #endregion Public Properties

        #region Private Functions

        #region Private Functions - Constructors

        public Id() { }

        public Id(Id jObject) { Load(jObject); }


        #endregion Private Functions - Constructors

        #region Private Functions - Loaders

        private bool Load(Id jObject)
        {
            var bReturn = false;

            try
            {
                if (jObject != null)
                {
                    Key = jObject.Key;
                    Value = jObject.Value;

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
