using RealTimeDataUpdate.Business.Abstract;
using RealTimeDataUpdate.DataAccess.Abstract;
using RealTimeDataUpdate.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeDataUpdate.Business.Concrete
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(ActivityLog entity)
        {
            try
            {
                _unitOfWork.ActivityLogs.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<ActivityLog> GetAll()
        {
            try
            {
                var activityLogs = _unitOfWork.ActivityLogs.GetAll();
                return activityLogs;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<ActivityLog> GetAllByUserId(int id)
        {
            try
            {
                var activityLogs = _unitOfWork.ActivityLogs.GetAll().Where(x=>x.UserId == id).ToList();
                return activityLogs;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public ActivityLog GetById(int id)
        {
            try
            {
                var activity = _unitOfWork.ActivityLogs.GetById(id);
                return activity;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }


        public void Remove(int id)
        {
            try
            {
                var activity = _unitOfWork.ActivityLogs.GetById(id);
                if (activity != null)
                {
                    _unitOfWork.ActivityLogs.Remove(activity);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(ActivityLog entity)
        {
            try
            {

                _unitOfWork.ActivityLogs.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

    }
}
