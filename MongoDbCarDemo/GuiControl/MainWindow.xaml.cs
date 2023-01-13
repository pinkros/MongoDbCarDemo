using System;
using System.Windows;
using System.Windows.Controls;
using DataAccess;
using DataAccess.Models;

namespace GuiClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRepository<Car> _carManager;
        public MainWindow()
        {
            InitializeComponent();
            _carManager = new CarManager();
            UpdatePeopleView();
        }

        private void People_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (People.SelectedItem is Car car)
            {
                FirstName.Text = car.FirstName;
                LastName.Text = car.LastName;
                Age.Text = $"{car.Age}";
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var car = new car()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Age = int.Parse(Age.Text)
            };

            _peopleManager.Add(car);
            UpdatePeopleView();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (People.SelectedItem is car car)
            {
                if (!string.IsNullOrEmpty(FirstName.Text) && !string.IsNullOrEmpty(LastName.Text) && !string.IsNullOrEmpty(Age.Text))
                {
                    var newcar = new Car()
                    {
                        FirstName = FirstName.Text,
                        LastName = LastName.Text,
                        Age = int.Parse(Age.Text)
                    };
                    _peopleManager.Replace(car.Id, newcar);
                }

                UpdatePeopleView();
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (People.SelectedItem is car car)
            {
                _peopleManager.Delete(car.Id);
            }

            UpdatePeopleView();
        }

        private void UpdatePeopleView()
        {
            var people = _peopleManager.GetAll();
            People.Items.Clear();
            foreach (var car in people)
            {
                People.Items.Add(car);
            }

            ClearFields();
        }

        private void ClearFields()
        {
            FirstName.Text = string.Empty;
            LastName.Text = string.Empty;
            Age.Text = string.Empty;
        }
    }
}
