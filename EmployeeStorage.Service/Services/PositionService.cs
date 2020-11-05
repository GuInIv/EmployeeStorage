using AutoMapper;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.DataAccess.Interfaces;
using EmployeeStorage.Service.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeStorage.Service.Services
{
    public class PositionService : IPositionService
    {
        IUnitOfWork DataBase { get; set; }

        public PositionService(IUnitOfWork uow)
        {
            this.DataBase = uow;
        }

        public void Create(Position position)
        {
            DataBase.Positions.Create(position);
            Save();
        }

        public IEnumerable<Position> GetAll()
        {
            return DataBase.Positions.GetAll();
        }

        public Position GetById(int id)
        {
            return DataBase.Positions.GetById(id);
        }

        public void Update(Position position)
        {
            DataBase.Positions.Update(position);
            Save();
        }

        public void Delete(int id)
        {
            DataBase.Positions.Delete(new Position { Id = id });
            Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Save()
        {
            DataBase.Save();
        }
    }
}
