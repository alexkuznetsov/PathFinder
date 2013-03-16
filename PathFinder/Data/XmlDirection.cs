namespace PathFinder.Data
{
	/// <summary>
	/// Направление
	/// </summary>
	sealed class XmlDirection
	{
		/// <summary>
		/// ID населенного пункта, откуда идет путь
		/// </summary>
		public int From { get; set; }

		/// <summary>
		/// ID населенного пункта, куда идет путь
		/// </summary>
		public int To { get; set; }

		/// <summary>
		/// Протяженность пути
		/// </summary>
		public double Length { get; set; }
	}
}
