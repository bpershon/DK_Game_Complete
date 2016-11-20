import xml.etree.ElementTree as ET

tileMapTree = ET.parse("../Levels/fullLevel1.tmx")

root = tileMapTree.getroot()

objects = root.findall("./objectgroup[@name='ItemLayer']/object")
for mapObject in objects:
	properties = mapObject.findall("./properties/property")
	for prop in properties:
		mapObject.set(prop.get("name"),prop.get("value"))

tileMapTree.write("../Levels/fullLevel1.tmx", "UTF-8", True)
