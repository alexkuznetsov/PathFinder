namespace PathFinder.Data
{
	/// <summary>
	/// Представление населенного пункта
	/// </summary>
	sealed class XmlCity
	{
		/// <summary>
		/// Идентификатор
		/// </summary>
		public int Id { get; private set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Title { get; private set; }

		internal XmlCity(int id, string title)
		{
			Id = id;
			Title = string.Format("{0} ({1})", title, id);
		}
	}
}
