using Caliburn.Micro;
using ResPublicaDashboard.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ResPublicaDashboard.ViewModels
{
    public class RecruitmentViewModel : Screen, IMainScreenTabItem
    {
        private PlayerClass _selectedPlayerClass;
        private List<string> _specializations;

        public RecruitmentViewModel()
        {
            DisplayName = "Rekrutacja";
            WowClasses = PopulateData();
        }

        public List<PlayerClass> WowClasses { get; set; }
        public List<string> Specializations
        {
            get 
            { 
                return _specializations; 
            }
            set
            {
                _specializations = value;
            }
        }

        public PlayerClass SelectedPlayerClass 
        {
            get
            {
                return _selectedPlayerClass;
            }
            set
            {
                _selectedPlayerClass = value;
                Specializations = _selectedPlayerClass.Specializations;
                NotifyOfPropertyChange(() => Specializations);
            }
        }

        public string SelectedSpecialization { get; set; }

        private List<PlayerClass> PopulateData()
        {
            return new List<PlayerClass>()
            {
                new PlayerClass { ClassName = "Warrior", Specializations = new List<string>() {"Protection", "Arms", "Fury"} },
                new PlayerClass { ClassName = "Rogue", Specializations = new List<string>() {"Assasination", "Subtlety", "Outlaw"} },
                new PlayerClass { ClassName = "Priest", Specializations = new List<string>() {"Shadow", "Holy", "Discipline"} },
                new PlayerClass { ClassName = "Paladin", Specializations = new List<string>() {"Holy", "Retribution", "Protection"} },
                new PlayerClass { ClassName = "Druid", Specializations = new List<string>() {"Guardian", "Feral", "Restoration", "Balance"} },
                new PlayerClass { ClassName = "Death Knight", Specializations = new List<string>() {"Blood", "Frost", "Unholy"} },
                new PlayerClass { ClassName = "Monk", Specializations = new List<string>() {"Brewmaster", "Windwalker", "Mistweaver"} },
                new PlayerClass { ClassName = "Hunter", Specializations = new List<string>() {"Survival", "Beast Mastery", "Marksmanship"} },
                new PlayerClass { ClassName = "Demon Hunter", Specializations = new List<string>() {"Vengeance", "Havoc"} },
                new PlayerClass { ClassName = "Shaman", Specializations = new List<string>() {"Restoration", "Elemental", "Enhancement"} },
                new PlayerClass { ClassName = "Mage", Specializations = new List<string>() {"Fire", "Frost", "Arcane"} },
                new PlayerClass { ClassName = "Warlock", Specializations = new List<string>() {"Affliction", "Destruction", "Demonology"} },
                new PlayerClass { ClassName = "Warrior", Specializations = new List<string>() {"Protection", "Arms", "Fury"} },
            };
        }
    }

}
