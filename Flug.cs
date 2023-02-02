using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apm
{
    /// <summary>
    /// Flug.
    /// </summary>
    public class Flug
    {
        public int Flugnummer { get; set; }
        public string StartFlughafenCode { get; set; }
        public string ZielFlughafenCode { get; set; }
        public DateTime StartZeitpunkt { get; set; }
        public DateTime LandZeitpunkt { get; set; }


        /// <summary>
        /// Політ конструктора за замовчуванням
        /// </summary>
        /// <param name="flight number">Номер, за яким можна однозначно ідентифікувати рейс</param>
        public Flug(int flugnummer)
        {
            this.Flugnummer = flugnummer;
        }


        /// <summary>
        /// Розширений політ конструктора
        /// </summary>
        /// <param name="flight number">Номер, за яким можна однозначно ідентифікувати рейс</param>
        /// <param name="startFlughafenCode">Код IATA аеропорту відправлення</param>
        /// <param name="zielFlughafenCode">Код IATA аеропорту призначення</param>
        public Flug(int flugnummer, string startFlughafenCode, string zielFlughafenCode)
        {
            this.Flugnummer = flugnummer;
            this.StartFlughafenCode = startFlughafenCode;
            this.ZielFlughafenCode = zielFlughafenCode;
        }


        /// <summary>
        /// Повний політ конструктора
        /// </summary>
        /// <param name="flight number">Номер, за яким можна однозначно ідентифікувати рейс</param>
        /// <param name="startFlughafenCode">Код IATA аеропорту відправлення</param>
        /// <param name="zielFlughafenCode">Код IATA аеропорту призначення</param>
        /// <param name="startZeitpunkt">Час старту або повинен стартувати літак</param>
        /// <param name="landeZeitpunkt">Час приземлення або запланованої посадки літака</param>
        /// <rezyume>
        /// Povnyy polit konstruktora
        /// </summary>
        public Flug(int flugnummer, string startFlughafenCode, string zielFlughafenCode, 
            DateTime startZeitpunkt, DateTime landeZeitpunkt)
        {
            this.Flugnummer = flugnummer;
            this.StartFlughafenCode = startFlughafenCode;
            this.ZielFlughafenCode = zielFlughafenCode;
            this.StartZeitpunkt = startZeitpunkt;
            this.LandZeitpunkt = landeZeitpunkt;
        }


        /// <summary>
        /// Повертає тривалість польоту. Є стартом за часом
        /// після посадки створюється виняток.
        /// </summary>
        /// <returns>Проміжок часу польоту у форматі DAYS.HOURS:MINUTES:SECOUNDS</returns>
        public TimeSpan GetFlugdauer()
        {
            if (LandZeitpunkt.Subtract(StartZeitpunkt) < new TimeSpan(0))
                throw new ArgumentException();
            return LandZeitpunkt.Subtract(StartZeitpunkt);
        }
    }
}
