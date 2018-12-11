using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GymCore.Models
{
    public class WorkoutsModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Workout Name")]
        public string WorkoutName { get; set; }

        [DisplayName("Sets")]
        public int WorkoutSets { get; set; }

        [DisplayName("Rep Count 1")]
        public int WorkoutReps1 { get; set; }
        [DisplayName("Weight 1")]
        public int Weight1 { get; set; }

        [DisplayName("Rep Count 2")]
        public int WorkoutReps2 { get; set; }
        [DisplayName("Weight 2")]
        public int Weight2 { get; set; }

        [DisplayName("Rep Count 3")]
        public int WorkoutReps3 { get; set; }
        [DisplayName("Weight 3")]
        public int Weight3 { get; set; }

        [DisplayName("Rep Count 4")]
        public int WorkoutReps4 { get; set; }
        [DisplayName("Weight 4")]
        public int Weight4 { get; set; }

        [DisplayName("Date & Time")]
        public DateTime DateTime { get; set; }

        [DisplayName("Who lifted?")]
        public string UserName { get; set; }

        public bool MakePublic { get; set; }
    }
}