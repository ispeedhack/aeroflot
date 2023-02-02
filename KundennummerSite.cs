using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apm
{
    /// <summary>
    /// Інтерфейс сайту використовується для прив’язки клієнтів до баз клієнтів
    /// і для забезпечення зв’язку між ними.
    /// </summary>
    class KundennummerSite : ISite
    {
        private IComponent _curComponent;
        private IContainer _curContainer;
        private bool _bDesignMode;
        private string _kundennummerName;


        // <summary>
        /// конструктор CustomerNumberSite
        /// </summary>
        /// <param name="actvCntr"></param>
        /// <param name="prntCmpnt"></param>
        public KundennummerSite(IContainer actvCntr, IComponent prntCmpnt)
        {
            _curComponent = prntCmpnt;
            _curContainer = actvCntr;
            _bDesignMode = false;
            _kundennummerName = null;
        }


        /// <summary>
        /// Повертає пов’язаний компонент сайту з номером клієнта.
        /// </summary>
        public virtual IComponent Component
        {
            get
            {
                return _curComponent;
            }
        }


        /// <summary>
        /// Повертає пов’язаний контейнер сайту з номером клієнта.
        /// </summary>
        public virtual IContainer Container
        {
            get
            {
                return _curContainer;
            }
        }


        /// <summary>
        /// Повертає DesignMode сайту.
        /// </summary>
        public virtual bool DesignMode
        {
            get
            {
                return _bDesignMode;
            }
        }


        /// <summary>
        /// Повертає або встановлює назву сайту.
        /// Ім'я (номер клієнта) завжди розглядається як рядок.
        /// </summary>
        public virtual string Name
        {
            get
            {
                return _kundennummerName;
            }

            set
            {
                _kundennummerName = value;
            }
        }

         
        /// <summary>
        /// Повертає сервісний об’єкт сайту.
        /// Сервісні об'єкти не використовуються в цій програмі.
        /// </summary>
        /// <param name="serviceType"></param>
        /// <повертає></повертає>
        public virtual object GetService(Type serviceType)
        {
            return null;
        }
    }
}
