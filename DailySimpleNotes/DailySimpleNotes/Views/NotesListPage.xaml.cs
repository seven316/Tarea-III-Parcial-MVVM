using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailySimpleNotes.Models;
using DailySimpleNotes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailySimpleNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {

        public NotesListPage()
        {
            InitializeComponent();
           
            BindingContext = new NotesListViewModel() { Navigation = this.Navigation };
        }

    }
}