using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymProdactsModels
{
    public class Trainer
    {
        string trainerId;
        string trainerFirstName;
        string trainerLastName;
        string trainerYear;
        string CountryId;
        string trainerPicture;



        public string trainerId
        {

            get { return this.trainerId; }

            set {; this.trainerId = value; }
        }
        [RequErrorMessage="trainer first name cannot be empty"]
        public string trainerLastName
        {

            get { return this.trainerLastName; }

            set {; this.trainerLastName = value; }
        }
        public string trainerFirstName
        {

            get { return this.trainerFirstName; }

            set {; this.trainerFirstName = value; }
        }
        public string trainerYear
        {

            get { return this.trainerYear; }

            set {; this.trainerYear = value; }
        }
        public string CountryId
        {

            get { return this.CountryId; }

            set {; this.CountryId = value; }
        }
        public string trainerPicture
        {

            get { return this.trainerPicture; }

            set {; this.trainerPicture = value; }
        }
    }
}
