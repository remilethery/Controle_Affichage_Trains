using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffichageTempsReel.ViewModels
{
    public class TrainModelView : BaseViewModel
    {

        public TrainModelView (Train train)
        {
            this.Train = train;
        }

        public Train Train { get; set; }

        public string IDTrain
        {
            get
            {
                return this.Train.id_train.ToString() ;
            }
            set
            {
                if (Int32.TryParse(value, out int tempID))
                {
                    this.Train.id_train = tempID;
                }
                NotifyPropertyChanged(nameof(IDTrain));
            }
        }
        public string Line
        {
            get
            {
                return this.Train.ligne;
            }
            set
            {
                this.Train.ligne = value;
                NotifyPropertyChanged(nameof(Line));
            }
        }
        public string Destination
        {
            get
            {
                return this.Train.direction;
            }
            set
            {
                this.Train.direction = value;
                NotifyPropertyChanged(nameof(Destination));
            }
        }
        public String TimeOfPassage
        {
            get
            {
                return this.Train.horaire;
            }
                
            set
            {
                this.Train.horaire = value;
                NotifyPropertyChanged(nameof(TimeOfPassage));
            }
        }
        public String Stops
        {
            get
            {
                return this.Train.info;
            }
            set
            {
                this.Train.info = value;
                NotifyPropertyChanged(nameof(Stops));
            }
        }
        public String Platform
        {
            get
            {
                return this.Train.voie;
            }
            set
            {
                this.Train.voie = value;
                NotifyPropertyChanged(nameof(Platform));
            }
        }


    }
}
