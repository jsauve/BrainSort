using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PropertyChanged;

namespace BrainSort
{
    [AddINotifyPropertyChangedInterface]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Entry.TextChanged += Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ReversedText = new string(e?.NewTextValue?.ToUpperInvariant()?.Where(char.IsLetterOrDigit)?.Reverse()?.ToArray()) ?? null;
            SortedText = new string(e?.NewTextValue?.ToUpperInvariant()?.Where(char.IsLetterOrDigit)?.OrderBy(x => x)?.ToArray()) ?? null;
            ReversedSortedText = new string(SortedText?.Reverse()?.ToArray()) ?? null;
            CharacterCount = SortedText?.Count().ToString() ?? null;
            IsShowingLabels = SortedText.Any();

            if (SortedText.Count() % 16 == 0)
                CountColor = Color.Green;
            else if (SortedText.Count() % 4 == 0)
                CountColor = Color.Orange;
            else
            {
                switch (Application.Current.RequestedTheme)
                {
                    case OSAppTheme.Light:
                        CountColor = Color.Black;
                        break;
                    case OSAppTheme.Dark:
                        CountColor = Color.White;
                        break;
                    case OSAppTheme.Unspecified:
                        CountColor = Color.Gray;
                        break;
                }  
            }
        }

        public string EntryText { get; set; }
        //public string ReversedText { get; set; }
        public string SortedText { get; set; }
        public string ReversedSortedText { get; set; }
        public string CharacterCount { get; set; }
        public bool IsShowingLabels { get; set; }
        public Color CountColor { get; set; } = Color.Black;
    }
}
