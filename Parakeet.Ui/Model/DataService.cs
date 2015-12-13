using System;

namespace Parakeet.Ui.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void GetEmployee(long? id, Action<Employee, Exception> callback);
    }

    public class DataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public void GetEmployee(long? id, Action<Employee, Exception> callback)
        {
            var employee = id == null ? new Employee() : null;
            callback(employee, null);
        }
    }
}