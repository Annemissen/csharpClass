namespace SolvedExercises
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonSet")]
    public partial class PersonSet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Age { get; set; }

        public int Weight { get; set; }

        public int? Score { get; set; }

        public bool Accepted { get; set; }
    }
}
