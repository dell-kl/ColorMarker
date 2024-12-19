using CommunityToolkit.Maui.Alerts;

namespace ColorMarker
{
    public partial class MainPage : ContentPage
    {
        private string valorhex;

        public MainPage()
        {
            this.valorhex = "";
            InitializeComponent();
        }

        private void VerificarColores(object sender, EventArgs args)
        {
            var color1 = SldRed.Value;
            var color2 = SldGreen.Value;
            var color3 = SldBlue.Value;

            setearValores(color1, color2, color3);
        }

        public void setearValores(double color1, double color2, double color3)
        {
            var colorFinal = Color.FromRgb(color1, color2, color3);
            this.valorhex = colorFinal.ToHex();
            LabelHex.Text = "HEX VALUE: " + this.valorhex;
            Contenedor.BackgroundColor = colorFinal;

        }

        private void GenerarColorRandom(object sender, EventArgs args)
        {
            //vamos a generar un color random respectivo en este aspecto... 
            Random random = new Random();

            double color1 = random.NextDouble();
            double color2 = random.NextDouble();
            double color3 = random.NextDouble();
            
            setearValores(color1, color2, color3);

            //cambiar los colores de la parte de nuestro slider. 
            SldRed.Value = color1;
            SldGreen.Value = color2;
            SldBlue.Value = color3;
        }

        private async void CopiarHex(object sender, EventArgs args)
        {
            await Clipboard.SetTextAsync(this.valorhex);
            await CommunityToolkit.Maui.Alerts.Toast.Make("Copiado al portapapeles").Show();
        }

    }

}
