using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace csv_reader_wpf
{
    /// <summary>
    /// класс исключений возникающих при работе с объектами кинотеатра
    /// </summary>
    public class IncorrectCinemaDataException : Exception
    {
        /// <summary>
        /// Конструктор исключения без параметров
        /// </summary>
        public IncorrectCinemaDataException()
        {
        }
        /// <summary>
        /// Конструктор исключения с сообщением
        /// </summary>
        /// <param name="message"></param>
        public IncorrectCinemaDataException(string message) : base(message)
        {
        }
        /// <summary>
        /// Конструктор исключения с сообщением  и унаследованным типом исключения
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public IncorrectCinemaDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// конструктор исключения с информацией о сериализации и контекстным потоком
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected IncorrectCinemaDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    /// <summary>
    /// класс представляющий кинотеатр
    /// </summary>
    public class Cinema
    {
        /// <summary>
        /// конструктор без параметров
        /// </summary>
        public Cinema()
        {

        }
        /// <summary>
        /// конструктор коасса кинотеатра состоящего в отношении агрегации с классом округа
        /// </summary>
        /// <param name="columns">массив строк - ячеек столбцов кинотеатра</param>
        /// <param name="region">экземпляр округа</param>
        public Cinema(List<string> columns, Region region)
        {
            this.region = region;
            for (int i = 0; i < 21; i++)
                this[i] = columns[i];
        }
        /// <summary>
        /// возвращает экзеимпляр кинотеатра в вие модели для таблицы Grid View
        /// </summary>
        public GridViewModel ToGridView
        {
            get
            {
                return new GridViewModel(this);
            }
        }
        /// <summary>
        /// проверка строки на валидность для создания экземпляра кинотеатр
        /// </summary>
        /// <param name="data">входная строка</param>
        public static void IsValid(string data)
        {
            if (data.Count(x => x == ';') % 23 != 0)
                throw new IncorrectCinemaDataException("Incorrect data in cells for save/load.");
        }
        /// <summary>
        /// проиндексированные значения для столбцов таблицы
        /// </summary>
        /// <param name="index">индекс столбца</param>
        /// <returns>строковое представление ячейки столбца</returns>
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
        /// <summary>
        /// Поле с информацие об округе кинотеатра
        /// </summary>
        public Region region { get; set; }
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
    }

}
