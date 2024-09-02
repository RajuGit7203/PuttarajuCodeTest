using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mouri.Shared
{
    public class Animals
    {
        private readonly string _type;
        public Animals(string type)
        {
            _type = type;
        }

        public string ScanAnimalSpeakType()
        {
            
            string animalType = _type;
            string speakType = string.Empty;
            switch (animalType)
            {
                case "Dog":
                    speakType= "bow-bow";
                    break;
                case "Cat":
                    speakType = "meow";
                    break;
                default:
                    speakType = "silence";
                    break;
            }
            return speakType;
        }

   

}
}
