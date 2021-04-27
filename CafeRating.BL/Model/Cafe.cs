namespace CafeRating.BL.Model
{
    public class Cafe
    {
        #region Свойства
        /// <summary>
        /// Название кафе.
        /// </summary>
        public string Name { get; }
        #endregion

        /// <summary>
        /// Создать новое кафе.
        /// </summary>
        /// <param name="name"> Название кафе. </param>
        public Cafe(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
