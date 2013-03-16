namespace PathFinder
{
	using PathFinder.Data;
	using System;

	/// <summary>
	/// Поиск пути по графу
	/// </summary>
	class Finder
	{
		private readonly XmlSource xmlSource;

		private Action<string> onSuccess = (data) => { };
		private Action<string> onError = (data) => { };
		
		internal event Action<string> OnSuccess
		{
			add { onSuccess += value; }
			remove { onSuccess -= value; }
		}

		internal event Action<string> OnError
		{
			add { onError += value; }
			remove { onError -= value; }
		}

		internal Finder(XmlSource source)
		{
			xmlSource = source;
		}

		/// <summary>
		/// Поиск пути из точки А в точку Б
		/// </summary>
		/// <param name="fromId">ID точки А, начальной точки</param>
		/// <param name="toId">ID точки Б, конечной точки</param>
		internal void Find(int fromId, int toId)
		{
			int maxCityId = xmlSource.GetMaxCityId();
			double[,] pathMatrix = new double[maxCityId, maxCityId];

			var allDirections = xmlSource.GetDirections();

			foreach (XmlDirection d in allDirections)
			{
				pathMatrix[d.From, d.To] = d.Length;
			}

			var result = _Find(pathMatrix, fromId, toId);

			if (result.IsSuccess)
			{
				onSuccess(result.GetResult());
			}
			else
			{
				//попробуем найти пусть наоборот
				result = _Find(pathMatrix, toId, fromId);

				if (result.IsSuccess)
				{
					onSuccess(result.GetResult(true));
				}
				else
				{
					onError(result.GetResult());
				}
			}
		}

		FinderResult _Find(double[,] pathMatrix, int fromId, int toId)
		{
			Dijkstra dij = new Dijkstra(pathMatrix, fromId);

			var dist = dij.Distances;
			var parents = dij.Parents;

			if (dist[toId] != Double.PositiveInfinity)
			{
				return new FinderResult(fromId, toId, dist[toId], parents, xmlSource);
			}

			return new FinderResult();
		}
	}
}
