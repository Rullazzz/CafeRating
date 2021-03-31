using CafeRating.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CafeRating.BL.Controller
{
    public abstract class BaseController
    {
        /// <summary>
        /// Получить данные
        /// </summary>
        /// <typeparam name="T"> Тип возвращаемых данных </typeparam>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения </param>
        /// <returns> Данные из файла или Default(T) </returns>
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Сохранить данные.
        /// </summary>
        /// <param name="fileName"> Путь для сохранения данных. </param>
        /// <param name="item"> Объект сохранения. </param>
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
