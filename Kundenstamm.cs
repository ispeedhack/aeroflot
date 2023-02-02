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
    /// Кореневий клієнт — це клас контейнера, який містить клієнтів
    /// включені різні авіакомпанії.
    /// </summary>
    public class Kundenstamm : IDisposable, IContainer
    {
        private ArrayList _kundenList;
        public string Fluggesellschaft { get; set; }


        /// <summary>
        /// клієнтська база конструктора.
        /// </summary>
        /// <param name="airline">Назва авіакомпанії, яка володіє цією базою клієнтів.</param>
        public Kundenstamm(string fluggesellschaft)
        {
            _kundenList = new ArrayList();
            this.Fluggesellschaft = fluggesellschaft;
        }


        /// <summary>
        /// Додати клієнта до клієнтської бази.
        /// Клієнт додається без створення об’єкта CustomerNumberSite.
        /// Цей метод не перевіряє наявність дублікатів і його не слід використовувати
        /// буде.
        /// </summary>
        /// <param name="customer">Об'єкт клієнта, який буде додано до бази клієнтів.</param>
        public virtual void Add(IComponent kunde)
        {
            _kundenList.Add(kunde);
        }

         
        /// <summary>
        /// Додати клієнта до клієнтської бази.
        /// Клієнт додається за допомогою об’єкта CustomerNumberSite.
        /// </summary>
        /// <param name="customer">Об'єкт клієнта, який буде додано до бази клієнтів.</param>
        /// <param name="customer number">Номер клієнта, який унікально ідентифікує клієнта.</param>
        public virtual void Add(IComponent kunde, string kundennummer)
        {
            for (int i = 0; i < _kundenList.Count; ++i)
            {
                IComponent curObj = (IComponent)_kundenList[i];
                if (curObj.Site != null)
                {
                    if (curObj.Site.Name.Equals(kundennummer))
                        throw new ArgumentException("Diese Kundennummer existiert bereits im Kundenstamm.");
                }
            }

            KundennummerSite data = new KundennummerSite(this, kunde);
            data.Name = kundennummer;
            kunde.Site = data;
            _kundenList.Add(kunde);
        }


        /// <summary>
        /// Вилучає клієнта з авіакомпанії
        /// </summary>
        /// <param name="customer">Клієнт для видалення.</param>
        public virtual void Remove(IComponent kunde)
        {
            for (int i = 0; i < _kundenList.Count; ++i)
            {
                if (kunde.Equals(_kundenList[i]))
                {
                    _kundenList.RemoveAt(i);
                    break;
                }
            }
        }


        /// <summary>
        /// Повертає ComponentCollection, що містить окремих клієнтів.
        /// </summary>
        public ComponentCollection Components
        {
            get
            {
                IComponent[] datalist = new Kunde[_kundenList.Count];
                _kundenList.CopyTo(datalist);
                return new ComponentCollection(datalist);
            }
        }


        /// <summary>
        /// Розширює клієнтську базу та клієнтів у ній.
        /// </summary>
        public virtual void Dispose()
        {
            for (int i = 0; i < _kundenList.Count; ++i)
            { 
                IComponent curObj = (IComponent)_kundenList[i];
                curObj.Dispose();
            }

            _kundenList.Clear();
        }
    }
}
