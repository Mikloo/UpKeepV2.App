using System;

namespace UpKeepV2.App.Models
{
    public class MedarbejderInfo
    {
        //public int Medarbejder_InfoID
        //{
        //    get
        //    {
        //        Guid ko = ToGuid(Medarbejder_InfoID);
        //        return ko;
        //    }
        //    set { Medarbejder_InfoID = value; }
        //}
        public int Medarbejder_InfoID { get; set; }
        public string WindowsID { get; set; }
        public string Navn { get; set; }
        public string EmailAdresse { get; set; }
        public int MobilNummer { get; set; }
        public int Lokalitet_InfoID { get; set; }

        //public static Guid ToGuid(int value)
        //{
        //    byte[] bytes = new byte[16];
        //    BitConverter.GetBytes(value).CopyTo(bytes, 0);
        //    return new Guid(bytes);
        //}

        
    }
}
