using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo.Models;

namespace HotelInfo.ModelBuilders
{
    public class WorkerEditModelBuilder : IModelBuilder<WorkerEditModel, Worker>
    {
        public WorkerEditModel CreateFrom(Worker entity)
        {
            return new WorkerEditModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                SecondName = entity.SecondName,
                IndividualId = entity.IndividualId,
                HotelTitle = entity.Hotel.Title,
                PositionTitle = entity.Position.Title
            };
        }

        public WorkerEditModel Rebuild(WorkerEditModel model)
        {
            return model;
        }
    }
}