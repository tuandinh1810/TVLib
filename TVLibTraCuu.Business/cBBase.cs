using System;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLibTraCuu.Business
{
    public class cBBase
    {
        protected string mErrorMessage;
        protected int mErrorNumber;

        public int ErorrNumber
        {
            get
            {
                return mErrorNumber;
            }
        }

        public string ErrorMessages
        {
            get
            {
                return mErrorMessage;
            }
        }        
    }
}
