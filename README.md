PathFinder
==========

Реализация поиска пути из точки А в точку Б. Тестовый.

## Исходные данные

Исходные данных представлены в XML файле в следующем формате:
	
	<?xml version="1.0"?>
	<root>
		<cities>
			<city id="5" name="Астана" />
			...
			<city id="{city_n}" name="{title_n}" />
		</cities>
		
		<nodes>
			<node from="5" to="84" length="63" />
			<node from="5" to="390" length="82" />
		</nodes>
	</root>
	
`cities` представляет набор населенных пунктов, `nodes` - направления между ними (с растаяниями).