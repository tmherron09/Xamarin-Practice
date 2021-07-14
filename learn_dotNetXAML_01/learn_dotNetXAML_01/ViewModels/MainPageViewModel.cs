using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace learn_dotNetXAML_01.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<string> AllNotes { get; set; }

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        string selectedNote;
        public string SelectedNote {
            get => selectedNote;
            set
            {
                selectedNote = value;

            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command SelectedNoteChangedCommand { get; }


        public MainPageViewModel()
        {

            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);

                TheNote = string.Empty;
            });

            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailedVM = new DetailPageViewModel(SelectedNote);

                var detailPage = new DetailPage();

                detailPage.BindingContext = detailedVM;

                await Application.Current.MainPage.Navigation.PushAsync(detailPage);

            });

        }

        

        


    }
}
