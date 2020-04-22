using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create vegatables and attach restorants

        Cucumber cucumber = new Cucumber("Краставици", 02.10);
        cucumber.Attach(new Restorant("Одеон"));
        cucumber.Attach(new Restorant("Никол"));
        cucumber.Attach(new Restorant("Виктория"));

        Cabbage cabbage = new Cabbage("Зеле", 01.05);
        cabbage.Attach(new Restorant("Одеон"));
        cabbage.Attach(new Restorant("Никол"));
        cabbage.Attach(new Restorant("Виктория"));

        Tomato tomato = new Tomato("Домат", 01.95);
        tomato.Attach(new Restorant("Одеон"));
        tomato.Attach(new Restorant("Никол"));
        tomato.Attach(new Restorant("Виктория"));

        // Fluctuating prices will notify restorants

        cucumber.Price = 02.25;
        cucumber.Price = 02.15;
        cucumber.Price = 02.20;

        cabbage.Price = 01.10;
        cabbage.Price = 01.15;
        cabbage.Price = 01.10;

        tomato.Price = 02.10;
        tomato.Price = 02.25;
        tomato.Price = 02.20;

        // Wait for user

        Console.ReadKey();
    }
}

/// <summary>

/// The 'Vegetable' abstract class

/// </summary>

abstract class Vegetable
{
    private string _vegetableName;

    private double _price;

    private List<IRestorant> _restorants = new List<IRestorant>();

    // Constructor

    public Vegetable(string vegetableName, double price)
    {
        this._vegetableName = vegetableName;

        this._price = price;
    }


    public void Attach(IRestorant restorant)
    {
        _restorants.Add(restorant);
    }

    public void Detach(IRestorant restorant)

    {
        _restorants.Remove(restorant);
    }


    public void Notify()
    {
        foreach (IRestorant restorant in _restorants)
        {
            restorant.Update(this);
        }
        Console.WriteLine("");
    }

    // Gets or sets the price

    public double Price
    {
        get { return _price; }

        set

        {

            if (_price != value)

            {

                _price = value;

                Notify();

            }

        }

    }


    // Gets the vegetableName

    public string VegetableName

    {

        get { return _vegetableName; }

    }

}



/// <summary>

/// The 'ConcreteSubject' class

/// </summary>

class Tomato : Vegetable

{

    // Constructor

    public Tomato(string vegetableName, double price)

      : base(vegetableName, price)

    {

    }

}

class Cabbage : Vegetable

{

    // Constructor

    public Cabbage(string vegetableName, double price)

      : base(vegetableName, price)

    {

    }

}

class Cucumber : Vegetable

{

    // Constructor

    public Cucumber(string vegetableName, double price)

      : base(vegetableName, price)

    {

    }

}


/// <summary>

/// The 'Observer' interface

/// </summary>

interface IRestorant

{

    void Update(Vegetable vegatable);

}


/// <summary>

/// The 'ConcreteObserver' class

/// </summary>

class Restorant : IRestorant

{

    private string _name;

    private Vegetable _vegetable;



    // Constructor

    public Restorant(string name)

    {

        this._name = name;

    }



    public void Update(Vegetable vegetable)

    {

        Console.WriteLine("Уведомява ресторант {0}, че цената на {1} " +

          "се променя на {2:C}", _name, vegetable.VegetableName, vegetable.Price);

    }


    // Gets or sets the vegatable

    public Vegetable vegetable

    {

        get { return _vegetable; }

        set { _vegetable = value; }

    }

}