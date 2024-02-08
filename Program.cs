using static System.Console;

void InputOperations(Fraction fract1, Fraction fract2)
{
    WriteLine($"Исходные дроби: {fract1} и {fract2}");

    Fraction generalFr1 = new Fraction();
    Fraction generalFr2 = new Fraction();
    Fraction.GeneralDenom(fract1, fract2, out generalFr1, out generalFr2);
    WriteLine($"Приведены к общему знаменателю: {generalFr1} и {generalFr2}");
    WriteLine("");

    WriteLine("Арифметические операторы: ");

    WriteLine($"{fract1} + {fract2} = {fract1 + fract2}");
    WriteLine($"{fract1} - {fract2} = {fract1 - fract2}");
    WriteLine($"{fract1} * {fract2} = {fract1 * fract2}");
    WriteLine($"{fract1} / {fract2} = {fract1 / fract2}");
    WriteLine("");

    WriteLine("Операторы сравнения: ");
    WriteLine($"{fract1} > {fract2}: {generalFr1 > generalFr2}");
    WriteLine($"{fract1} < {fract2}: {generalFr1 < generalFr2}");
    WriteLine($"{fract1} == {fract2}: {generalFr1 == generalFr2}");
    WriteLine($"{fract1} != {fract2}: {generalFr1 != generalFr2}");
    WriteLine("");

    WriteLine("Логические операторы: ");
    WriteLine($"{fract1} || {fract2}: {Fraction.Or(fract1, fract2)}");
    WriteLine($"{fract1} %% {fract2}: {Fraction.And(fract1, fract2)}");
}
WriteLine("\t\tТест 1");
Fraction fract1 = new Fraction(2, 5);
Fraction fract2 = new Fraction(3, 10);
InputOperations(fract1, fract2);

WriteLine("\n");
WriteLine("\t\tТест 2");
Fraction fract3 = new Fraction(5, 6);
Fraction fract4 = new Fraction(0, 10);
InputOperations(fract3, fract4);

WriteLine("\n");
WriteLine("\t\tТест 3");
Fraction fract5 = new Fraction(3, 0);
class Fraction
{
    int numerator { get; set; }
    int denominator { get; set; }

    public Fraction(int num, int denom)
    {
        this.numerator = num;
        if (denom == 0)
        {
            Console.WriteLine("Знаменатель не может быть = 0");
        }
        else
            this.denominator = denom;
    }
    public Fraction() { }

    public static void GeneralDenom (Fraction f1, Fraction f2, out Fraction generalFract1, out Fraction generalFract2)
    {
        int num1 = f1.numerator * f2.denominator;
        int num2 = f2.numerator * f1.denominator;
        int denom = f2.denominator*f1.denominator;
        generalFract1 = new Fraction(num1, denom);
        generalFract2 = new Fraction(num2, denom);
    }
    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.denominator + f2.numerator * f1.denominator;
        int denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.denominator - f2.numerator * f1.denominator;
        int denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.numerator;
        int denom = f1.denominator * f2.denominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        int num = f1.numerator * f2.denominator;
        int denom = f1.denominator * f2.numerator;
        return new Fraction(num, denom);
    }

    public static bool operator >(Fraction f1, Fraction f2) {return f1.numerator > f2.numerator;}
    public static bool operator <(Fraction f1, Fraction f2) { return f1.numerator < f2.numerator; }
    public static bool operator ==(Fraction f1, Fraction f2) { return f1.numerator == f2.numerator; }
    public static bool operator !=(Fraction f1, Fraction f2) { return f1.numerator != f2.numerator; }

    public static bool operator false(Fraction f1) {return f1.numerator == 0 ? true : false;}
    public static bool operator true(Fraction f1) { return f1.numerator != 0 ? true : false; }

    public static Fraction operator|(Fraction f1, Fraction f2)
    {
        if ((f1.numerator != 0 || f1.denominator != 0) || (f2.numerator != 0 || f2.denominator != 0))
                return f2;
        return new Fraction();
    }
    public static Fraction operator &(Fraction f1, Fraction f2)
    {
        if ((f1.numerator != 0 && f1.denominator != 0) && (f2.numerator != 0 && f2.denominator != 0))
            return f2;
        return new Fraction();
    }

    public static bool Or(Fraction f1, Fraction f2)
    {
        if (f1 || f2) return true;
        else return false;
    }
    public static bool And(Fraction f1, Fraction f2)
    {
        if (f1 && f2) return true;
        else return false;
    }
    public override string ToString()
    {
        string fract = "";
        if (numerator == 0)
        {
            fract += "0";
            return fract;
        }
        fract += numerator;

        if (denominator != 1)
        {
            fract += "/";
            fract += denominator;
        }
        return fract;
    }
}

