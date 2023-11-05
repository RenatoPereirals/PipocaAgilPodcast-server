using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tests.FeatureTests;
    public class UserMock
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName  { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
