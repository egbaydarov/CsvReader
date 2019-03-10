using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_reader_wpf
{
    public class GridViewModel
    {
        public GridViewModel(Cinema cinema)
        {
            for (int i = 0; i < 5; i++)
                this[i] = cinema[i];
            this[5] = cinema.region.District;
            this[6]= cinema.region.AdmArea;
            for (int i = 7; i < 23; i++)
            {
                this[i] = cinema[i - 2];
            }
        }
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return ROWNUM;
                    case 1:
                        return CommonName;
                    case 2:
                        return FullName;
                    case 3:
                        return ShortName;
                    case 4:
                        return ChiefOrg;
                    case 5:
                        return AdmArea;
                    case 6:
                        return District;
                    case 7:
                        return Address;
                    case 8:
                        return ChiefName;
                    case 9:
                        return ChiefPosition;
                    case 10:
                        return PublicPhone;
                    case 11:
                        return Fax;
                    case 12:
                        return Email;
                    case 13:
                        return WorkingHours;
                    case 14:
                        return ClarificationOfWorkingHours;
                    case 15:
                        return WebSite;
                    case 16:
                        return OKPO;
                    case 17:
                        return INN;
                    case 18:
                        return NumberOfHalls;
                    case 19:
                        return TotalSeatsAmount;
                    case 20:
                        return X_WGS;
                    case 21:
                        return Y_WGS;
                    case 22:
                        return GLOBALID;
                    
                    default:
                        throw new ArgumentOutOfRangeException("Index of column was out of range.");
                }
            }
            set
            {
                switch (index)
                {

                    case 0:
                        ROWNUM = value;
                        break;
                    case 1:
                        CommonName = value;
                        break;
                    case 2:
                        FullName = value;
                        break;
                    case 3:
                        ShortName = value;
                        break;
                    case 4:
                        ChiefOrg = value;
                        break;
                    case 5:
                        AdmArea = value;
                        break;
                    case 6:
                        District = value;
                        break;
                    case 7:
                        Address = value;
                        break;
                    case 8:
                        ChiefName = value;
                        break;
                    case 9:
                        ChiefPosition = value;
                        break;
                    case 10:
                        PublicPhone = value;
                        break;
                    case 11:
                        Fax = value;
                        break;
                    case 12:
                        Email = value;
                        break;
                    case 13:
                        WorkingHours = value;
                        break;
                    case 14:
                        ClarificationOfWorkingHours = value;
                        break;
                    case 15:
                        WebSite = value;
                        break;
                    case 16:
                        OKPO = value;
                        break;
                    case 17:
                        INN = value;
                        break;
                    case 18:
                        NumberOfHalls = value;
                        break;
                    case 19:
                        TotalSeatsAmount = value;
                        break;
                    case 20:
                        X_WGS = value;
                        break;
                    case 21:
                        Y_WGS = value;
                        break;
                    case 22:
                        GLOBALID = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Index of column was out of range.");
                }
            }
        }
        #region Columns
        public string ROWNUM { get; set; }
        public string CommonName { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string ChiefOrg { get; set; }
        public string AdmArea { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string ChiefName { get; set; }
        public string ChiefPosition { get; set; }
        public string PublicPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WorkingHours { get; set; }
        public string ClarificationOfWorkingHours { get; set; }
        public string WebSite { get; set; }
        public string OKPO { get; set; }
        public string INN { get; set; }
        public string NumberOfHalls { get; set; }
        public string TotalSeatsAmount { get; set; }
        public string X_WGS { get; set; }
        public string Y_WGS { get; set; }
        public string GLOBALID { get; set; }
        #endregion
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < 23; i++)
                res += this[i] + ";"; 
            res += "\r\n";
            return res;
        }
    }

}
