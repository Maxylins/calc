using System.Linq.Expressions;

public class Program
{
    public static void Main(string[] args)
    {
        string UserData;
        Console.WriteLine("Введите выражение:");
        UserData = Console.ReadLine();
        Console.WriteLine(Expression(UserData));

    }
    public static decimal Add(string a, string b)
    {
        return Convert.ToDecimal(a) + Convert.ToDecimal(b);
    }
    public static decimal Minus(string a, string b)
    {
        return Convert.ToDecimal(a) - Convert.ToDecimal(b);
    }
    public static decimal Mult(string a, string b)
    {
        return Convert.ToDecimal(a) * Convert.ToDecimal(b);
    }
    public static decimal Del(string a, string b)
    {
        if (b != "0")
        {
            return Convert.ToDecimal(a) / Convert.ToDecimal(b);
        }
        else
        {
            throw new Exception("деление на ноль");
        }
    }
    public static decimal Expression(string userdata)
    {
        decimal a;
        string s;
        List<string> expression=userdata.Split('+','-','*','/').ToList<string>();
        foreach(string sa in expression)
        {
            Console.WriteLine(sa);
        }
        Console.ReadLine();
        if ((expression[0]=="+" || expression[0] == "-" || expression[0] == "*" || expression[0] == "/") || (expression.Last() == "+" || expression.Last() == "-" || expression.Last() == "*" || expression.Last() == "/"))
        {
            throw new Exception("неверное составление выражения");
        }
        do {
            for (int i = 0; true; i++)
            {
                s = expression[i];
                if (s == "+")
                {
                    a = Convert.ToDecimal(expression[i - 1]) + Convert.ToDecimal(expression[i + 1]);
                    expression[i] = a.ToString();
                    expression.RemoveAt(i - 1);
                    expression.RemoveAt(i + 1);
                }
                if (s == "-")
                {
                    a = Convert.ToDecimal(expression[i - 1]) - Convert.ToDecimal(expression[i + 1]);
                    expression[i] = a.ToString();
                    expression.RemoveAt(i - 1);
                    expression.RemoveAt(i + 1);
                }
                if (s == "*")
                {
                    a = Convert.ToDecimal(expression[i - 1]) / Convert.ToDecimal(expression[i + 1]);
                    expression[i] = a.ToString();
                    expression.RemoveAt(i - 1);
                    expression.RemoveAt(i + 1);
                }
                if (s == "/")
                {
                    a = Convert.ToDecimal(expression[i - 1]) / Convert.ToDecimal(expression[i + 1]);
                    expression[i] = a.ToString();
                    expression.RemoveAt(i - 1);
                    expression.RemoveAt(i + 1);
                }
            }
        }
        while (expression.Count > 1);
        return Convert.ToDecimal(expression[0]);
    }
}
