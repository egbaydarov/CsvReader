using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace csv_reader_wpf
{
    public class IncorrectCinemaDataException : Exception
    {
        public IncorrectCinemaDataException()
        {
        }

        public IncorrectCinemaDataException(string message) : base(message)
        {
        }

        public IncorrectCinemaDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IncorrectCinemaDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    public class Cinema
    {
        public Cinema()
        {

        }
        public Cinema(List<string> columns, Region region)
        {
            this.region = region;
            for (int i = 0; i < 21; i++)
                this[i] = columns[i];
        }
        public GridViewModel ToGridView
        {
            get
            {
                return new GridViewModel(this);
            }
        }
        public static void IsValid(string data)
        {
            if (data.Count(x => x == ';') % 23 != 0)
                throw new IncorrectCinemaDataException("Incorrect data in cells for save/load.");
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
                        return Address;
                    case 6:
                        return ChiefName;
                    case 7:
                        return ChiefPosition;
                    case 8:
                        return PublicPhone;
                    case 9:
                        return Fax;
                    case 10:
                        return Email;
                    case 11:
                        return WorkingHours;
                    case 12:
                        return ClarificationOfWorkingHours;
                    case 13:
                        return WebSite;
                    case 14:
                        return OKPO;
                    case 15:
                        return INN;
                    case 16:
                        return NumberOfHalls;
                    case 17:
                        return TotalSeatsAmount;
                    case 18:
                        return X_WGS;
                    case 19:
                        return Y_WGS;
                    case 20:
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
                        Address = value;
                        break;
                    case 6:
                        ChiefName = value;
                        break;
                    case 7:
                        ChiefPosition = value;
                        break;
                    case 8:
                        PublicPhone = value;
                        break;
                    case 9:
                        Fax = value;
                        break;
                    case 10:
                        Email = value;
                        break;
                    case 11:
                        WorkingHours = value;
                        break;
                    case 12:
                        ClarificationOfWorkingHours = value;
                        break;
                    case 13:
                        WebSite = value;
                        break;
                    case 14:
                        OKPO = value;
                        break;
                    case 15:
                        INN = value;
                        break;
                    case 16:
                        NumberOfHalls = value;
                        break;
                    case 17:
                        TotalSeatsAmount = value;
                        break;
                    case 18:
                        X_WGS = value;
                        break;
                    case 19:
                        Y_WGS = value;
                        break;
                    case 20:
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
        public Region region { get; set; }
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
    }

}
