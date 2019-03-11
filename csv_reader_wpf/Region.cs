using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csv_reader_wpf
{ 
    /// <summary>
    /// класс представляющий информацию об округе
    /// </summary>
    public class Region
    {
        /// <summary>
        /// конструктор округа
        /// </summary>
        /// <param name="admArea">название округа</param>
        /// <param name="district">название района</param>
        public Region(string admArea, string district)
        {
            AdmArea = admArea;
            District = district;
        }
        /// <summary>
        /// свойство округ
        /// </summary>
        public string AdmArea { get; set; }
        /// <summary>
        /// свойство район
        /// </summary>
        public string District { get; set; }
        

        /// <summary>
        /// перегруженный оператор для сравнения равенства округов
        /// </summary>
        /// <param name="rg1">левый операнд</param>
        /// <param name="rg2">правый операнд</param>
        /// <returns></returns>
        public static bool operator ==(Region rg1, Region rg2)
        {
            return rg1.AdmArea.Equals(rg2.AdmArea) && rg1.District.Equals(rg2.District); 
        }
        /// <summary>
        /// перегруженный оператор для сравнения неравенства округов
        /// </summary>
        /// <param name="rg1">левый операнд</param>
        /// <param name="rg2">правый операнд</param>
        /// <returns></returns>
        public static bool operator !=(Region rg1, Region rg2)
        {
            return !(rg1.AdmArea.Equals(rg2.AdmArea) && rg1.District.Equals(rg2.District));
        }
    }
}
