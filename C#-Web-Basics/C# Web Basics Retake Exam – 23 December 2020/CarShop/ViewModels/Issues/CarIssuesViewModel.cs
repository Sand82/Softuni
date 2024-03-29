﻿using System.Collections.Generic;

namespace CarShop.ViewModels.Issues
{
    public class CarIssuesViewModel
    {
        public string Id { get; set; }

        public int Year { get; set; }

        public string Model { get; set; }

        public bool UserIsMechanic { get; set; }

        public IEnumerable<IssueListingViewModel> Issues { get; set; }
    }
}
