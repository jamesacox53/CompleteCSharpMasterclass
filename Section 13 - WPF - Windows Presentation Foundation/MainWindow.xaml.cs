using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Section_13___WPF___Windows_Presentation_Foundation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Match> matches = new List<Match>();
            matches.Add(new Match(3, 2, "Bayern Munich", "Real Madrid", 85));
            matches.Add(new Match(4, 2, "Bayern Munich", "Barcelona",75));
            matches.Add(new Match(1, 0, "Tottenham Hotspur", "Newcastle United", 30));

            lbMatches.ItemsSource = matches;
        }

        private void ShowSelectedButtonClicked(object sender, RoutedEventArgs e)
        {
            if (lbMatches.SelectedItem != null)
            {
                MessageBox.Show("Selected Match: " + lbMatches.SelectedItem.ToString());
            }
        }
    }

    public class Match
    {
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public string Team1 { get; set; }
        public string Team2 { get; set; }

        public int Completion { get; set; }

        public Match(int score1, int score2, string team1, string team2, int completion)
        {
            this.Score1 = score1;
            this.Score2 = score2;
            this.Team1 = team1;
            this.Team2 = team2;
            this.Completion = completion;
        }

        public override string ToString()
        {
            return $"{Team1} {Score1} : {Score2} {Team2}";
        }

    }
}
