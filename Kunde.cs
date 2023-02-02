using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apm
{
    /// <summary>
    /// Клієнт – це компонент, який призначається до бази клієнтів
    /// може. Він успадковує від людини.
    /// </summary>
    public class Kunde : Person, IComponent, IEquatable<Kunde>
    {
        private ISite _curKundennummerSite;
        public event EventHandler Disposed;
        public int Kundennummer { get; set; }
        public enum Stati { unbekannt, Flug_gebucht, eingecheckt, eingecheckt_und_Gepäck_abgegeben, 
            Sicherheitskontrolle_erfolgreich_durchlaufen, Sicherheitskontrolle_fehlgeschlagen, an_Bord,
            Flug_storniert
        };

        public Stati Status { get;  set; }

        public Sitzplatz Sitz { get; set; }



        /// <summary>
        /// замовник конструктора
        /// </summary>
        /// <param name="customer number">Номер, за яким можна чітко ідентифікувати клієнта</param>
        /// <param name="status">Поточний статус обслуговування рейсу, в якому перебуває клієнт</param>
        /// <param name="first name">Ім'я клієнта</param>
        /// <param name="lastname">Прізвище клієнта</param>
        /// <param name="birthdate">Дата народження клієнта</param>
        /// <param name="gender">Стать клієнта</param>
        /// <param name="phone number">Номер телефону клієнта</param>
        /// <param name="emailAddress">Електронна адреса клієнта</param>
        /// <param name="nationality">Національність клієнта</param>
        /// <param name="street">Вулиця, де живе клієнт</param>
        /// <param name="house number">Номер будинку, в якому проживає клієнт</param>
        /// <param name="zip">Поштовий індекс або поштовий індекс міста клієнта</param>
        /// <param name="residence">Місце проживання клієнта</param>
        /// <param name="country">Країна, у якій проживає клієнт</param>
        public Kunde(int kundennummer, Stati status, string vorname, string nachname, 
            DateTime geburtsdatum, Geschlechter geschlecht, long telefonnummer, 
            string emailAdresse, string staatsbuergerschaft, string strasse,
            string hausnummer, int zip, string wohnort, string land)
        {
            Kundennummer = kundennummer;
            Status = status;
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;
            Geschlecht = geschlecht;
            Telefonnummer = telefonnummer;
            EMailAdresse = emailAdresse;
            Staatsbuergerschaft = staatsbuergerschaft;
            Strasse = strasse;
            Hausnummer = hausnummer;
            Zip = zip;
            Wohnort = wohnort;
            Land = land;
        }


        /// <summary>
        /// Видаляє об'єкт клієнта.
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
                return _curKundennummerSite;
            }
            set
            {
                _curKundennummerSite = value;
            }
        }


        /// <summary>
        /// Порівняти між собою два об’єкти клієнта.
        /// </summary>
        /// <param name="cmp">Об'єкт клієнта для порівняння</param>
        /// <повертає></повертає>
        public override bool Equals(object cmp)
        {
            Kunde cmpObj = (Kunde)cmp;
            if (this.Kundennummer.Equals(cmpObj.Kundennummer) && this.Status.Equals(cmpObj.Status) && 
                this.Vorname.Equals(cmpObj.Vorname) && this.Nachname.Equals(cmpObj.Nachname))
                return true;

            return false;
        }

        /// <summary>
        /// Порівнює між собою два об’єкти клієнта, але лише за номером клієнта.
        /// </summary>
        /// <param name="other"></param>
        /// <повертає></повертає>
        public bool Equals(Kunde other)
        {
            if (other == null) return false;
            return (this.Kundennummer.Equals(other.Kundennummer));
        }


        /// <summary> 
        /// /// Повертає хеш-код об'єкта клієнта. /// </summary> /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
