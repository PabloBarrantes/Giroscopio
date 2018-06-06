using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Acelerometro.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Giroscopio : ContentPage
    {
        SensorSpeed speed = SensorSpeed.Normal;

        public Giroscopio()
        {
            InitializeComponent();
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
            this.IniciarGiroscopio.Clicked += IniciarGiroscopio_Clicked;
            this.PararGiroscopio.Clicked += PararGiroscopio_Clicked;
        }

        private void PararGiroscopio_Clicked(object sender, EventArgs e)
        {
            Gyroscope.Stop();
        }

        private void IniciarGiroscopio_Clicked(object sender, EventArgs e)
        {
            Gyroscope.Start(speed);
        }

        private void Gyroscope_ReadingChanged(GyroscopeChangedEventArgs e)
        {
            var data = e.Reading;
            // Process Angular Velocity X, Y, and Z
            this.resultado.Text = "Reading: X:" + data.AngularVelocity.X + ", Y:" + data.AngularVelocity.X + ", Z:" + data.AngularVelocity.Z;

        }

    }
}