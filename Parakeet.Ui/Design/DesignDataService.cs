using Parakeet.Ui.Model;
using System;

namespace Parakeet.Ui.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void GetEmployee(long? id, Action<Employee, Exception> callback)
        {
            var employee = new Employee { FirstName = "Designer", LastName = "Designer" };
            callback(employee, null);
        }
    }
}