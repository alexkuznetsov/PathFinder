namespace PathFinder
{
	using PathFinder.Data;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	class FinderResult
	{
		public bool IsSuccess { get; private set; }

		private int fromId;
		private int toId;
		private double dist;
		private int[] parents;
		private XmlSource xmlSource;
		private string message = string.Empty;

		internal FinderResult(int fromId, int toId, double dist, int[] parents, XmlSource xmlSource)
		{
			this.fromId = fromId;
			this.toId = toId;
			this.dist = dist;
			this.parents = parents;
			this.xmlSource = xmlSource;
			this.IsSuccess = true;
		}

		internal FinderResult()
		{
			IsSuccess = false;
			message = "Путь не найден";
		}

		public string GetResult()
		{
			return GetResult(false);
		}

		public string GetResult(bool invert)
		{
			if (IsSuccess == false)
				return message;

			IList<string> drivePath = new List<string>();
			int destId = parents[toId];

			drivePath.Add(xmlSource.GetCityById(toId).Title);
			drivePath.Add(xmlSource.GetCityById(destId).Title);

			while (destId != fromId)
			{
				destId = parents[destId];

				if (destId == fromId)
				{
					drivePath.Add(xmlSource.GetCityById(destId).Title);
				}
				else
				{
					drivePath.Add(xmlSource.GetCityById(destId).Title);
				}
			}

			string drivePathString = invert == false ?
				String.Join("\r\n\t", drivePath.Reverse().ToArray()) :
				String.Join("\r\n\t", drivePath.ToArray());

			return string.Format("Путь найден. Длина: {0}. Проезд:\r\n\t {1}", dist, drivePathString);

		}
	}
}
