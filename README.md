<h1 align="center">Refactoring Documentation</h1>
<h2 align="center">“Baloons Pop 5”</h2>

<h5>21.07.2015 - DimitarSD</h5>

1. Refactoring Rating.cs
	- Changed the access modifiers of the fields from **public** to **private**
	- Added **this** when calling the properties in the constructor
	- Added blank line between **get** and **set** in each property
	- Added **this** when return a value from property (get) and when set a value to field (set)
	- Added **this** when return a value in **CompareTo()** method
	
2. Refactoring Balloon.cs
	- Renamed variable **randNumber** to **randomNumber** in **GenerateBalloons()** method
	- Renamed method name from **checkLeft()** to **CheckLeft()**
	- Renamed method name from **checkRight()** to **CheckRight()**
	- Renamed method name from **checkUp()** to **CheckUp()** 
	- Added blank line between **CheckUp()** and **CheckRight()** methods
	- Renamed method name from **checkDown()** to **CheckDown()**
	- Put **{** and **}** after **else** in **CheckRight()**, **CheckUp()** and **CheckDown()** methods
