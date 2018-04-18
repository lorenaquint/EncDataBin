
namespace Encuentas
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using System;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SurveysView : ContentPage
    {
        public SurveysView()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<ContentPage,
            Survey>(this, Messages.NewSurveyComplete,(sender, args)
            =>
            {
                SurveysPanel.Children.Add(new Label()
                {
                    Text = args.ToString()
                });


            });
        }
    
        public async void AddSurvey_Clicked(Object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SurveyDetailsView());
        }

    }
}