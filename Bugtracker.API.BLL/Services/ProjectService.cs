﻿using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using Bugtracker.API.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Services
{
    public class ProjectService : IProjectService, IService<int, ProjectDto>
    {
        private IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public IEnumerable<ProjectDto> GetAll()
        {
            return _projectRepository.GetAll().Select(project => project.ToDto());
        }
        public ProjectDto GetById(int id)
        {
            ProjectEntity entity = _projectRepository.GetById(id);
            if (entity is null)
                return null;
            else
                return entity.ToDto();
        }
        public int Add(ProjectDto projectDto)
        {
            // TODO : projectDto name exist ? Do SP
            return _projectRepository.Add(projectDto.ToEntity());
        }

        public bool Remove(int id)
        {
            return _projectRepository.Remove(id);
        }
        public bool Edit(ProjectDto projectDto)
        {
            // TODO : projectDto name exist ?
            return _projectRepository.Edit(projectDto.ToEntity());
        }
    }
}