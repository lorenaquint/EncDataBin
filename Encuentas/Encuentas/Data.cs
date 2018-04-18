


namespace Encuentas
{

    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class Data:Notificable
    {
        private ObservableCollection<Survey> encuestas;
        private Survey encSeleccionada;

        public Survey EncSeleccionada
        {
            get
            {
                return encSeleccionada;

            }
            set {
                if (encSeleccionada == value)
                {
                    return;
                }
                encSeleccionada = value;
                OnPropertyChanged();
            }
        }
    

        public ObservableCollection<Survey> Encuestas
        {
            get
            {
                return encuestas;
            }
            set
            {
                if (encuestas == value)
                {
                    return;
                }
                encuestas = value;
                OnPropertyChanged();
            }
        }


        public Data()
        {
            Encuestas = new ObservableCollection<Survey>();
            MessagingCenter.Subscribe<ContentPage,
           Survey>(this, Messages.NewSurveyComplete, (sender, args)
            =>
           {
               Encuestas.Add(args);


           });
        }
    }
}
