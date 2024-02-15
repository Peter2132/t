using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace WpfApp4_Ezednevnik
{
    
    
    public partial class MainWindow : Window
    {
        private Dictionary<DateTime, List<Note>> ezednevnilnote;

        public MainWindow()
        {
            InitializeComponent();
            ezednevnilnote = new Dictionary<DateTime, List<Note>>();
            DatePicker.SelectedDate = DateTime.Today;
            LoadNotes();
            UpdateNotes();

            Example.DisplayMemberPath = "Name";

            Example.SelectionChanged += Example_SelectChang;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = DatePicker.SelectedDate ?? DateTime.Today;

            
            Note newNote = new Note(TextBox.Text, TextBox1.Text);

            ezednevnilnote[selectedDate].Add(newNote);

            TextBox.Text = "";
            TextBox1.Text = "";
            UpdateNotes();

            SaveNotes();
        }
        private void Example_SelectChang(object sender, SelectionChangedEventArgs e)
        {
            if (Example.SelectedItem != null)
            {

                Note selectNote = Example.SelectedItem as Note;

                
                TextBox.Text = selectNote.Name;
                TextBox1.Text = selectNote.Description;
            }
            else
            {
                
                TextBox.Text = "";
                TextBox1.Text = "";
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Note selectNote = Example.SelectedItem as Note;


            if (selectNote != null)
            {
                selectNote.Name = TextBox.Text;
                selectNote.Description = TextBox1.Text;

                UpdateNotes();

                SaveNotes();
            }
            
        }

        private void Delete__Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = DatePicker.SelectedDate ?? DateTime.Today;

            if (ezednevnilnote.ContainsKey(selectedDate))
            {
                ezednevnilnote[selectedDate].Remove(Example.SelectedItem as Note);

                UpdateNotes();

                SaveNotes();
            }
        }

        private void UpdateNotes()
        {
            DateTime selectedDate = DatePicker.SelectedDate ?? DateTime.Today;

            if (ezednevnilnote.ContainsKey(selectedDate))
            {
                Example.ItemsSource = ezednevnilnote[selectedDate];
            }
            else
            {
                Example.ItemsSource = null;
            }
        }

        private void LoadNotes()
        {
            ezednevnilnote = SerandDeser.Deserialize("notes.json");
        }

        private void SaveNotes()
        {
            SerandDeser.Serialize(ezednevnilnote, "notes.json");
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateNotes();
        }
    }
}