﻿using Application.Contracts.ReadPersistence.Common;
using Domain.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.ReadPersistence.ReadWorkExperience
{
    public interface IReadWorkExperienceRepository : IReadBaseRepository<WorkExperience>
    {
    }
}