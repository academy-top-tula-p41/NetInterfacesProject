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
}
