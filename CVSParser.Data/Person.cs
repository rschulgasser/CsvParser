﻿using System;

namespace CVSParser.Data
{
    public class Person
    { public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }

        //public override string ToString()
        //{
        //    return $"{Name} - {Age}";
        //}
    }
}
