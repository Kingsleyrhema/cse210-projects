using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Default constructor sets fraction to 1/1
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor to set a whole number as a fraction (e.g., 5 becomes 5/1)
    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    // Constructor with numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _numerator = numerator;
        _denominator = denominator;
    }

    // Getter for Numerator
    public int GetNumerator()
    {
        return _numerator;
    }

    // Setter for Numerator
    public void SetNumerator(int numerator)
    {
        _numerator = numerator;
    }

    // Getter for Denominato
    public int GetDenominator()
    {
        return _denominator;
    }

    // Setter for Denominator with validation
    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        _denominator = denominator;
    }

    // Method to get the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }

    // Method to get the fraction as a string
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }
}

class Program
{
    static void Main()
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString()); 
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString()); 
        
        Fraction fraction3 = new Fraction(2, 3);
        Console.WriteLine(fraction3.GetFractionString()); 
        Console.WriteLine(fraction3.GetDecimalValue());  
    }
}
