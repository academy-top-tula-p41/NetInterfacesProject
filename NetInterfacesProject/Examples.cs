using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetInterfacesProject
{
    static class Examples
    {
        public static void InterfacesWelcomeExample()
        {
            /*
            Methods
            Properties
            Indexators []
            Events
            Static field, const field
            */

            MovesObject obj = new MovesObject();
            (obj as IMovable).DefaultMethod();

            IMovable movable = new MovesObject();
            movable.DefaultMethod();
        }

        public static void MethodsDefaultExample()
        {
            DoFly(new Duck());
            DoFly(new Planet());
            DoFly(new Airplane());

            IFlyable[] flyables = new IFlyable[4];
            flyables[0] = new Duck();
            flyables[1] = new Planet();
            flyables[2] = new Airplane();
            flyables[3] = new Disk();

            foreach (var flyable in flyables)
                flyable.Fly();

            void DoFly(IFlyable flable)
            {
                flable.Fly();
            }
        }

        public static void ExplicitImplentsExample()
        {
            MyClass myClass = new MyClass();
            (myClass as IAction).Action();

            IAction action = new MyClass();
            action.Action();

            Boy boy = new Boy();
            boy.Study();

            ISchool school = new Boy();
            school.Study();

            IUniversitet universitet = new Boy();
            universitet.Study();
        }

        public static void InheritanceExample()
        {
            Animal animal = new Animal();
            animal.Sleep();

            Cat cat = new Cat();
            cat.Sleep();

            animal = new Cat();
            animal.Sleep();
        }

        public static void CovarContrvarExample()
        {
            // Covariant
            IMessageBuilder<EmailMessage> emailMessageBuilder
                = new EmailMessageBuilder();
            var email = emailMessageBuilder.MessageCreate("Hello world");
            email.Send();

            IMessageBuilder<Message> messageBuilder
                = new EmailMessageBuilder();
            Message message = messageBuilder.MessageCreate("Good by world");
            message.Send();

            messageBuilder = emailMessageBuilder;
            messageBuilder.MessageCreate("Welcome").Send();


            // Contrvariant
            IMessagePrintable<Message> messagePrinter
                = new MessagePrinter();
            messagePrinter.Print(new Message("Hi"));

            IMessagePrintable<EmailMessage> emailPrinter
                = new MessagePrinter();
            emailPrinter.Print(new EmailMessage("Wow"));
        }
    }

    class MovesObject : IMovable
    {
        int speed;
        public int Speed { get; set; }
        //{
        //    get => speed;
        //    set => speed = value; 
        //}

        public event Action<string> MoveHandler;

        public void Move()
        {
            Console.WriteLine("Movable Object Move");
            MoveHandler?.Invoke("Movable Object Move Handler");
        }
    }
    interface IMovable
    {
        const int minSpeed = 0;
        static int maxSpeed = 100;
        int Speed { get; set; }
        void Move();

        void DefaultMethod()
        {
            Console.WriteLine("Interface method");
        }

        event Action<string> MoveHandler;
    }


    interface IFlyable
    {
        void Fly() => Console.WriteLine("Any flying");
    }

    class Airplane : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Arplane flying");
        }
    }

    class Duck : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Duck flying");
        }
    }

    class Planet : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Planet flying");
        }
    }

    class Disk : IFlyable
    {
        // Fly
    }




    interface IAction
    {
        void Action();
    }
    class MyClass : IAction
    {
        public void Action()
        {
            Console.WriteLine("Action method of class");
        }

        void IAction.Action()
        {
            Console.WriteLine("Action method of interface");
        }
    }



    class Boy : ISchool, IUniversitet
    {
        public void Study()
        {
            Console.WriteLine("Study...");
        }

        void ISchool.Study()
        {
            Console.WriteLine("Study in school.");
        }

        void IUniversitet.Study()
        {
            Console.WriteLine("Study in universitet.");
        }
    }

    interface ISchool
    {
        void Study();
    }

    interface IUniversitet
    {
        void Study();
    }


    interface ISleepable
    {
        void Sleep();
    }

    class Animal : ISleepable
    {
        public virtual void Sleep()
        {
            Console.WriteLine("Animal sleeping...hr...");
        }
    }

    class Cat : Animal
    {
        public override void Sleep()
        {
            Console.WriteLine("Cat sleeping...hr...");
        }
    }



    interface ISpeedable
    {
        void Speed();
    }

    interface IDriveable : ISpeedable
    {
        void Drive();
    }

    class Transport : IDriveable
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public void Speed()
        {
            throw new NotImplementedException();
        }
    }




    interface IIdentifiable<T>
    {
        T Id { get; }
    }

    class User<T> : IIdentifiable<T>
    {
        public T Id { get; }
    }

    class IntUser : IIdentifiable<int>
    {
        public int Id { get; }
    }



    class Message
    {
        public string Text { get; set; }
        public Message(string text) => Text = text;

        public virtual void Send()
            => Console.WriteLine($"Message: {Text}");
    }

    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }

        public override void Send()
            => Console.WriteLine($"Email: {Text}");
    }


    interface IMessageBuilder<out T>
    {
        T MessageCreate(string text);
    }

    class EmailMessageBuilder : IMessageBuilder<EmailMessage>
    {
        public EmailMessage MessageCreate(string text)
            => new EmailMessage(text);
    }


    interface IMessagePrintable<in T>
    {
        void Print(T message);
    }

    class MessagePrinter : IMessagePrintable<Message>
    {
        public void Print(Message message)
            => message.Send();
    }

}
