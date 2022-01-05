using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Entities.Dtos.DepartmentDto;
using VisitorSystem.Shared.Utilities.Results.Abstarct;

namespace VisitorSystem.Services.Abstract
{
    public interface IDepartmentService
    {
        Task<IDataResult<DepartmentDto>> Get(int departmentId);
        Task<IDataResult<DepartmentUpdateDto>> GetDepartmentUpdateDto(int departmentId);
        Task<IDataResult<DepartmentListDto>> GetAll();
        Task<IDataResult<DepartmentListDto>> GetAllNonDeleted();
        Task<IDataResult<DepartmentListDto>> GetAllNonDeletedAndActive();

        Task<IDataResult<DepartmentDto>> Add(DepartmentAddDto departmentAddDto,string createdByName);

        Task<IDataResult<DepartmentDto>> Update(DepartmentUpdateDto departmentUpdateDto, string modifieldByName);

        Task<IDataResult<DepartmentDto>> Delete(int departmentId, string modifieldByName);
        Task<IResult> HardDelete(int departmentId);

    }
}
