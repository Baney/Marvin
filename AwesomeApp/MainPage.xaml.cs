using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AwesomeApp.Data;
using System.Diagnostics;

namespace AwesomeApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            
        }



        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        
        void Handle_Clicked(object sender, System.EventArgs e)
        {

            var plate = PlateEntry.Text;
            var count = 0;

            for (int i=0; i < plate.Length; i++)
            {
                if(!Char.IsLetterOrDigit(plate[i]))
                {
                    //((Button)sender).Text = $"Your Plate is Invalid";
                    count ++;
                    Invalidentry();
                    break;
                    
                }
                else
                {
                    continue;
                }
            }

            if (count is 0)
            {
                Confirmentry(PlateEntry.Text.ToUpper());

               
            }
           
          
        }

        async void Invalidentry()
        {
            await DisplayAlert("Invalid Entry", "Please Re-Enter Your Registiration", "OK");
        }

        async void Confirmentry( string plate)
        {
            var ans =  await DisplayAlert("Confirm", $"Is {plate} Correct?", "YES", "NO");
            if(ans ==true)
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "registrations.db");
                using  (var db = new DatabaseContext(dbPath))
                {
                    db.Add(new RegDb () { RegId = 9, Registration = PlateEntry.Text.ToUpper(), StartTime = DateTime.Now });
                    db.SaveChanges();

                    
                    var p = db.RegDbs.ToList();

                    for (var index = 0; index < p.Count; index += 1)
                    {
                        Debug.WriteLine(p[index].StartTime.ToString());
                    }
                    

                }
            }

            
            
        }
    }
}
