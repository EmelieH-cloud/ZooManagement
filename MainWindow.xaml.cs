using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ZooManagement.database;
using ZooManagement.Models;

namespace ZooManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateWithData();


        }

        public void clearList()
        {
            lstAnimals.Items.Clear();
        }

        public void AddAnimal()
        {
            string name = txtname.Text;
            string species = txtspecies.Text;
            ComboBoxItem selectedkeeper = (ComboBoxItem)cbKeepers.SelectedItem;
            ComboBoxItem selectedhabitat = (ComboBoxItem)cbHabitat.SelectedItem;

            if (selectedhabitat != null && selectedhabitat != null && name.Length > 0 && species.Length > 0)
            {
                Keeper castedKeeper = (Keeper)selectedkeeper.Tag;
                Habitat castedHabitat = (Habitat)selectedhabitat.Tag;

                Animal newAnimal = new()
                {
                    Name = name,
                    Species = species,
                    HabitatId = castedHabitat.HabitatId,
                    KeeperId = castedKeeper.KeeperId

                };

                using (ZooDbContext context = new())
                {
                    context.Animals.Add(newAnimal);
                    context.SaveChanges();
                }


            }
        }


        public void PopulateWithData()
        {
            using (ZooDbContext context = new())
            {
                var animalsList = context.Animals.Include(animals => animals.Keeper).ToList();
                var keepersList = context.Keepers.ToList();
                var habitatsList = context.Habitats.ToList();

                foreach (var habitat in habitatsList)
                {
                    if (habitat != null)
                    {
                        ComboBoxItem comboBoxItem = new ComboBoxItem();
                        comboBoxItem.Tag = habitat;
                        comboBoxItem.Content = habitat.Name;
                        cbHabitat.Items.Add(comboBoxItem);
                    }
                }

                foreach (var animal in animalsList)
                {
                    ListViewItem displayAnimalitem = new ListViewItem();
                    displayAnimalitem.Tag = animal;
                    if (animal.Keeper != null)
                    {
                        displayAnimalitem.Content = $"{animal.Name}, caretaker: {animal.Keeper.Name}";
                    }
                    lstAnimals.Items.Add(displayAnimalitem);
                }

                foreach (var keeper in keepersList)
                {
                    ComboBoxItem displayKeeperitem = new ComboBoxItem();
                    displayKeeperitem.Tag = keeper;
                    displayKeeperitem.Content = keeper.Name;
                    cbKeepers.Items.Add(displayKeeperitem);
                }


            }

        }

        private void btnAddAnimal_Click(object sender, RoutedEventArgs e)
        {
            AddAnimal();
            clearList();
            PopulateWithData();

        }
    }

}
