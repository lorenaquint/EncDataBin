

namespace Encuentas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveyDetailsView : ContentPage
	{
        private readonly string[] teams =

        {
            "Colombia",
            "México",
            "Perú",
            "Argentina",
            "Brasil",
            "Alemania",
            "España"

        };
		public SurveyDetailsView ()
		{
			InitializeComponent ();
		}

        public async void EquipoFavorito_Clicked(Object sender, EventArgs e)
        {
            var favoriteTeam = await DisplayActionSheet(Literals.FavoriteTeamTitle,
                                                       null,
                                                        null,
                                                        teams);
            if (!string.IsNullOrEmpty(favoriteTeam))
            {
                EquipoFavoritoLAbel.Text = favoriteTeam;
            }
        }
        public async void Aceptar_Clicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombreEntry.Text) || string.IsNullOrEmpty(EquipoFavoritoLAbel.Text))
            {
                await DisplayAlert("Datos Incompletos",
                                  "Recuerde Diligenciar la Información",
                                   "Aceptar");
                return;
            }
            var newSurvey = new Survey()
            {
                Nombre = NombreEntry.Text,
                FechaNacimiento = FechaNacimientoDP.Date,
                FavoriteTeam = EquipoFavoritoLAbel.Text
            };
            MessagingCenter.Send((ContentPage)this,
                                 Messages.NewSurveyComplete,
                                 newSurvey);

            await Navigation.PopAsync();
        }


    }
}