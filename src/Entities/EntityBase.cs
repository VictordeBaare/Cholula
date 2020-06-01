using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoilerPlateCore.Entities
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public DateTime ModifiedOn { get; set; }

        public DateTime ModifiedOnUtc { get; set; }
    }
}
