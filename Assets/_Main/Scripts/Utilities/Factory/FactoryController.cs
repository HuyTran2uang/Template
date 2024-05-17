using Simple.DesignPattern.FactoryMethod;
using UnityEngine;

public class FactoryController : MonoBehaviour
{
    private IAnimalFactory _animalFactory;

    private void Start()
    {
        //
        _animalFactory = new RandomAnimalFactory();
        var animal1 = _animalFactory.CreateAnimal();
        animal1.Speak();

        //
        _animalFactory = new Random4LegAnimalFactory();
        var animal2 = _animalFactory.CreateAnimal();
        animal2.Speak();
    }
}
