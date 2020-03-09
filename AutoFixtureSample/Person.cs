using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AutoFixtureSample
{
    public class Person
    {
        public Guid Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        [Range(10, 80)]
        public int Age { get; set; }

        public DateTime CreateTime { get; set; }
    }
}