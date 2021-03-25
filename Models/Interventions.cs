using System;
using System.Collections.Generic;

namespace Rocket_Elevators_Rest_API.Models
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public int? BatteryId { get; set; }
        public int? ColumnId { get; set; }
        public int? ElevatorId { get; set; }
        public int? EmployeeId { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }
        public long? EmployeesId { get; set; }
        public long? CustomersId { get; set; }
        public long? BuildingsId { get; set; }

        public DateTime? start_intervention { get; set; }

        public DateTime? end_intervention { get; set; }

        public virtual Buildings Buildings { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
