using DogApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApp.Abstraction
{
    public interface IDogService
    {
        bool Create(string name, int age, string breed, string picture);

        bool UpdateDog(int dogId, string name, int age, string breed, string picture);

        List<Dog> GetDogs();

        Dog GetDogById(int dogId);

        bool RemoveByid(int dogId);

        List<Dog> GetDogs(string searchStringBreed, string searchStringName);

    }
}
