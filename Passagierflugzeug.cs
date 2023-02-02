using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apm
{
    /// <summary>
    /// Пасажирський літак — це клас контейнерів, який
    /// включені різні місця. Клас успадковується від
    /// Літак.
    /// </summary>
    public class Passagierflugzeug : Flugzeug, IDisposable, IContainer
    {
        private ArrayList _sitzplatzList;
        public int Kapazität { get; set; }


        /// <summary>
        /// Конструктор пасажирського літака
        /// </summary>
        /// <param name="id">Ідентифікація літака</param>
        public Passagierflugzeug(string id)
        {
            _sitzplatzList = new ArrayList();
            this.ID = id;
        }

         
        /// <summary>
        /// Додати місце в пасажирський літак.
        /// Місце додається без створення об’єкта SeatNumberSite.
        /// Цей метод не перевіряє наявність дублікатів і його не слід використовувати
        /// буде.
        /// </summary>
        /// <param name="seat"></param>
        public virtual void Add(IComponent sitzplatz)
        {
            _sitzplatzList.Add(sitzplatz);
        }
         
        /// <summary>
        /// Додати місце в пасажирський літак.
        /// Місце додається за допомогою об’єкта seatnumberSite.
        /// </summary>
        /// <param name="seat">Об’єкт сидіння для додавання до пасажирського літака.</param>
        /// <param name="seat number">Номер місця, який унікально ідентифікує місце.</param>
        public virtual void Add(IComponent sitzplatz, string sitznummer)
        {
            for (int i = 0; i < _sitzplatzList.Count; ++i)
            {
                IComponent curObj = (IComponent)_sitzplatzList[i];
                if (curObj.Site != null)
                {
                    if (curObj.Site.Name.Equals(sitznummer))
                        throw new ArgumentException("Diese Sitznummer existiert bereits im Passagierflugzeug.");
                }
            }

            SitznummerSite data = new SitznummerSite(this, sitzplatz);
            data.Name = sitznummer;
            sitzplatz.Site = data;
            _sitzplatzList.Add(sitzplatz);
        }
         
        /// <summary>
        /// Знімає крісло з пасажирського літака.
        /// </summary>
        /// <param name="seat">Місце для видалення.</param>
        public virtual void Remove(IComponent sitzplatz)
        {
            for (int i = 0; i < _sitzplatzList.Count; ++i)
            {
                if (sitzplatz.Equals(_sitzplatzList[i]))
                {
                    _sitzplatzList.RemoveAt(i);
                    break;
                }
            }
        }


        /// <summary>
        /// Повертає ComponentCollection, що містить окремі місця.
        /// </summary>
        public ComponentCollection Components
        {
            get
            {
                IComponent[] datalist = new Sitzplatz[_sitzplatzList.Count];
                _sitzplatzList.CopyTo(datalist);
                return new ComponentCollection(datalist);
            }
        }


        /// <summary>
        /// Розпускає пасажирський літак і крісла в ньому.
        /// </summary>
        public virtual void Dispose()
        {
            for (int i = 0; i < _sitzplatzList.Count; ++i)
            {
                IComponent curObj = (IComponent)_sitzplatzList[i];
                curObj.Dispose();
            }

            _sitzplatzList.Clear();
        }
    }
}
