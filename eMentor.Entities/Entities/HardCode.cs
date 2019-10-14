using eMentor.Entities.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eMentor.Entities
{
    public class HardCode : BaseEntity
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }

}
