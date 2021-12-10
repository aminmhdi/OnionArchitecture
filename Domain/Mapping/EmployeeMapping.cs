using Domain.DataModel;
using Domain.Dto._Base;

namespace Domain.Mapping
{
    public static class EmployeeMapping
    {

        #region Employee => EmployeeDto

        public static EmployeeDto ToDto(this Employee model)
        {
            return new EmployeeDto
            {
                AccessForms = model.AccessForms,
                BirthDate = model.BirthDate,
                Country = model.Country,
                DomainSquad = model.DomainSquad,
                Email = model.Email,
                FormDate = model.FormDate,
                GovernanceHandler = model.GovernanceHandler,
                GSMNo = model.GSMNo,
                Id = model.Id,
                LaptopModel = model.LaptopModel,
                LaptopVdiForm = model.LaptopVdiForm,
                LaptopVdiFormDate = model.LaptopVdiFormDate,
                LaptopVdiId = model.LaptopVdiId,
                LeaveDate = model.LeaveDate,
                Name = model.Name,
                Notes = model.Notes,
                OnboardDate = model.OnboardDate,
                OTPStatus = model.OTPStatus,
                Payroll = model.Payroll,
                RequestDate = model.RequestDate,
                SAPSicilNo = model.SAPSicilNo,
                Status = model.Status,
                Team = model.Team,
                Username = model.Username,
                VFBizFormNo = model.VFBizFormNo,
                Workplace = model.Workplace
            };
        }

        #endregion

        #region EmployeeDto => Employee

        public static Employee ToDataModel(this EmployeeDto model)
        {
            return new Employee
            {
                AccessForms = model.AccessForms,
                BirthDate = model.BirthDate,
                Country = model.Country,
                DomainSquad = model.DomainSquad,
                Email = model.Email,
                FormDate = model.FormDate,
                GovernanceHandler = model.GovernanceHandler,
                GSMNo = model.GSMNo,
                Id = model.Id,
                LaptopModel = model.LaptopModel,
                LaptopVdiForm = model.LaptopVdiForm,
                LaptopVdiFormDate = model.LaptopVdiFormDate,
                LaptopVdiId = model.LaptopVdiId,
                LeaveDate = model.LeaveDate,
                Name = model.Name,
                Notes = model.Notes,
                OnboardDate = model.OnboardDate,
                OTPStatus = model.OTPStatus,
                Payroll = model.Payroll,
                RequestDate = model.RequestDate,
                SAPSicilNo = model.SAPSicilNo,
                Status = model.Status,
                Team = model.Team,
                Username = model.Username,
                VFBizFormNo = model.VFBizFormNo,
                Workplace = model.Workplace
            };
        }

        #endregion

        #region IEnumerable<EmployeeDto> => IEnumerable<Employee>

        public static IEnumerable<Employee> ToDataModelList(this IEnumerable<EmployeeDto> model) => model.Select(ToDataModel);

        #endregion

        #region IEnumerable<Employee> => IEnumerable<EmployeeDto>

        public static IEnumerable<EmployeeDto> ToDtoList(this IEnumerable<Employee> model) => model.Select(ToDto);

        #endregion

        #region PagedResultDto<Employee> => PagedResultDto<EmployeeDto>

        public static PagedResultDto<EmployeeDto> ToPagedResultDto(this PagedResultDto<Employee> model)
        {
            return new PagedResultDto<EmployeeDto>
            {
                List = model.List.ToDtoList(),
                Total = model.Total
            };
        }

        #endregion
    }
}
