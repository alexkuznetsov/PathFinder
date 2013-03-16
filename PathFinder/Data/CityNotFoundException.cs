namespace PathFinder.Data
{
	using System;

	/// <summary>
	/// Исключение "Город не найден"
	/// </summary>
	sealed class CityNotFoundException : Exception
	{
		public CityNotFoundException() : base() { }
		public CityNotFoundException(string message) : base(message) { }
	}
}
