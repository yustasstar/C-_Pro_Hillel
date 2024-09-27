// https://ru.stackoverflow.com/questions/606849/%D0%9A%D0%BB%D1%8E%D1%87%D0%B5%D0%B2%D0%BE%D0%B5-%D1%81%D0%BB%D0%BE%D0%B2%D0%BE-this-%D0%B8-%D0%B5%D0%B3%D0%BE-%D0%BF%D1%80%D0%B8%D0%BC%D0%B5%D0%BD%D0%B5%D0%BD%D0%B8%D0%B5-%D0%B2-%D0%9A%D0%BB%D0%B0%D1%81%D1%81%D0%B5-%D0%9F%D0%BE%D0%BB%D1%8C%D0%B7%D0%BE%D0%B2%D0%B0%D1%82%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%BE%D0%B9-%D1%81%D1%82%D1%80%D1%83%D0%BA%D1%82%D1%83%D1%80%D0%B5

/*
Варто зазначити, що до версії C# 11 щодо конструктора структуру в ньому необхідно 
було ініціалізувати всі поля структури, починаючи з версії C# 11 це робити необов'язково.

Якщо нам потрібно викликати конструктори з різною кількістю параметрів,
то ми можемо, як і у випадку з класами, викликати їх по ланцюжку
*/
struct PersonV2
{
    public string name;
    public int age;

    public PersonV2() : this("Tom")
    { }
    public PersonV2(string name) : this(name, 1)
    { }
    public PersonV2(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public void Print() => Console.WriteLine($"Name: {name}  Age: {age}");
}