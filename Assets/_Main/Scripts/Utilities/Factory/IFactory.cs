using UnityEngine;

namespace Simple.DesignPattern.FactoryMethod
{
    public interface IFactory
    {

    }

    public interface IAnimalFactory
    {
        IAnimal CreateAnimal();
    }

    public class RandomAnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal()
        {
            int random = UnityEngine.Random.Range(0, 3);

            if(random == 0)
            {
                return new Dog();
            }
            else if(random == 1)
            {
                return new Cat();
            }
            else
            {
                return new Fish();
            }
        }
    }

    public class Random4LegAnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal()
        {
            int random = UnityEngine.Random.Range(0, 2);

            if (random == 0)
            {
                return new Dog();
            }
            else
            {
                return new Cat();
            }
        }
    }

    public interface IAnimal
    {
        void Speak();
    }

    public class Dog : IAnimal
    {
        public void Speak()
        {
            Debug.Log("Go go");
        }
    }

    public class Cat : IAnimal
    {
        public void Speak()
        {
            Debug.Log("Mew mew");
        }
    }

    public class Fish : IAnimal
    {
        public void Speak()
        {
            Debug.Log("...");
        }
    }
}