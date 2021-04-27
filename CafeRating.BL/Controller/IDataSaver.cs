using System.Collections.Generic;

namespace CafeRating.BL.Controller
{
    public interface IDataSaver
    {
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения. </param>
        void Save<T>(List<T> item) where T : class;

        /// <summary>
        /// Получить данные.
        /// </summary>
        /// <typeparam name="T"> Тип возвращаемых данных. </typeparam>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <returns> Данные из файла или Default(T). </returns>
        List<T> Load<T>() where T : class;
    }
}
