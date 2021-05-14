using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Zoo.Models;

namespace Zoo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        private Carnivore carnivore;

        private DispatcherTimer timer;
        private int elapsedTime;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();
            DataContext = viewModel;
            
            AddTimer();
        }

        private void AddTimer()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(UpdateTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            UseEnergy();

            elapsedTime += 1;
            lbl_DisplayTimer.Content = elapsedTime.ToString();
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAnimalName.Text))
                return;

            Animal animal = (Animal)Activator.CreateInstance((Type)cbAddAnimalType.SelectedItem);
            animal.Name = tbAnimalName.Text;
            animal.Died += Animal_Died;
            viewModel.Animals.Add(animal);
        }

        private void FeedSelectedAnimals_Click(object sender, RoutedEventArgs e)
        {
            Type type = (Type)cbFeedAnimalType.SelectedItem;
            foreach (Animal animal in viewModel.Animals)
                if (animal.GetType() == type)
                    animal.Eat();
        }

        private void FeedAllAnimals_Click(object sender, RoutedEventArgs e)
        {
            foreach (Animal animal in viewModel.Animals)
                animal.Eat();
        }

        private void EatOtherAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (lvAnimals.SelectedItem is Carnivore)
            {
                if (lvAnimals.Items.Count > 1)
                {
                    carnivore = (Carnivore)lvAnimals.SelectedItem;
                    lvAnimals.BorderBrush = Brushes.Red;
                    lvAnimals.BorderThickness = new Thickness(4);
                }
                else
                {
                    MessageBox.Show("No other animals available");
                }
            }
            else
            {
                MessageBox.Show("Please select a carnivore");
            }
        }

        private void lvAnimals_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (carnivore != null && lvAnimals.SelectedItem != null)
            {
                Animal prey = (Animal)lvAnimals.SelectedItem;
                try
                {
                    // This allows for cancellation by selecting the same animal.
                    if (prey != carnivore)
                        carnivore.Eat(prey);
                    carnivore = null;

                    lvAnimals.BorderBrush = null;
                    lvAnimals.BorderThickness = new Thickness(0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void UseEnergy_Click(object sender, RoutedEventArgs e)
        {
            UseEnergy();
        }

        private void StartStopTimer_Click(object sender, EventArgs e)
        {
            elapsedTime = 0;
            if (!timer.IsEnabled)
            {
                timer.Start();
                btn_StartStop.Content = "Stop Timer";
            }
            else
            {
                timer.Stop();
                btn_StartStop.Content = "Start Timer";
            }
        }

        private void UseEnergy()
        {
            // The "Died" event is apparently raised before the loop completes
            // so we need a copy because lists cannot be modified while looping through it.
            Animal[] animals = new Animal[viewModel.Animals.Count];
            viewModel.Animals.CopyTo(animals, 0);
            foreach (Animal animal in animals)
                animal.UseEnergy();
        }

        private void Animal_Died(object sender, EventArgs e)
        {
            Animal animal = (Animal)sender;
            Debug.WriteLine(animal.GetType().Name + " " + animal.Name + " died :(");
            viewModel.Animals.Remove(animal);
        }
    }
}