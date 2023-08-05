/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
using System.Collections.Generic;

class LibraryArrays {
    
    public int GetSumMainDiagonal(int[,] array, bool isMain)
    {
        var length = array.GetLength(0);
        if (length != array.GetLength(1)) throw new Exception("Матрица не квадратная");
       
        var sum=0;
        var i = 0;
        for (var j = 0; i < length; i++, j++)
        {
            sum += array[i, isMain? j : length - j - 1];
        }
        return sum;
    }
    
    public int GetSumDivElements(int[,] array, int divValue)
    {
        if (divValue == 0) throw new Exception("Делить на 0 нельзя");
        
        var sum=0;
        for(var i = 0; i<array.GetLength(0); i++)
        {
            for(var j = 0; j<array.GetLength(1); j++)
            {
                var element = array[i,j];
                if (element % divValue == 0)
                {
                    sum += element;
                }
            }
        }
        return sum;
    }
}

class LibraryRecursive 
{
    
    public int GetFibonachi(int number)
    {
        if (number == 0 || number == 1) return number;
     
        return GetFibonachi(number - 1) + GetFibonachi(number - 2);
    }
    
    public int Degree(int number, int power) 
    {
        if (power == 1)
            return number;
        return number * Degree(number, --power);
    }
}

class Contact 
{
    public string Fio;
    public string Phone;
    
    public Contact(string fio, string phone) 
    {
        Fio = fio;
        Phone = phone;
    }
}

class LibraryContacts 
{
    private Dictionary<int, Contact> contats = new Dictionary<int, Contact>();
    
    public int GetHashCode(string key)
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + key == null ? 0 : key.GetHashCode();
            return hash;
        }
    }
    
    public void Add(string fio, string phone) 
    {
        var hashKey = GetHashCode(fio);
        if (contats.ContainsKey(hashKey)) throw new Exception("Такой человек уже есть");
        contats.Add(hashKey, new Contact(fio, phone));   
    }
    
    public void Delete(string fio) 
    {
        var hashKey = GetHashCode(fio);
        contats.Remove(hashKey);
    }
    
    public string GetPhone(string fio) 
    {
        var hashKey = GetHashCode(fio);
        return contats[hashKey].Phone;
    }
    
    public int GetCountContacts() 
    {
        return contats.Keys.Count;
    }
}

class LibraryFigures 
{
    public abstract class Figure 
    {
        public abstract double GetPerimetr();
        public abstract double GetArea();
        
        public virtual string GetFigure() 
        {
            return "Figure";
        }
    }
    
    public class Circle : Figure
    {
        protected int _side;
        
        public Circle(int radius)
        {
            _side = radius;
        }
        
        public override double GetPerimetr() 
        {
            return 2 * Math.PI * _side;
        }
        
        public override double GetArea() 
        {
            return Math.PI * _side * _side;
        }
        
        public override string GetFigure() 
        {
            return "Circle";
        }
    }
    
    public class Square: Circle
    {
        public Square(int side) : base(side)
        {
        }
        
        public override double GetPerimetr()
        {
            return 4 * _side;
        }
        
        public override double GetArea() 
        {
            return _side * _side;
        }
        
        public override string GetFigure() 
        {
            return "Square";
        }
    }
    
    public class Rectangle : Square
    {
        protected int _side2;
        
        public Rectangle(int side, int side2) : base(side)
        {
            _side2 = side2;
        }
        
        public override double GetPerimetr()
        {
            return 2 * (_side + _side2);
        }
        
        public override double GetArea() 
        {
            return _side * _side2;
        }
        
        public override string GetFigure() 
        {
            return "Rectangle";
        }
    }
    
    public class Rhombus : Rectangle
    {
        public Rhombus(int diagonal, int diagonal2): base(diagonal, diagonal2)
        {
        }
        
        public override double GetPerimetr() 
        {
            return 2 * Math.Sqrt(_side * _side + _side2 * _side2); 
        }
        
        public override double GetArea() 
        {
            return base.GetArea() / 2;
        }
        
        public override string GetFigure() 
        {
            return "Rhombus";
        }
    }
}

class TestCode 
{

    static void Main() 
    {
        int[,] array = {{1, 2, 3}, {6, 7, 8}, {9, 10, 12}};
        var libArray = new LibraryArrays();
        Console.WriteLine("Матрица сумма главной диагонали "+ libArray.GetSumMainDiagonal(array, true));
        Console.WriteLine("Сумма чисел кратных 3 "+ libArray.GetSumDivElements(array, 3));
        
        var libRecursive = new LibraryRecursive();
        Console.WriteLine("6 число фибоначи "+ libRecursive.GetFibonachi(6)); 
        Console.WriteLine("Возведение 5 в степень 3 = "+ libRecursive.Degree(5,3));
        
        var libContacts = new LibraryContacts();
        libContacts.Add("Alex", "12353");
        libContacts.Add("Tom", "23545");
        Console.WriteLine("Телефон Tom = "+ libContacts.GetPhone("Tom"));
        libContacts.Delete("Tom");
        Console.WriteLine("Количество контактов = "+ libContacts.GetCountContacts());
        
        
        var figures = new List<LibraryFigures.Figure>();
        figures.Add(new LibraryFigures.Circle(4));
        figures.Add(new LibraryFigures.Square(3));
        figures.Add(new LibraryFigures.Rectangle(2, 4));
        figures.Add(new LibraryFigures.Rhombus(5, 7));
        
        foreach(var figure in figures) 
        {
            Console.WriteLine("Периметр фигуры "+ figure.GetFigure() + " = " + figure.GetPerimetr());
            Console.WriteLine("Площадь фигуры "+ figure.GetFigure() + " = " + figure.GetArea());
        }
    }
}
