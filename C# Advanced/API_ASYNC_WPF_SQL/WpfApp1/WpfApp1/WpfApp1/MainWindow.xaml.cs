using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Complaint>? allComplaints;

        public MainWindow()
        {
            InitializeComponent();
            InitialLoadData();
        }

        private void ReloadMainWindow()
        {
            InitializeComponent();
            InitialLoadData();

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Complaints Comp = new Complaints();
            Comp.DisposeClient();

        }

        private async void InitialLoadData()
        {
            Complaints Comp = new Complaints();

            var allComp = await Comp.GetAllComplaints();
            allComplaints =  allComp.Value;

            Listbox1.Items.Clear();

            foreach (var i in allComplaints)
            {
                Listbox1.Items.Add(i.Id + " / " + i.Description + " / " + i.Location + " / " + i.Category + " / " + i.Complainant.Name);
            }

            ComboCategory.ItemsSource = Enum.GetValues(typeof(ComplaintCategory));
            ComboStatus.ItemsSource = Enum.GetValues(typeof(ComplaintStatus));
            ComboSearch.ItemsSource = Enum.GetValues(typeof(ComplaintSearch));
            //ChangeComplaintItems(allComplaints.First().Id);
            Listbox1.SelectedIndex = 0;
        }

        private void ChangeComplaintItems(Guid complaintGuid) 
        {
            foreach (var i in allComplaints)
            {
                if (i.Id.Equals(complaintGuid))
                {
                    TextId.Text = i.Id.ToString();
                    TextDescription.Text = i.Description;
                    TextLocation.Text = i.Location;
                    ComboCategory.SelectedItem = i.Category;
                    ComboStatus.SelectedItem = i.Status;
                    TextCreatedAt.Text = i.CreatedAt.ToString();
                    TextUpdatedAt.Text = i.UpdatedAt.ToString();
                    TextComplainant.Text = i.Complainant.ToString();
                    TextPersID.Text = i.Complainant.id.ToString();
                    TextPersName.Text = i.Complainant.Name;
                    TextPersApartment.Text = i.Complainant.Apartment.ToString();
                    TextPersBuilding.Text = i.Complainant.Building.ToString();
                }
            }
        }

        private void Listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listbox1.Items.Count > 0)
            {
                string selectedItem = Listbox1.SelectedItem.ToString().Substring(0, Listbox1.SelectedItem.ToString().IndexOf("/")).Trim();
                Guid selectedGuid = Guid.Parse(selectedItem);
                ChangeComplaintItems(selectedGuid);
            }
        }

        private void TextDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null) 
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).Description = TextDescription.Text;

        }

        private void TextLocation_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).Location = TextLocation.Text;
        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).Category = (ComplaintCategory)ComboCategory.SelectedItem;
        }

        private void ComboStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).Status = (ComplaintStatus)ComboCategory.SelectedItem;
        }

        private void TextCreatedAt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).CreatedAt = DateTime.Parse(TextCreatedAt.Text);
        }

        private void TextUpdatedAt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Id.Equals(Guid.Parse(TextId.Text))).UpdatedAt = DateTime.Parse(TextUpdatedAt.Text);
        }

        private void TextPersName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Complainant.id.Equals(Guid.Parse(TextPersID.Text))).Complainant.Name = TextPersName.Text;
        }

        private void TextPersBuilding_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Complainant.id.Equals(Guid.Parse(TextPersID.Text))).Complainant.Building = TextPersBuilding.Text;
        }

        private void TextPersApartment_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (allComplaints != null)
                allComplaints.Find(x => x.Complainant.id.Equals(Guid.Parse(TextPersID.Text))).Complainant.Apartment = TextPersApartment.Text;
        }

        private async void BottonSaveData_Click(object sender, RoutedEventArgs e)
        {
            Complaints Comp = new Complaints();

            var request = await Comp.PostAllComplaints(allComplaints);

            ReloadMainWindow();
        }
        private void BottonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (allComplaints != null) 
            {
                List<Complaint> matchingComplaints = new List<Complaint>();
                ListboxSearch.Items.Clear();

                try
                {
                    switch (ComboSearch.SelectedItem)
                    {
                        case ComplaintSearch.Id:
                            matchingComplaints = allComplaints.FindAll(x => x.Id.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.Description:
                            matchingComplaints = allComplaints.FindAll(x => x.Description.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.Location:
                            matchingComplaints = allComplaints.FindAll(x => x.Location.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.Category:
                            matchingComplaints = allComplaints.FindAll(x => x.Category.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.Status:
                            matchingComplaints = allComplaints.FindAll(x => x.Status.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.CreatedAt:
                            matchingComplaints = allComplaints.FindAll(x => x.CreatedAt.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.UpdatedAt:
                            matchingComplaints = allComplaints.FindAll(x => x.UpdatedAt.ToString().Equals(TextSearch.Text));
                            break;
                        case ComplaintSearch.Complainant:
                            matchingComplaints = allComplaints.FindAll(x => x.Complainant.ToString().Equals(TextSearch.Text));
                            break;
                        default:
                            break;
                    }
                   
                    if (!(matchingComplaints.Count == 0))
                    {
                        foreach (var i in matchingComplaints)
                        {
                            ListboxSearch.Items.Add(i.Id + " / " + i.Description + " / " + i.Location + " / " + i.Category + " / " + i.Complainant.Name);
                        }
                    }
                    else 
                    {
                        MessageBox.Show("No entrys found.");
                    }

                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("No entrys found.");
                }
            }
        }
        private void ListboxSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListboxSearch.SelectedItem != null)
            {
                string selectedItem = ListboxSearch.SelectedItem.ToString().Substring(0, ListboxSearch.SelectedItem.ToString().IndexOf("/")).Trim();
                Guid selectedGuid = Guid.Parse(selectedItem);
                ChangeComplaintItems(selectedGuid);
            }
        }

        private void BottonNewCompliant_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want add a new compliance?", "Confirmation", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.Yes)
            {
                Complaint Comp = new Complaint();

                Comp.Id = Guid.NewGuid();
                Comp.Description = string.Empty;
                Comp.Location = string.Empty;
                Comp.Category = ComplaintCategory.Maintenance;
                Comp.Status = ComplaintStatus.Pending;
                Comp.CreatedAt = System.DateTime.Now;
                Comp.UpdatedAt = System.DateTime.Now;

                Person Pers = new Person();
                Pers.id = Guid.NewGuid();
                Pers.Name = string.Empty;
                Pers.Apartment = string.Empty;
                Pers.Building = string.Empty;

                Comp.Complainant = Pers;

                allComplaints.Add(Comp);
                ChangeComplaintItems(Comp.Id);
            }
        }

        private void DatepickerCreatedAt_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if (DatepickerCreatedAt.SelectedDate.HasValue)
                TextCreatedAt.Text = DatepickerCreatedAt.SelectedDate.Value.ToString();
        }

        private void DatepickerUpdateAt_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if (DatepickerUpdateAt.SelectedDate.HasValue)
                TextUpdatedAt.Text = DatepickerUpdateAt.SelectedDate.Value.ToString();
        }
    }
}
