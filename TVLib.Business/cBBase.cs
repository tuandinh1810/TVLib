using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TruongViet.TVLib.Business
{
    public class cBBase
    {
        protected string mErrorMessage;
        protected int mErrorNumber;
        protected string  mBodyContent; 
        protected ArrayList mArrDataField;

        public string BodyContent
        {
            get { return mBodyContent; }
            set { mBodyContent = value; }
        }

        public ArrayList ArrFieldDataField
        {
            get { return mArrDataField; }
            set { mArrDataField = value; }
        }
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
        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            string result = "";
            if (param != "")
            {
                result = param.Substring(0, length);
            }
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = "";
            if (param != "")
            {
                result = param.Substring(param.Length - length, length);
            }
            //return the result of the operation
            return result;
        }
        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }
       
   	 private string GetQuote(string BContent)
	 {
       
        string strResult = "";
        if ((BContent.IndexOf("<$") >= 0 & BContent.IndexOf("$>", BContent.IndexOf("<$")) > 0)) 
        {
         strResult = BContent.Substring(BContent.IndexOf("<$") + 2, BContent.IndexOf("$>", BContent.IndexOf("$>")) - BContent.IndexOf("<$") - 2);
        }
        return strResult;
  }
     public object GetFields()
     {
         string AContent = "";
         int i = 0;
         string BodyContents = BodyContent;
         string[] arrAContents=null;

         while ((BodyContents.IndexOf("<$") != -1))
         {
            Array.Resize(ref arrAContents, i + 1);
            // arrAContents[i] = new arrAContents[];
             arrAContents[i] = GetQuote(BodyContents);
             if (arrAContents[i]+""=="")
             {
                 break; // TODO: might not be correct. Was : Exit While
             }
             else
             {
                 BodyContents = BodyContents.Substring(BodyContents.IndexOf("$>", BodyContents.IndexOf("<$")) + 2, BodyContents.Length - BodyContents.IndexOf("$>", BodyContents.IndexOf("<$")) - 2);
                 i = i + 1;
             }
         }
         return arrAContents;
     }
     public object FillDataInto_Body()
     {
         string AContent = "";
         int i = 0;

         string BodyContents = BodyContent;
         string[] arrAContents=null;
         while ((BodyContents.IndexOf("<$") != -1))
         {
             Array.Resize(ref arrAContents, i + 1);

             arrAContents[i] = GetQuote(BodyContents);
             if (arrAContents[i]+""=="")
             {
                 break; // TODO: might not be correct. Was : Exit While
             }
             else
             {
                 BodyContents = BodyContents.Substring(BodyContents.IndexOf("$>", BodyContents.IndexOf("<$")) + 2, BodyContents.Length - BodyContents.IndexOf("$>", BodyContents.IndexOf("<$")) - 2);
                 BodyContent = BodyContent.Replace("<$" + arrAContents[i].ToString() + "$>", mArrDataField[1].ToString());

                 i = i + 1;
             }
         }
         return BodyContent;
     }
    }
}
