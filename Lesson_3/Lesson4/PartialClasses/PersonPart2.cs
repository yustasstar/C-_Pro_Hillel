namespace Lesson4.PartialClasses
{
    public partial class PersonPartial
    {
        public partial void Read()
        {
            Console.WriteLine("I am reading a book");
        }
    }
}

// Варто зазначити, що за умовчанням до часткових методів застосовується низка обмежень:

//Вони не можуть мати модифікаторів доступу

//Вони мають тип void

//Вони не можуть мати out-параметри

//Вони не можуть мати модифікатори virtual, override, sealed, new або extern
