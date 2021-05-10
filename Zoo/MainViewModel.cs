using System;
using System.Collections.ObjectModel;
using Zoo.Models;

namespace Zoo
{
    public class MainViewModel
    {
        public ObservableCollection<Animal> Animals { get; } = new();
        public ObservableCollection<Type> AnimalTypes { get; } = new();

        public MainViewModel()
        {
            AnimalTypes.Add(typeof(Monkey));
            AnimalTypes.Add(typeof(Lion));
            AnimalTypes.Add(typeof(Tiger));
            AnimalTypes.Add(typeof(Elephant));
        }
    }
}
