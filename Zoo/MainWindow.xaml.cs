using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
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
            foreach (Animal animal in viewModel.Animals.Reverse())
            {
                animal.UseEnergy();

                if (animal.Energy == 0)
                {
                    Debug.WriteLine(animal.GetType().Name + " " + animal.Name + " died :(");
                    viewModel.Animals.Remove(animal);
                }
            }
        }
    }
}