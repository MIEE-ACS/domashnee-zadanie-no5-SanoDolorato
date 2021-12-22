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


namespace domashnee_zadanie_no5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Date
    {
        public int day;
        public int month;
        public int year;
        public Date(int day_k,int month_k,int year_k)
        {
            day = day_k;
            month = month_k;
            year = year_k;
        }
        public override string ToString()
        {
            return $"{day}.{month}.{year}";
        }
        public static string printDatesList(List<Date> dates) {
            string datesResult = "";
            foreach (var date in dates)
            {
                datesResult += date.ToString() + "\n";

            }
            return datesResult;
        }

    }
    
    
    public partial class MainWindow : Window
    {
        public List<Date> dates = new List<Date> 
        { 
            new Date(5, 06, 2002),
            new Date(25, 07, 2009),
            new Date(31, 01, 2022)
        };
        public MainWindow()
        {
            InitializeComponent();

            string datesResult  =  Date.printDatesList(dates);
            Text_today_date.Text = datesResult;
        }

        private void add_date_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                int day = int.Parse(text_day.Text);
                int month = int.Parse(text_month.Text);
                int year = int.Parse(text_year.Text);

                dates.Add(new Date(day, month, year));
                string datesResult = Date.printDatesList(dates);
                Text_today_date.Text = datesResult;
                if (day > 0 && day < 32 && month > 0 && month < 13)
                {
                    Text_error_date.Text = "Данные введены корректно";
                }
                else
                {
                    Text_error_date.Text = "#Ошибка \n Данные введены не корректно!!";
                }
                
            }
            catch (System.FormatException)
            {
                Text_error_date.Text = "#Ошибка \n Данные введены не корректно!!";
            }
            

        }

        private void plus_day_Click(object sender, RoutedEventArgs e)
        {
            int day = int.Parse(text_day.Text);
            text_day.Text = (day+1).ToString();
        }

        private void minus_day_Click(object sender, RoutedEventArgs e)
        {
            int day = int.Parse(text_day.Text);
            text_day.Text = (day-1).ToString();
        }

        private void plus_month_Click(object sender, RoutedEventArgs e)
        {
            int month = int.Parse(text_month.Text);
            text_month.Text = (month + 1).ToString();
        }

        private void minus_month_Click(object sender, RoutedEventArgs e)
        {
            int month = int.Parse(text_month.Text);
            text_month.Text = (month-1).ToString();
        }

        private void plus_year_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(text_year.Text);
            text_year.Text = (year + 1).ToString();
        }

        private void minus_year_Click(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(text_year.Text);
            text_year.Text = (year - 1).ToString();
        }

        private void button_remove_date_Click(object sender, RoutedEventArgs e)
        {

            dates.RemoveAt(dates.Count-1);
            string datesResult = Date.printDatesList(dates);
            Text_today_date.Text = datesResult;
        }
    }
}
