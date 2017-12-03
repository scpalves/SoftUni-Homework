﻿namespace LearningSystem.Web.Models.Home
{
    using System.Collections.Generic;
    using Services.Models;

    public class HomeIndexViewModel : SearchFormModel
    {
        public IEnumerable<CourseListingServiceModel> Courses { get; set; }
    }
}
