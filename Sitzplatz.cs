using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apm
{
    /// <summary>
    /// Сидіння є складовою частиною пасажирського літака
    /// можна призначити.
    /// </summary>
    public class Sitzplatz : IComponent
    {
        private ISite _curSitznummerSite;
        public event EventHandler Disposed;
        public string Sitznummer { get; set; }
        public string Befoerderungsklasse { get; set; }


        /// <summary>
        /// Конструктор сидінь
        /// </summary>
        /// <param name="sitznummer">Номер, за яким можна чітко ідентифікувати місце</param>
        /// <param name="carriage class">Клас вагона, у якому розташоване місце</param>
        public Sitzplatz(string sitznummer, string befoerderungsklasse)
        {
            this.Sitznummer = sitznummer;
            this.Befoerderungsklasse = befoerderungsklasse;
        }


        /// <summary>
        /// Видаляє об'єкт сидіння.
        /// </summary>
        public virtual void Dispose()
        {
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
        }


        /// <summary>
        /// Повертає або встановлює об'єкт сайту
        /// </summary>
        public virtual ISite Site
        {
            get
            {
                return _curSitznummerSite;
            }
            set
            {
                _curSitznummerSite = value;
            }
        }


        /// <summary>
        /// Порівняти два об'єкти сидіння між собою.
        /// </summary>
        /// <param name="cmp">Об'єкт сидіння для порівняння</param> 
        public override bool Equals(object cmp)
        {
            Sitzplatz cmpObj = (Sitzplatz)cmp;
            if (this.Sitznummer.Equals(cmpObj.Sitznummer) && 
                this.Befoerderungsklasse.Equals(cmpObj.Befoerderungsklasse))
                return true;

            return false;
        }


        /// <summary>
        /// Повертає хеш-код об'єкта seat.
        /// </summary> 
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
