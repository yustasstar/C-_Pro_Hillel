namespace Lesson6.SOLID.BasicExamples
{
    // Problem: 

    // Производный класс изменяет поведение базового класса, нарушая логику программы.

    // Пользователь класса Bird ожидает, что любой его подкласс сможет летать,
    // но в случае с пингвином это не так, что нарушает принцип Лисков.

    public class Bird
    {
        public virtual void Fly()
        {
            // Логика полета
        }
    }

    public class Penguin : Bird
    {
        public override void Fly()
        {
            throw new NotImplementedException("Пингвины не летают!");
        }
    }

    // Solution:

    // Не стоит использовать наследование, если подкласс не может корректно выполнять действия базового класса.
    // В данном случае нужно пересмотреть иерархию классов.

    public abstract class BirdV2
    {
        public abstract void Move();
    }

    public class FlyingBirdV2 : BirdV2
    {
        public override void Move()
        {
            // Логика полета
        }
    }

    public class PenguinV2 : BirdV2
    {
        public override void Move()
        {
            // Логика плавания или ходьбы
        }
    }

    // Теперь вместо полиморфного метода Fly, у нас есть метод Move, который каждый подкласс реализует
    // в соответствии со своими возможностями.
}
