using System;
using System.Collections.Generic;
// using Ctci.Library;

namespace ExChapter03
{
    public class Q3_06_Animal_Shelter
    {

        #region Animal

        public abstract class Animal
        {
            private int Order;
            protected string Name;
            public Animal(string name)
            {
                this.Name = name;
            }

            public abstract string ShowName();

            // public int Order { get; set; }
            public void SetOrder(int order)
            {
               this.Order = order;
            }

            //public int GetOrder { get; set; }
            public int GetOrder()
            {
                return this.Order;
            }

            // Compare orders of animals to return the older item.
            public bool IsOlderThan(Animal animal)
            {
                return this.Order < animal.GetOrder();
            }
        }

        #endregion Animal

        #region Dog

        public class Dog : Animal
        {
            public Dog(string name) : base(name) { }

            override public string ShowName()
            {
                return "Dog: " + this.Name;
            }

        }

        #endregion Dog

        #region Cat

        public class Cat : Animal
        {
            public Cat(string name) : base(name) { }

            override public string ShowName()
            {
                return "Cat: " + this.Name;
            }

        }

        #endregion Cat

        #region AnimalQueue

        public class AnimalQueue
        {
            // https://www.geeksforgeeks.org/linked-list-in-java/
            // https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
            LinkedList<Dog> dogs = new LinkedList<Dog>();
            LinkedList<Cat> cats = new LinkedList<Cat>();
            // Time stamp
            private int order = 0;

            public void Enqueue(Animal animal)
            {
                // Order is used as a sort of timestamp,
                // so that we can compare the insertion order of a dog to a cat.
                animal.SetOrder(order);
                order++;
                // https://stackoverflow.com/questions/3561202/check-if-instance-is-of-a-type
                if (animal is Dog)  // animal.GetType() == typeof(Dog)
                {
                    dogs.AddLast((Dog)animal);
                }
                else if (animal is Cat) // animal.GetType() == typeof(Cat)
                {
                    cats.AddLast((Cat)animal);
                }
            }

            // Look at tops of dog and cat queues, and pop the queue with the oldest value.
            public Animal DequeueAny()
            {
                if (dogs.Count == 0) return DequeueCats();
                else if (cats.Count == 0) return DequeueDogs();

                Dog dog = dogs.First.Value;
                Cat cat = cats.First.Value;
                if (dog.IsOlderThan(cat))
                    return DequeueDogs();
                    //return dogs.poll();
                else
                    return DequeueCats();
                    // return cats.poll();
            }

            public Animal Peek()
            {
                if (dogs.Count == 0) return cats.First.Value;
                else if (cats.Count == 0) return dogs.First.Value;
                Dog dog = dogs.First.Value;
                Cat cat = cats.First.Value;
                if (dog.IsOlderThan(cat)) return dog;
                else return cat;
            }

            public int Size()
            {
                return dogs.Count + cats.Count;
            }

            public Dog DequeueDogs()
            {
                Dog dog = dogs.First.Value;
                dogs.RemoveFirst();
                return dog;
                //return dogs.poll();
            }

            public Dog PeekDogs()
            {
                return dogs.First.Value;
            }

            public Cat DequeueCats()
            {
                Cat cat = cats.First.Value;
                cats.RemoveFirst();
                return cat;
                //return cats.poll();
            }

            public Cat PeekCats()
            {
                return cats.First.Value;
            }
        }

        #endregion AnimalQueue

        #region Q03_06_Run

        public static void Q03_06_Run()
        {
           	AnimalQueue animals = new AnimalQueue();
            animals.Enqueue(new Cat("Callie"));
            animals.Enqueue(new Cat("Kiki"));
            animals.Enqueue(new Dog("Fido"));
            animals.Enqueue(new Dog("Dora"));
            animals.Enqueue(new Cat("Kari"));
            animals.Enqueue(new Dog("Dexter"));
            animals.Enqueue(new Dog("Dobo"));
            animals.Enqueue(new Cat("Copa"));
            Console.WriteLine(animals.DequeueAny().ShowName());	
            Console.WriteLine(animals.DequeueAny().ShowName());	
            Console.WriteLine(animals.DequeueAny().ShowName());	

            animals.Enqueue(new Dog("Dapa"));
            animals.Enqueue(new Cat("Kilo"));

            while (animals.Size() != 0)
            {
                Console.WriteLine(animals.DequeueAny().ShowName());	
            }
        }

        #endregion Q03_06_Run
    }
}