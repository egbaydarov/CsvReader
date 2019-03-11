using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_reader_wpf
{
    /// <summary>
    /// класс описывающий модель данных для таблицы Grid View
    /// </summary>
    public class GridViewModel
    {
        /// <summary>
        /// конструктор экземпляра модели
        /// </summary>
        /// <param name="cinema">данные о кинотеатре</param>
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
        /// <summary>
        /// индексатор для столбцов таблицы
        /// </summary>
        /// <param name="index">номер столбца 0 - 22</param>
        /// <returns>ячейку соответствующего столбца</returns>
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
        /// <summary>
        /// Номер столбца
        /// </summary>
        public string ROWNUM { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string CommonName { get; set; }
        /// <summary>
        /// полное имя
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// сокращенное имя
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Главная организация
        /// </summary>
        public string ChiefOrg { get; set; }
        /// <summary>
        /// Административный округ
        /// </summary>
        public string AdmArea { get; set; }
        /// <summary>
        /// Район
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// Адресс
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Имя главного
        /// </summary>
        public string ChiefName { get; set; }
        /// <summary>
        /// Должность главного
        /// </summary>
        public string ChiefPosition { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string PublicPhone { get; set; }
        /// <summary>
        /// Факс
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// График работы
        /// </summary>
        public string WorkingHours { get; set; }
       /// <summary>
       /// Clarification of Working Hours
       /// </summary>
        public string ClarificationOfWorkingHours { get; set; }
        /// <summary>
        /// Веб-сайт
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// OKPO
        /// </summary>
        public string OKPO { get; set; }
        /// <summary>
        /// INN
        /// </summary>
        public string INN { get; set; }
        /// <summary>
        /// Количество помещений
        /// </summary>
        public string NumberOfHalls { get; set; }
        /// <summary>
        /// Количество сидячих мест
        /// </summary>
        public string TotalSeatsAmount { get; set; }
        /// <summary>
        /// какая-то цифра
        /// </summary>
        public string X_WGS { get; set; }
        /// <summary>
        /// какая-то цифра 2
        /// </summary>
        public string Y_WGS { get; set; }
        /// <summary>
        /// Глобальный идентификатор
        /// </summary>
        public string GLOBALID { get; set; }
        #endregion
        /// <summary>
        /// переопределенный ToString для строки таблицы
        /// </summary>
        /// <returns>строковое представление строки таблица в формате csv</returns>
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
