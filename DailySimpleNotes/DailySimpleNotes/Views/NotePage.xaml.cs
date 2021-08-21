using DailySimpleNotes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailySimpleNotes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage : ContentPage
    {
        public NoteViewModel ViewModel { get; private set; }
        public NotePage(NoteViewModel nvm)
        {
            InitializeComponent();

            ViewModel = nvm;
            this.BindingContext = ViewModel;
        }
    }
}