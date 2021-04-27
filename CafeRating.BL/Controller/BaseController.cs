using System.Collections.Generic;

namespace CafeRating.BL.Controller
{
    public abstract class BaseController
    {
        private readonly IDataSaver manager = new SerializeDataSaver();

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения. </param>
        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        /// <summary>
        /// Получить данные
        /// </summary>
        /// <typeparam name="T"> Тип возвращаемых данных </typeparam>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения </param>
        /// <returns> Данные из файла или Default(T) </returns>
        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
