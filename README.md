# Tehnici și Mecanisme de Proiectare Software

*Author - Vladimir Roman*

*Group - TI-164*

*Name - Patterns Lab 1 Creational Patterns *

This lab include realisation of next patterns: 
1. Factory Method 

![Image of Factory Method](https://refactoring.guru/images/patterns/cards/factory-method-mini-2x.png)

Declaration of [abstract class](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/AbstractObject.cs)
```
public abstract class AbstractObject : IObjectBuilder
{
  ***
}
```

Declaration of [class that is responsible for 'circles'](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/Circle/CircleBuilder.cs)
```
public class CircleBuilder : AbstractObject, IObjectBuilder
{
  ***
}
```
Declaration of [class that is responsible for 'rectangles'](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/Rectangle/RectangleBuilder.cs)

```
public class RectangleBuilder: AbstractObject, IObjectBuilder
{
  ***
}
```

2. Abstract Factory

![Image of Abstract Factory](https://refactoring.guru/images/patterns/cards/abstract-factory-mini-2x.png)

Declaration of interface in this [file](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/IUnitFactory.cs)
```
public interface IUnitFactory
{
    string Name { get; set; }
    IObjectBuilder ObjectBuilder { get; }       

}
```

Creation of inhetitors classes in this [file](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/CircleFactory.cs) and this [file](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/RectangleFactory.cs)

```
public class RectangleFactory : IUnitFactory
{
  ***
}
public class CircleFactory : IUnitFactory
{
  ***
}
```


3. Builder

![Image of Builder](https://refactoring.guru/images/patterns/cards/factory-method-mini-2x.png)

Declaration of [Object builder interface](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/IObjectBuilder.cs)
```
public interface IObjectBuilder
{       
Graphics formGraphics { get; set; }
IObjectBuilder BuildObject();
UserColor ObjectColor { get; set; }
void ChangeColor();

}
```

Implementation of this interface was you can check in Factory Method.
Classes circle builder and rectangle builder implements it.

4. Prototype

![Image of Prototype](https://refactoring.guru/images/patterns/cards/factory-method-mini-2x.png)

Files where was created [prototype methods](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/Circle/CircleBuilder.cs)
and [this](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Factory/Rectangle/RectangleBuilder.cs)

```
public static CircleBuilder CopyCircle(CircleBuilder tempCircle)
{
    CircleBuilder temp = new CircleBuilder(tempCircle.formGraphics, tempCircle.ThisObject, tempCircle.ObjectColor,
        tempCircle.timer);

    return temp;
}

public static RectangleBuilder CopyRectangle(RectangleBuilder tempRectangle)
{
    RectangleBuilder temp = new RectangleBuilder(tempCircle.formGraphics, tempCircle.ThisObject, tempCircle.ObjectColor,
        tempCircle.timer);

    return temp;
}
```
This methods return new instance of objects.


5. Singleton 

![Image of Singleton](https://refactoring.guru/images/patterns/cards/factory-method-mini-2x.png)

For realisation of singleton pattern was created class [Map](https://github.com/vovaroman/PatternsLab1/blob/master/patternLab/Map/Map.cs) that is responsible for map of the application.
One application - one map, philosophy of singleton method.


```
public class Map
{
    private static Map MapObject;
    ***
    public static Size Size;
    private Map(Point p,int height, int width)
    {
        Size = new Size(width, height);
        PointStart = p;
        GameField = new Rectangle(PointStart, Size);
        Graphics.FillRectangle(new SolidBrush(Color.OldLace), GameField);
    }
    ***
    public static Map GetInstance(Point p, int height, int width, Graphics gs)
    {
        if (MapObject == null)
        {
            Graphics = gs;
            MapObject = new Map(p, height, width);
            return MapObject;
        }
        else
            return MapObject;
    }
    ***
}
```

In this code block we can check realisation of singleton pattern:)

Screenshot of program:
![Image of program](https://pp.userapi.com/c847019/v847019010/19db33/oYqPlVIcRBk.jpg)
