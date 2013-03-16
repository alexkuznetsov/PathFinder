namespace PathFinder.Data
{
	using System;
	using System.Collections.Generic;
	using System.Xml.XPath;

	sealed class XmlSource
	{
		private string xmlFile = string.Empty;
		private XPathDocument doc;
		private bool fileLoaded = false;

		internal XmlSource(string xmlFile)
		{
			this.xmlFile = xmlFile;

			LoadFile();
		}

		private void LoadFile()
		{
			if (System.IO.File.Exists(xmlFile))
			{
				doc = new XPathDocument(System.IO.File.OpenRead(xmlFile));
				fileLoaded = true;
			}
		}

		internal IEnumerable<XmlCity> GetCities()
		{
			if (fileLoaded)
			{
				var navi = doc.CreateNavigator();
				var cities = navi.Select("/root/cities/city");

				foreach (XPathNavigator city in cities)
				{
					yield return new XmlCity 
					(
						int.Parse(city.GetAttribute("id", string.Empty)), 
						city.GetAttribute("name", string.Empty)
					);
				}
			}
		}

		internal XmlCity GetCityById(int cityID)
		{
			if (fileLoaded)
			{
				var navi = doc.CreateNavigator();
				var city = navi.SelectSingleNode(string.Format("/root/cities/city[@id={0}]", cityID));

				if (city != null)
				{
					return new XmlCity
					(
						int.Parse(city.GetAttribute("id", string.Empty)),
						city.GetAttribute("name", string.Empty)
					);
				}

				throw new CityNotFoundException(string.Format("City #{0} not found.", cityID));
			}

			throw new ArgumentException("Data file not loaded.");
		}

		internal int GetMaxCityId()
		{
			if (fileLoaded)
			{
				XPathNavigator navi = doc.CreateNavigator();

				XPathNavigator idAttrNode = navi.SelectSingleNode(@"/root/cities/city[not(preceding-sibling::city/@id >= @id) 
    and not(following-sibling::city/@id > @id)]/@id");

				if (idAttrNode != null)
				{
					return int.Parse(idAttrNode.Value);
				}

			}

			return 0;
		}

		internal IEnumerable<XmlDirection> GetDirections()
		{
			if (fileLoaded)
			{
				var navi = doc.CreateNavigator();
				var directions = navi.Select("/root/nodes/node");

				foreach (XPathNavigator direction in directions)
				{
					yield return new XmlDirection
					{
						From = int.Parse(direction.GetAttribute("from", string.Empty)),
						To = int.Parse(direction.GetAttribute("to", string.Empty)),
						Length = double.Parse(direction.GetAttribute("length", string.Empty).Replace('.', ','))
					};
				}
			}
			else
			{
				throw new ArgumentException("Data file not loaded.");
			}
		}
	}
}
